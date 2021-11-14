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
		IdleManager im;
		DataManager dm;

		internal FormPowerPlanManager(SelfInstaller si, PowerPlanManager ppm, IdleManager im, DataManager dm)
		{
			this.si = si;
			this.ppm = ppm;
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

			// show power plants in combos
			comboDefault.Items.Clear();
			comboIdle.Items.Clear();
			foreach (var v in ppm.availablePlans)
			{
				comboDefault.Items.Add(v.Value.name);
				comboIdle.Items.Add(v.Value.name);
			}

			// select current values
			if (ppm.defaultPlan != null) comboDefault.SelectedItem = ppm.defaultPlan.name;
			if (ppm.idlePlan != null) comboIdle.SelectedItem = ppm.idlePlan.name;

			// show current label
			labelCurrentPowerPlan.Text = ppm.currentPlan != null ? ppm.currentPlan.name : "ERROR";

			// show modes
			comboMode.Items.Clear();
			foreach(var v in Enum.GetValues(typeof(IdleManager.Modes)))
			{
				comboMode.Items.Add(v.ToString());
			}
			comboMode.SelectedItem = im.mode.ToString();

			// show timeout
			numericUpDown.Value = im.timeout;

			// show autostart
			checkBoxAutoStart.Checked = si.IsAutostarting();
		}

		private void cbPowerPlan_default_SelectedIndexChanged(object sender, EventArgs e)
		{
			string selected = (string)comboDefault.SelectedItem;
			Debug.Log("default power plan selected: " + selected);
			
			// set plan
			ppm.defaultPlan = ppm.GetPowerPlanFromName(selected);
			
			// save pref
			dm.SetPref("default", ppm.defaultPlan.name);
		}

		private void cbPowerPlan_idle_SelectedIndexChanged(object sender, EventArgs e)
		{
			string selected = (string)comboIdle.SelectedItem;
			Debug.Log("idle power plan selected: " + selected);

			// set plan
			ppm.idlePlan = ppm.GetPowerPlanFromName(selected);

			// save pref
			dm.SetPref("idle", ppm.idlePlan.name);
		}

		private void comboMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			string selected = (string)comboMode.SelectedItem;
			Debug.Log("idle mode selected: " + selected);

			// set mode
			im.mode = (IdleManager.Modes)Enum.Parse(typeof(IdleManager.Modes), selected);

			// save pref
			dm.SetPref("mode", selected);

			// show or hide timeout
			numericUpDown.Enabled = im.mode == IdleManager.Modes.timeout;
		}

		private void numericUpDown_ValueChanged(object sender, EventArgs e)
		{
			int selected = (int)numericUpDown.Value;
			Debug.Log("timeout selected: " + selected);

			// set mode
			im.timeout = selected;

			// save pref
			dm.SetPref("timeout", selected.ToString());
		}

		private void checkBoxAutoStart_CheckedChanged(object sender, EventArgs e)
		{
			si.SetAutoStart(checkBoxAutoStart.Checked);
		}

		private void buttonShowLog_Click(object sender, EventArgs e)
		{
			Debug.ShowLog();
		}
	}
}
