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
			labelStatus.Text = im.CurrentStatus == IdleManager.TargetStatus.use ? "IN USE" : "IDLE";
			pictureBoxStatus.Image = im.CurrentStatus == IdleManager.TargetStatus.use ? Resources.use.ToBitmap() : Resources.idle.ToBitmap();

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
			labelCurrentPowerPlan.Text = ppm.currentPlan != null ? ppm.currentPlan.name : "ERROR";
			comboInUsePP.Items.Clear();
			comboIdlePP.Items.Clear();
			foreach (var v in ppm.availablePlans)
			{
				comboInUsePP.Items.Add(v.Value.name);
				comboIdlePP.Items.Add(v.Value.name);
			}
			if (ppm.defaultPlan != null) comboInUsePP.SelectedItem = ppm.defaultPlan.name;
			if (ppm.idlePlan != null) comboIdlePP.SelectedItem = ppm.idlePlan.name;
			comboInUsePP.Enabled = checkBoxUserPowerPlans.Checked;
			comboIdlePP.Enabled = checkBoxUserPowerPlans.Checked;

			// show power modes
			labelCurrentPowerMode.Text = pmm.GetCurrentPowerModeName();
			checkBoxUsePowerModes.Checked = pmm.Enabled;

			// show processes
			toggleDisableWithProcesses.Checked = im.DisableWithProcesses;
			DrawProcesses();
		}

		void DrawProcesses()
		{
			listBoxRunningProcesses.Items.Clear();
			listBoxRunningProcesses.Sorted = true;

			// get running processes
			System.Diagnostics.Process[] allProcesses = System.Diagnostics.Process.GetProcesses();
			foreach (System.Diagnostics.Process process in allProcesses)
			{
				// filter
				if (!string.IsNullOrEmpty(textBoxSearchRunningProcesses.Text) && !process.ProcessName.Contains(textBoxSearchRunningProcesses.Text)) continue;

				// add to list
				listBoxRunningProcesses.Items.Add(process.ProcessName);
			}

			// draw disable processes
			listBoxDisableProcesses.Items.Clear();
			foreach(var v in im.BlockingProcessNames)
			{
				listBoxDisableProcesses.Items.Add(v);
			}
		}

		private void textBoxSearchRunningProcesses_TextChanged(object sender, EventArgs e)
		{
			DrawProcesses();
		}

		private void listBoxRunningProcesses_DoubleClick(object sender, EventArgs e)
		{
			// add selected to disable with running
			if (listBoxRunningProcesses.SelectedItem != null)
			{
				if (!im.BlockingProcessNames.Contains(listBoxRunningProcesses.SelectedItem.ToString()))
				{
					im.AddBlockingProcess(listBoxRunningProcesses.SelectedItem.ToString());
				}
			}
			DrawProcesses();
		}

		private void listBoxDisableProcesses_DoubleClick(object sender, EventArgs e)
		{
			// remove disable process
			if (listBoxDisableProcesses.SelectedItem != null)
			{
				if (im.BlockingProcessNames.Contains(listBoxDisableProcesses.SelectedItem.ToString()))
				{
					im.RemoveBlockingProcess(listBoxDisableProcesses.SelectedItem.ToString());
				}
			}
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

		private void toggleDisableWithProcesses_CheckedChanged(object sender, EventArgs e)
		{
			im.DisableWithProcesses = toggleDisableWithProcesses.Checked;
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
			Draw();
		}

		private void comboInUsePP_SelectedIndexChanged(object sender, EventArgs e)
		{
			string selected = (string)comboInUsePP.SelectedItem;
			Debug.Log("default power plan selected: " + selected);

			// set plan
			ppm.defaultPlan = ppm.GetPowerPlanFromName(selected);

			// save pref
			dm.SetPref("default", ppm.defaultPlan.name);
		}

		private void comboIdlePP_SelectedIndexChanged(object sender, EventArgs e)
		{
			string selected = (string)comboIdlePP.SelectedItem;
			Debug.Log("idle power plan selected: " + selected);

			// set plan
			ppm.idlePlan = ppm.GetPowerPlanFromName(selected);

			// save pref
			dm.SetPref("idle", ppm.idlePlan.name);
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
		}

		private void button1_Click(object sender, EventArgs e)
		{
			pmm.ApplyBatterySaverPowerPlan();
			Draw();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			pmm.ApplyBalancedPowerPlan();
			Draw();
		}

		private void buttonApplyPerformanceMode_Click(object sender, EventArgs e)
		{
			pmm.ApplyPerformancePowerPlan();
			Draw();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}







		#endregion

		
	}
}
