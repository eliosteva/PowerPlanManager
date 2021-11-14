using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PowerPlanManager
{
	internal class IdleManager
	{
		internal enum Modes
		{
			none,
			screenSaver,
			timeout,
		}

		DataManager dm;
		PowerPlanManager ppm;
		internal Modes mode = Modes.none;
		internal int timeout = 20;
		int pollingIntervalSec = 5;
		BackgroundWorker bw;

		internal IdleManager(DataManager dm, PowerPlanManager ppm)
		{
			this.dm = dm;
			this.ppm = ppm;

			Debug.Log("initializing idle manager");

			// load prefs
			InitializeIdleMode(dm.GetPref("mode"));
			InitializePollingInterval(dm.GetPref("interval"));
			int.TryParse(dm.GetPref("timeout"), out timeout);
			timeout = Math.Clamp(timeout, 5, 600);

			// init background worker and start
			bw = new BackgroundWorker();
			bw.WorkerReportsProgress = false;
			bw.WorkerSupportsCancellation = false;
			bw.DoWork += new DoWorkEventHandler(Update);
			bw.RunWorkerAsync();

			// intercept exit event
			AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
		}

		internal void InitializeIdleMode(string v)
		{
			if (!string.IsNullOrEmpty(v)) mode = (Modes)Enum.Parse(typeof(Modes), v);
		}

		internal void InitializePollingInterval(string v)
		{
			if (!string.IsNullOrEmpty(v)) pollingIntervalSec = int.Parse(v);
		}







		bool wasIdle = false;
		bool close = false;

		void Update(object sender, DoWorkEventArgs e)
		{
			Debug.Log("starting background worker");
			while (!close)
			{
				if (ppm == null) continue;
				if (ppm.currentPlan == null) continue;
				if (ppm.idlePlan == null) continue;
				if (ppm.defaultPlan == null) continue;

				switch (mode)
				{
					case Modes.none:
						break;

					case Modes.screenSaver:
						//Debug.Log("updating background worker...");
						if (GetScreenSaverRunning()) EnterIdle();
						else ExitIdle();
						break;

					case Modes.timeout:
						var idleTime = GetInputIdleTime();
						if (idleTime.TotalSeconds >= timeout) EnterIdle();
						else ExitIdle();
						break;
				}
				Thread.Sleep(pollingIntervalSec * 1000);
			}
			Debug.Log("background worker stopped");
		}

		void EnterIdle()
		{
			if (!wasIdle)
			{
				wasIdle = true;
				Debug.Log("entering idle");
				ppm.ApplyIdlePowerPlan();
			}
		}

		void ExitIdle()
		{
			if (wasIdle)
			{
				wasIdle = false;
				Debug.Log("exiting idle");
				ppm.ApplyDefaultPowerPlan();
			}
		}

		void OnProcessExit(object sender, EventArgs e)
		{
			Debug.Log("stopping background worker");
			close = true;
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
