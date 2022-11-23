using System;
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

		string disableProcesses = ""; // "Netflix\ndevenv\nUnity"; //WWAHost?
		public string DisableProcesses
		{
			get
			{
				return disableProcesses;
			}
			set
			{
				value = value.Replace('\n', '|');
				value = value.Replace(',', '|');
				if (value != disableProcesses)
				{
					disableProcesses = value;
					dm.SetPref("disableProcesses", value.ToString());
					RebuildProcessList();
				}
			}
		}

		public Action EnteredIdleEvent;
		public Action ExitedIdleEvent;


		BackgroundWorker bw;
		DataManager dm;
		PowerPlanManager ppm;
		PowerModeManager pmm;

		internal IdleManager(DataManager dm, PowerPlanManager ppm, PowerModeManager pmm)
		{
			this.dm = dm;
			this.ppm = ppm;
			this.pmm = pmm;

			Debug.Log("initializing idle manager");

			// load prefs
			IdleOnScreensaver = dm.GetPref("idleOnScreensaver", idleOnScreensaver);
			IdleOnTimeout = dm.GetPref("idleOnTimeout", idleOnTimeout);
			InputTimeout = dm.GetPref("inputTimeout", inputTimeout);
			PollingInterval = dm.GetPref("pollingInterval", pollingInterval);
			DisableWithProcesses = dm.GetPref("disableWithProcesses", disableWithProcesses);
			DisableProcesses = dm.GetPref("disableProcesses", disableProcesses);
			RebuildProcessList();

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
			if (!string.IsNullOrEmpty(DisableProcesses))
			{
				string[] ss = disableProcesses.Split('\n', '|', ',');
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
					System.Diagnostics.Process[] allProcesses = System.Diagnostics.Process.GetProcesses();
					foreach (System.Diagnostics.Process process in allProcesses)
					{
						foreach (string blockingName in blockingProcessNames)
						{
							if ((process.ProcessName.ToLowerInvariant().Contains(blockingName.ToLowerInvariant())))
							{
								Debug.Log("exiting due to process running: " + blockingName);
								ExitIdle();
								return;
							}
						}
					}

					//foreach (string name in blockingProcessNames)
					//{
					//	// if process is running
					//	Process[] pname = Process.GetProcessesByName(name);
					//	if (pname.Length != 0)
					//	{
					//		// exit idle
					//		if (currentStatus == TargetStatus.idle)
					//		{
					//			Debug.Log("exiting due to process running: " + name);
					//			ExitIdle();
					//		}
					//		return;
					//	}
					//}
				}

				// check timeout
				if (idleOnTimeout)
				{
					var idleTime = GetInputIdleTime();
					if (idleTime.TotalSeconds >= inputTimeout)
					{
						// enter idle
						if (currentStatus == TargetStatus.use)
						{
							Debug.Log("entering idle due to user input timeout");
							EnterIdle();
						}
						return;
					}
				}

				// check screensaver
				if (idleOnScreensaver)
				{
					if (GetScreenSaverRunning())
					{
						// enter idle
						if (currentStatus == TargetStatus.use)
						{
							Debug.Log("entering idle due to screen saver running");
							EnterIdle();
						}
						return;
					}
				}

				if (currentStatus == TargetStatus.idle)
				{
					Debug.Log("exiting idle due to user input");
					ExitIdle();
				}
			}
			catch (Exception ex)
			{
				Debug.LogError(ex.ToString());
			}
		}

		bool EnterIdle()
		{
			if (currentStatus != TargetStatus.use)
			{
				Debug.LogError("cannot enter idle: already in idle");
				return false;
			}

			currentStatus = TargetStatus.idle;
			Debug.Log("entering idle");
			ppm.ApplyIdlePowerPlan();
			pmm.ApplyIdlePowerPlan();
			EnteredIdleEvent?.Invoke();
			return true;
		}

		bool ExitIdle()
		{
			if (currentStatus != TargetStatus.idle)
			{
				Debug.LogError("cannot exit idle: already exited");
				return false;
			}

			currentStatus = TargetStatus.use;
			ppm.ApplyDefaultPowerPlan();
			pmm.ApplyDefaultPowerPlan();
			ExitedIdleEvent?.Invoke();
			return true;
		}

		#region idle timer

		static TimeSpan GetInputIdleTime()
		{
			NativeMethods.LastInputInfo plii = new NativeMethods.LastInputInfo();
			plii.cbSize = (UInt32)Marshal.SizeOf(plii);

			if (NativeMethods.GetLastInputInfo(ref plii))
			{
				//return TimeSpan.FromMilliseconds(Environment.TickCount64 - plii.dwTime);
				return TimeSpan.FromMilliseconds(Environment.TickCount - plii.dwTime);
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