using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

			this.ppm.PowerPlanChangedEvent += DrawInvoke;
			this.pmm.PowerModeChangedEvent += DrawInvoke;

			InitializeComponent();

			Draw();
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			Debug.Log("closing form");
			this.ppm.PowerPlanChangedEvent -= DrawInvoke;
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
			switch (im.CurrentStatus)
			{
				case IdleManager.TargetStatus.idle:
					labelStatus.Text = "IDLE";
					pictureBoxStatus.Image = Resources.idle.ToBitmap();
					break;
				case IdleManager.TargetStatus.balanced:
					labelStatus.Text = "BALANCED";
					pictureBoxStatus.Image = Resources.use.ToBitmap();
					break;
				case IdleManager.TargetStatus.performance:
					labelStatus.Text = "PERFORMANCE";
					pictureBoxStatus.Image = Resources.use.ToBitmap();
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

			// show power plans
			checkBoxUserPowerPlans.Checked = ppm.Enabled;
			labelCurrentPowerPlan.Text = ppm.CurrentPlan != null ? ppm.CurrentPlan.name : "ERROR";
			comboIdlePP.Items.Clear();
			comboBalancedPP.Items.Clear();
			comboPerfPP.Items.Clear();
			foreach (var v in ppm.AvailablePlans)
			{
				comboIdlePP.Items.Add(v.Value.name);
				comboBalancedPP.Items.Add(v.Value.name);
				comboPerfPP.Items.Add(v.Value.name);
			}
			if (ppm.StatusPlans.TryGetValue(IdleManager.TargetStatus.idle, out var ppIdle) && ppIdle != null) comboIdlePP.SelectedItem = ppIdle.name;
			if (ppm.StatusPlans.TryGetValue(IdleManager.TargetStatus.balanced, out var ppBalanced) && ppBalanced != null) comboBalancedPP.SelectedItem = ppBalanced.name;
			if (ppm.StatusPlans.TryGetValue(IdleManager.TargetStatus.performance, out var ppPerf) && ppPerf != null) comboPerfPP.SelectedItem = ppPerf.name;

			comboIdlePP.Enabled = checkBoxUserPowerPlans.Checked;
			comboBalancedPP.Enabled = checkBoxUserPowerPlans.Checked;
			comboPerfPP.Enabled = checkBoxUserPowerPlans.Checked;

			// show power modes
			labelCurrentPowerMode.Text = pmm.GetCurrentPowerModeName();
			checkBoxUsePowerModes.Checked = pmm.Enabled;

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
			foreach(var v in im.BalancedProcessNames)
			{
				listBoxBalanced.Items.Add(v);
			}

			// draw performance processes
			foreach(var v in im.PerformanceProcessNames)
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




		#region polling

		private void toggleAutoStart_CheckedChanged(object sender, EventArgs e)
		{
			si.SetAutoStart(toggleAutoStart.Checked);
		}

		private void pollingInterval_ValueChanged(object sender, EventArgs e)
		{
			im.PollingInterval = (int)pollingInterval.Value;
		}

		private void toggleIdleOnScreensaver_CheckedChanged(object sender, EventArgs e)
		{
			im.IdleOnScreensaver = toggleIdleOnScreensaver.Checked;
			Draw();
		}

		private void toggleIdleOnTimeout_CheckedChanged(object sender, EventArgs e)
		{
			im.IdleOnTimeout = toggleIdleOnTimeout.Checked;
			Draw();
		}

		private void inputTimeout_ValueChanged(object sender, EventArgs e)
		{
			im.InputTimeout = (int)inputTimeout.Value;
		}

		#endregion

		#region power plans

		private void buttonRefreshPowerPlans_Click(object sender, EventArgs e)
		{
			ppm.Refresh();
			Draw();
		}

		private void checkBoxUserPowerPlans_CheckedChanged(object sender, EventArgs e)
		{
			ppm.Enabled = checkBoxUserPowerPlans.Checked;
			pmm.Enabled = !ppm.Enabled;
			Draw();
		}

		private void comboIdlePP_SelectedIndexChanged(object sender, EventArgs e)
		{
			string selected = (string)comboIdlePP.SelectedItem;

			// associate PowerPlan with status
			ppm.AssociatePowerPlanWithStatus(selected, IdleManager.TargetStatus.idle);
		}

		private void comboBalancedPP_SelectedIndexChanged(object sender, EventArgs e)
		{
			string selected = (string)comboBalancedPP.SelectedItem;

			// associate PowerPlan with status
			ppm.AssociatePowerPlanWithStatus(selected, IdleManager.TargetStatus.balanced);
		}

		private void comboPerfPP_SelectedIndexChanged(object sender, EventArgs e)
		{
			string selected = (string)comboPerfPP.SelectedItem;
			
			// associate PowerPlan with status
			ppm.AssociatePowerPlanWithStatus(selected, IdleManager.TargetStatus.performance);
		}

		#endregion

		#region power modes

		private void buttonRefreshPowerModes_Click(object sender, EventArgs e)
		{
			Draw();
		}

		private void checkBoxUsePowerModes_CheckedChanged(object sender, EventArgs e)
		{
			pmm.Enabled = checkBoxUsePowerModes.Checked;
			ppm.Enabled = !pmm.Enabled;
			Draw();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			pmm.ApplyBatterySaverPowerMode();
			Draw();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			pmm.ApplyBalancedPowerMode();
			Draw();
		}

		private void buttonApplyPerformanceMode_Click(object sender, EventArgs e)
		{
			pmm.ApplyPerformancePowerMode();
			Draw();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}



		#endregion
	}
}
