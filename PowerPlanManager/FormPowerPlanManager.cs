using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PowerPlanManager.PowerPlanManager;

namespace PowerPlanManager
{
	internal partial class FormPowerPlanManager : Form
	{

		SelfInstaller si;
		PowerPlanManager ppm;
		PowerModeManager pmm;
		IdleManager im;
		DataManager dm;

		internal FormPowerPlanManager(SelfInstaller si, PowerPlanManager ppm, PowerModeManager pmm, IdleManager im, DataManager dm)
		{
			this.si = si;
			this.ppm = ppm;
			this.pmm = pmm;
			this.im = im;
			this.dm = dm;

			this.ppm.PowerPlanAppliedEvent += DrawInvoke;
			this.pmm.PowerModeChangedEvent += DrawInvoke;

			InitializeComponent();

			Draw();
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			Debug.Log("closing form");
			this.ppm.PowerPlanAppliedEvent -= DrawInvoke;
			this.pmm.PowerModeChangedEvent -= DrawInvoke;
			base.OnClosing(e);
		}

		void DrawInvoke()
		{
			this.Invoke((MethodInvoker)delegate { Draw(); });
		}

		void Draw()
		{
			Debug.Log("drawing");

			// show current status
			switch (im.CurrentMode)
			{
				case PowerModes.idle:
					labelStatus.Text = "IDLE " + im.CurrentModeReason;
					pictureBoxStatus.Image = Resources.idle.ToBitmap();
					break;
				case PowerModes.balanced:
					labelStatus.Text = "BALANCED " + im.CurrentModeReason;
					pictureBoxStatus.Image = Resources.balanced.ToBitmap();
					break;
				case PowerModes.performance:
					labelStatus.Text = "PERFORMANCE " + im.CurrentModeReason;
					pictureBoxStatus.Image = Resources.performance.ToBitmap();
					break;
			}

			// show polling interval
			pollingInterval.Value = im.PollingInterval;

			// show autostart
			toggleAutoStart.Checked = si.IsAutostarting();

			// show screensaver
			toggleIdleOnScreensaver.Checked = im.IdleOnScreensaver;

			// show timeout
			toggleIdleOnTimeout.Checked = im.IdleOnTimeout;
			inputTimeout.Value = im.InputTimeout;
			displayTimeout.Value = ppm.DisplayTimeout;
			sleepTimeout.Value = ppm.SleepTimeout;
			hibernateTimeout.Value = ppm.HibernateTimeout;

			// show power modes
			labelCurrentPowerMode.Text = pmm.GetCurrentPowerModeName();
			
			DrawProcesses();
		}

		void DrawProcesses()
		{
			listBoxIdle.Items.Clear();
			listBoxIdle.Sorted = true;

			listBoxBalanced.Items.Clear();
			listBoxBalanced.Sorted = true;

			listBoxPerformance.Items.Clear();
			listBoxPerformance.Sorted = true;

			// get 8dle (running) processes
			System.Diagnostics.Process[] allProcesses = System.Diagnostics.Process.GetProcesses();
			foreach (System.Diagnostics.Process process in allProcesses)
			{
				// filter
				//if (!string.IsNullOrEmpty(textBoxSearchRunningProcesses.Text) && !process.ProcessName.Contains(textBoxSearchRunningProcesses.Text)) continue;

				// do not show already added processes
				if (im.BalancedProcessNames.Contains(process.ProcessName)) continue;
				if (im.PerformanceProcessNames.Contains(process.ProcessName)) continue;

				// add to list
				if (!listBoxIdle.Items.Contains(process.ProcessName))
				{
					listBoxIdle.Items.Add(process.ProcessName);
				}
			}

			// draw balanced processes
			foreach (var v in im.BalancedProcessNames)
			{
				listBoxBalanced.Items.Add(v);
			}

			// draw performance processes
			foreach (var v in im.PerformanceProcessNames)
			{
				listBoxPerformance.Items.Add(v);
			}
		}

		void buttonIdleToBalanced_Click(object sender, EventArgs e)
		{
			if (listBoxIdle.SelectedItem == null) return;

			// move idle to balanced
			im.AddBalancedProcess(listBoxIdle.SelectedItems.Cast<string>());

			DrawProcesses();
		}

		void buttonBalancedToIdle_Click(object sender, EventArgs e)
		{
			if (listBoxBalanced.SelectedItem == null) return;

			// move balanced to idle
			im.AddIdleProcess(listBoxBalanced.SelectedItems.Cast<string>());

			DrawProcesses();
		}

		void buttonBalancedToPerf_Click(object sender, EventArgs e)
		{
			if (listBoxBalanced.SelectedItem == null) return;

			// move balanced to perf
			im.AddPerformanceProcess(listBoxBalanced.SelectedItems.Cast<string>());

			DrawProcesses();
		}

		void buttonPerfToBalanced_Click(object sender, EventArgs e)
		{
			if (listBoxPerformance.SelectedItem == null) return;

			// move balanced to idle
			im.AddBalancedProcess(listBoxPerformance.SelectedItems.Cast<string>());

			DrawProcesses();
		}

		void buttonRefreshPrcesses_Click(object sender, EventArgs e)
		{
			Draw();
		}


		#region options

		void toggleAutoStart_CheckedChanged(object sender, EventArgs e)
		{
			si.SetAutoStart(toggleAutoStart.Checked);
		}

		void pollingInterval_ValueChanged(object sender, EventArgs e)
		{
			im.PollingInterval = (int)pollingInterval.Value;
		}

		void toggleIdleOnScreensaver_CheckedChanged(object sender, EventArgs e)
		{
			im.IdleOnScreensaver = toggleIdleOnScreensaver.Checked;
			Draw();
		}

		void toggleIdleOnTimeout_CheckedChanged(object sender, EventArgs e)
		{
			im.IdleOnTimeout = toggleIdleOnTimeout.Checked;
			Draw();
		}

		void inputTimeout_ValueChanged(object sender, EventArgs e)
		{
			im.InputTimeout = (int)inputTimeout.Value;
		}

		void displayTimeout_ValueChanged(object sender, EventArgs e)
		{
			ppm.DisplayTimeout = (uint)displayTimeout.Value;
		}

		void sleepTimeout_ValueChanged(object sender, EventArgs e)
		{
			ppm.SleepTimeout = (uint)sleepTimeout.Value;
		}

		void hibernateTimeout_ValueChanged(object sender, EventArgs e)
		{

		}

		#endregion

		#region power modes

		void buttonRefreshPowerModes_Click(object sender, EventArgs e)
		{
			Draw();
		}

		void button1_Click(object sender, EventArgs e)
		{
			pmm.ApplyBatterySaverPowerMode();
			Draw();
		}

		void button2_Click(object sender, EventArgs e)
		{
			pmm.ApplyBalancedPowerMode();
			Draw();
		}

		void buttonApplyPerformanceMode_Click(object sender, EventArgs e)
		{
			pmm.ApplyPerformancePowerMode();
			Draw();
		}

		void button3_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}




		#endregion

		void buttonResetForced_Click(object sender, EventArgs e)
		{
			im.ResetForced();
			Draw();
		}

		void buttonForceIdle_Click(object sender, EventArgs e)
		{
			im.ForceMode(PowerModes.idle);
			Draw();
		}

		void buttonForceBalanced_Click(object sender, EventArgs e)
		{
			im.ForceMode(PowerModes.balanced);
			Draw();
		}

		void buttonForcePerformance_Click(object sender, EventArgs e)
		{
			im.ForceMode(PowerModes.performance);
			Draw();
		}

		
	}
}
