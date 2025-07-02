using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
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

		bool manualHibernation = true;
		public bool ManualHibernation
		{
			get
			{
				return manualHibernation;
			}
			set
			{
				if (value != manualHibernation)
				{
					manualHibernation = value;
					dm.SetPref("manualHibernation", value.ToString());
				}
			}
		}

		List<string> balancedProcessNames = new List<string>();
		List<string> performanceProcessNames = new List<string>();

		public IReadOnlyList<string> BalancedProcessNames => balancedProcessNames;
		public IReadOnlyList<string> PerformanceProcessNames => performanceProcessNames;

		public void AddIdleProcess(IEnumerable<string> names)
		{
			foreach (var v in names)
			{
				string name = v.Trim();
				if (string.IsNullOrEmpty(name)) return;

				// remove process from balanced and perf list
				if (balancedProcessNames.Contains(name))
				{
					balancedProcessNames.Remove(name);
				}
				if (performanceProcessNames.Contains(name))
				{
					performanceProcessNames.Remove(name);
				}
			}
			SaveProcessNames();
		}

		public void AddBalancedProcess(IEnumerable<string> names)
		{
			foreach(var v in names)
			{
				string name = v.Trim();
				if (string.IsNullOrEmpty(name)) return;

				// add process to balanced
				if (!balancedProcessNames.Contains(name))
				{
					balancedProcessNames.Add(name);
				}
				if (performanceProcessNames.Contains(name))
				{
					performanceProcessNames.Remove(name);
				}
			}
			SaveProcessNames();
		}

		public void AddPerformanceProcess(IEnumerable<string> names)
		{
			foreach (var v in names)
			{
				string name = v.Trim();
				if (string.IsNullOrEmpty(name)) return;

				// add process to performance
				if (balancedProcessNames.Contains(name))
				{
					balancedProcessNames.Remove(name);
				}
				if (!performanceProcessNames.Contains(name))
				{
					performanceProcessNames.Add(name);
				}
			}
			SaveProcessNames();
		}

		void SaveProcessNames()
		{
			{
				string s = "";
				foreach (var v in balancedProcessNames)
				{
					if (!string.IsNullOrEmpty(v))
					{
						s += v + "|";
					}
				}
				dm.SetPref("balancedProcessNames", s);
			}
			{
				string s = "";
				foreach (var v in performanceProcessNames)
				{
					if (!string.IsNullOrEmpty(v))
					{
						s += v + "|";
					}
				}
				dm.SetPref("performanceProcessNames", s);
			}
		}

		

		public enum Status
		{
			idle = 0,
			balanced = 1,
			performance = 2,
		}

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
			ManualHibernation = dm.GetPref("manualHibernation", manualHibernation);
			RebuildProcessList();
			
			// init background worker and start
			bw = new BackgroundWorker();
			bw.WorkerReportsProgress = false;
			bw.WorkerSupportsCancellation = false;
			bw.DoWork += new DoWorkEventHandler(Update);
			bw.RunWorkerAsync();

			// intercept exit event
			AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);

			lastHibernationTime = DateTime.Now;

			Poll();
		}

		bool close = false;

		void RebuildProcessList()
		{
			{
				string pref = dm.GetPref("balancedProcessNames", "");
				balancedProcessNames.Clear();
				if (!string.IsNullOrEmpty(pref))
				{
					string[] ss = pref.Split('\n', '|', ',');
					foreach (var s in ss)
					{
						if (!string.IsNullOrEmpty(s))
						{
							if (!balancedProcessNames.Contains(s))
							{
								balancedProcessNames.Add(s);
							}
						}
					}
				}
			}
			{ 
				string pref = dm.GetPref("performanceProcessNames", "");
				performanceProcessNames.Clear();
				if (!string.IsNullOrEmpty(pref))
				{
					string[] ss = pref.Split('\n', '|', ',');
					foreach (var s in ss)
					{
						if (!string.IsNullOrEmpty(s))
						{
							if (!performanceProcessNames.Contains(s))
							{
								performanceProcessNames.Add(s);
							}
						}
					}
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


		internal Action ModeAppliedEvent;

		internal Status CurrentMode => currentStatus;
		internal string CurrentModeReason => currentStatusReason;
		internal bool IsForced => forced;


		Status currentStatus = Status.balanced;
		string currentStatusReason = "";
		bool forced = false;
		DateTime lastHibernationTime;

		void Poll()
		{
			try
			{
				// check forced
				if (forced)
				{
#if DEBUG
					Debug.Log("[DEBUG] polling update: disabled due to forced status");
#endif
					return;
				}

				// check performance process
				if (performanceProcessNames != null && performanceProcessNames.Count > 0)
				{
					foreach(string name in performanceProcessNames)
					{
						if (IsProcessRunning(name))
						{
#if DEBUG
							Debug.Log("[DEBUG] polling update: Performance due to running process " + name);
#endif
							ApplyStatus(Status.performance, "process running (" + name +  ")");
							return;
						}
					}
				}

				// check balanced process
				if (balancedProcessNames != null && balancedProcessNames.Count > 0)
				{
					foreach (string name in balancedProcessNames)
					{
						if (IsProcessRunning(name))
						{
#if DEBUG
							Debug.Log("[DEBUG] polling update: Balanced due to running process " + name);
#endif
							ApplyStatus(Status.balanced, "process running (" + name + ")");
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
						if (currentStatus != Status.idle)
						{
#if DEBUG
							Debug.Log("[DEBUG] polling update: Idle due to user input timeout");
#endif
							ApplyStatus(Status.idle, "user input timeout");
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
						if (currentStatus != Status.idle)
						{
#if DEBUG
							Debug.Log("[DEBUG] polling update: Idle due to screen saver running");
#endif
							ApplyStatus(Status.idle, "screen saver running");
						}
						return;
					}
				}

				// if currently idle
				if (currentStatus == Status.idle)
				{
					if (ManualHibernation)
					{
						var idleTime = GetInputIdleTime();
						if (idleTime.TotalMinutes >= ppm.HibernateTimeout)
						{
							// minimum time between hibernations
                            if ((DateTime.Now - lastHibernationTime).TotalMinutes > ppm.HibernateTimeout)
							{
								// manually hibernate
								Debug.Log("polling update: Hibernation time elapsed, triggering manual hibernation");
								PowerPlansApiWrapper.SetSuspendState(true, true, true);
								return;
							}
						}
					}
				}

#if DEBUG
				Debug.Log("[DEBUG] polling update: Balanced due to user input detected");
#endif
				ApplyStatus(Status.balanced, "user input detected");
			}
			catch (Exception ex)
			{
				Debug.LogError(ex.ToString());
			}
		}

		void ApplyStatus(Status status, string reason)
		{
			if (currentStatus != status) Debug.Log("applying status: " + status);
			currentStatusReason = reason;
			currentStatus = status;
			ppm.ApplyPowerPlanForStatus(status);
			ModeAppliedEvent?.Invoke();
		}

		bool IsProcessRunning(string name)
		{
			Process[] pname = Process.GetProcessesByName(name);
			return pname.Length != 0;
		}

		internal void ForceStatus(Status status)
		{
			forced = true;
			ApplyStatus(status, "forced");
		}

		internal void ResetForced()
		{
			forced = false;
			Poll();
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