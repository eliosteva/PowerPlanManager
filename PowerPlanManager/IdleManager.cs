﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PowerPlanManager
{
	internal class IdleManager
	{

		DataManager dm;
		PowerPlanManager ppm;



		bool idleOnScreensaver = true;
		public bool IdleOnScreensaver
		{
			get
			{
				return idleOnScreensaver;
			}
			set
			{
				if (value != idleOnScreensaver)
				{
					idleOnScreensaver = value;
					dm.SetPref("idleOnScreensaver", value.ToString());
				}
			}
		}

		bool idleOnTimeout = true;
		public bool IdleOnTimeout
		{
			get
			{
				return idleOnTimeout;
			}
			set
			{
				if (value != idleOnTimeout)
				{
					idleOnTimeout = value;
					dm.SetPref("idleOnTimeout", value.ToString());
				}
			}
		}

		int inputTimeout = 20;
		public int InputTimeout
		{
			get
			{
				return inputTimeout;
			}
			set
			{
				if (value != inputTimeout)
				{
					inputTimeout = value;
					dm.SetPref("inputTimeout", value.ToString());
				}
			}
		}

		int pollingInterval = 10;
		public int PollingInterval
		{
			get
			{
				return pollingInterval;
			}
			set
			{
				if (value != pollingInterval)
				{
					pollingInterval = value;
					dm.SetPref("pollingInterval", value.ToString());
				}
			}
		}

		bool disableWithProcesses = true;
		public bool DisableWithProcesses
		{
			get
			{
				return disableWithProcesses;
			}
			set
			{
				if (value != disableWithProcesses)
				{
					disableWithProcesses = value;
					dm.SetPref("disableWithProcesses", value.ToString());
				}
			}
		}

		string disableProcesses = "Netflix|devenv|WWAHost";
		public string DisableProcesses
		{
			get
			{
				return disableProcesses;
			}
			set
			{
				if (value != disableProcesses)
				{
					disableProcesses = value;
					dm.SetPref("disableProcesses", value.ToString().Replace('\n', '|'));
					RebuildProcessList();
				}
			}
		}


		BackgroundWorker bw;

		internal IdleManager(DataManager dm, PowerPlanManager ppm)
		{
			this.dm = dm;
			this.ppm = ppm;

			Debug.Log("initializing idle manager");

			// load prefs
			IdleOnScreensaver = dm.GetPref("idleOnScreensaver", idleOnScreensaver);
			IdleOnTimeout = dm.GetPref("idleOnTimeout", idleOnTimeout);
			InputTimeout = dm.GetPref("inputTimeout", inputTimeout);
			PollingInterval = dm.GetPref("pollingInterval", pollingInterval);
			DisableWithProcesses = dm.GetPref("disableWithProcesses", disableWithProcesses);
			DisableProcesses = dm.GetPref("disableProcesses", disableProcesses);

			// init background worker and start
			bw = new BackgroundWorker();
			bw.WorkerReportsProgress = false;
			bw.WorkerSupportsCancellation = false;
			bw.DoWork += new DoWorkEventHandler(Update);
			bw.RunWorkerAsync();

			// intercept exit event
			AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
		}

		bool close = false;

		void RebuildProcessList()
		{
			blockingProcessNames.Clear();
			if (string.IsNullOrEmpty(DisableProcesses))
			{
				string[] ss = disableProcesses.Split("\n");
				foreach (var s in ss)
				{
					blockingProcessNames.Add(s);
				}
			}
		}

		void Update(object sender, DoWorkEventArgs e)
		{
			while (!close)
			{
				Poll();
				Thread.Sleep(pollingInterval * 1000);
			}
		}

		void OnProcessExit(object sender, EventArgs e)
		{
			Debug.Log("stopping background worker");
			close = true;
		}

		List<string> blockingProcessNames = new List<string>();
		enum TargetStatus
		{
			use,
			idle,
		}

		TargetStatus currentStatus = TargetStatus.use;
		
		void Poll()
		{
			try
			{
				// check processes
				if (blockingProcessNames != null && blockingProcessNames.Count > 0)
				{
					foreach (var p in blockingProcessNames)
					{
						// if process is running
						Process[] pname = Process.GetProcessesByName(p);
						if (pname.Length != 0)
						{
							// exit idle
							ExitIdle();
							return;
						}
					}
				}

				// check timeout
				if (idleOnTimeout)
				{
					var idleTime = GetInputIdleTime();
					if (idleTime.TotalSeconds >= inputTimeout)
					{
						// enter idle
						EnterIdle();
						return;
					}
				}

				// check screenshot
				if (idleOnScreensaver)
				{
					if (GetScreenSaverRunning())
					{
						// enter idle
						EnterIdle();
						return;
					}
				}

				ExitIdle();
			}
			catch (Exception ex)
			{
				Debug.LogError(ex.ToString());
			}
		}

		bool EnterIdle()
		{
			if (currentStatus == TargetStatus.use)
			{
				currentStatus = TargetStatus.idle;
				Debug.Log("entering idle");
				ppm.ApplyIdlePowerPlan();
				return true;
			}
			return false;
		}

		bool ExitIdle()
		{
			if (currentStatus == TargetStatus.idle)
			{
				currentStatus = TargetStatus.use;
				Debug.Log("exiting idle");
				ppm.ApplyDefaultPowerPlan();
				return true;
			}
			return false;
		}
		
		#region idle timer

		static TimeSpan GetInputIdleTime()
		{
			var plii = new NativeMethods.LastInputInfo();
			plii.cbSize = (UInt32)Marshal.SizeOf(plii);

			if (NativeMethods.GetLastInputInfo(ref plii))
			{
				return TimeSpan.FromMilliseconds(Environment.TickCount64 - plii.dwTime);
			}
			else
			{
				throw new Win32Exception(Marshal.GetLastWin32Error());
			}
		}

		static DateTimeOffset GetLastInputTime()
		{
			return DateTimeOffset.Now.Subtract(GetInputIdleTime());
		}

		static class NativeMethods
		{
			public struct LastInputInfo
			{
				public UInt32 cbSize;
				public UInt32 dwTime;
			}

			[DllImport("user32.dll")]
			public static extern bool GetLastInputInfo(ref LastInputInfo plii);
		}

		#endregion

		#region screen saver

		const int SPI_GETSCREENSAVERRUNNING = 114;

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		static extern bool SystemParametersInfo(int uAction, int uParam, ref bool lpvParam, int flags);

		/// <summary>
		/// Returns TRUE if the screen saver is actually running
		/// </summary>
		/// <returns></returns>
		public bool GetScreenSaverRunning()
		{
			bool isRunning = false;
			SystemParametersInfo(SPI_GETSCREENSAVERRUNNING, 0, ref isRunning, 0);
			return isRunning;
		}

		#endregion
	}
	}