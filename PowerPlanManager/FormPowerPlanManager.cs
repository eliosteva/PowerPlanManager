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

			InitializeComponent();

			Draw();
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			Debug.Log("closing form");
			this.ppm.PowerPlanChangedEvent -= DrawInvoke;
			base.OnClosing(e);
		}

		void DrawInvoke()
		{
			this.Invoke((MethodInvoker)delegate { Draw(); });
		}

		void Draw()
		{
			Debug.Log("drawing");

			// TODO draw enabled

			// show autostart
			toggleAutoStart.Checked = si.IsAutostarting();

			// show current power plan
			checkBoxUserPowerPlans.Checked = ppm.Enabled;
			labelCurrentPowerPlan.Text = ppm.currentPlan != null ? ppm.currentPlan.name : "ERROR";

			// show power plants in combos
			comboInUsePP.Items.Clear();
			comboIdlePP.Items.Clear();
			foreach (var v in ppm.availablePlans)
			{
				comboInUsePP.Items.Add(v.Value.name);
				comboIdlePP.Items.Add(v.Value.name);
			}
			if (ppm.defaultPlan != null) comboInUsePP.SelectedItem = ppm.defaultPlan.name;
			if (ppm.idlePlan != null) comboIdlePP.SelectedItem = ppm.idlePlan.name;

			// show screensaver
			toggleIdleOnScreensaver.Checked = im.IdleOnScreensaver;

			// show timeout
			toggleIdleOnTimeout.Checked = im.IdleOnTimeout;
			inputTimeout.Value = im.InputTimeout;

			// show processes
			toggleDisableWithProcesses.Checked = im.DisableWithProcesses;
			richTextBox1.Text = im.DisableProcesses;
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
		}

		private void toggleIdleOnTimeout_CheckedChanged(object sender, EventArgs e)
		{
			im.IdleOnTimeout = toggleIdleOnTimeout.Checked;
		}

		private void inputTimeout_ValueChanged(object sender, EventArgs e)
		{
			im.InputTimeout = (int)inputTimeout.Value;
		}

		private void toggleDisableWithProcesses_CheckedChanged(object sender, EventArgs e)
		{
			im.DisableWithProcesses = toggleDisableWithProcesses.Checked;
		}

		private void richTextBox1_TextChanged(object sender, EventArgs e)
		{
			im.DisableProcesses = richTextBox1.Text;
		}

		#endregion

		#region power plans

		private void checkBoxUserPowerPlans_CheckedChanged(object sender, EventArgs e)
		{
			ppm.Enabled = checkBoxUserPowerPlans.Checked;
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

		private void checkBoxUsePowerModes_CheckedChanged(object sender, EventArgs e)
		{
			pmm.Enabled = checkBoxUsePowerModes.Checked;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			pmm.ApplyIdlePowerPlan();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			pmm.ApplyDefaultPowerPlan();
		}

		#endregion





		//private void comboMode_SelectedIndexChanged(object sender, EventArgs e)
		//{
		//	string selected = (string)comboMode.SelectedItem;
		//	Debug.Log("idle mode selected: " + selected);

		//	// set mode
		//	im.mode = (IdleManager.Modes)Enum.Parse(typeof(IdleManager.Modes), selected);

		//	// save pref
		//	dm.SetPref("mode", selected);

		//	// show or hide timeout
		//	inputTimeout.Enabled = im.mode == IdleManager.Modes.timeout;
		//}


	}
}
