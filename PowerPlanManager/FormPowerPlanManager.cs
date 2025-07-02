using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PowerPlanManager.IdleManager;

namespace PowerPlanManager
{
	internal partial class FormPowerPlanManager : Form
	{

		SelfInstaller si;
		PowerPlanManager ppm;
		PowerModeManager pmm;
		IdleManager im;
		DataManager dm;
		bool ignoreEvents = false;

		internal FormPowerPlanManager(SelfInstaller si, PowerPlanManager ppm, PowerModeManager pmm, IdleManager im, DataManager dm)
		{
			this.si = si;
			this.ppm = ppm;
			this.pmm = pmm;
			this.im = im;
			this.dm = dm;

			//this.ppm.PowerPlanAppliedEvent += DrawInvoke;
			//this.pmm.PowerModeAppliedEvent += DrawInvoke;
			im.ModeAppliedEvent += OnIdleModeAppliedEvent;
			//im.ModeReasonChangedEvent += DrawInvoke;

			InitializeComponent();

			Draw();
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			Debug.Log("closing form");
			//this.ppm.PowerPlanAppliedEvent -= DrawInvoke;
			//this.pmm.PowerModeAppliedEvent -= DrawInvoke;
			im.ModeAppliedEvent -= OnIdleModeAppliedEvent;
			base.OnClosing(e);
		}

		void OnIdleModeAppliedEvent()
		{
			this.Invoke((MethodInvoker)delegate { DrawCurrentMode(); });
		}

		void Draw()
		{
			//Debug.Log("drawing");

			DrawPowerPlans();

			DrawCurrentMode();

			DrawProcesses();

			// show options
			pollingInterval.Value = im.PollingInterval;
			toggleAutoStart.Checked = si.IsAutoStartEnabled();
			toggleIdleOnScreensaver.Checked = im.IdleOnScreensaver;
			toggleIdleOnTimeout.Checked = im.IdleOnTimeout;
			inputTimeout.Value = im.InputTimeout;
			displayTimeout.Value = ppm.DisplayTimeout;
			sleepTimeout.Value = ppm.SleepTimeout;
			hibernateTimeout.Value = ppm.HibernateTimeout;
			rbModePowerSaver.Checked = pmm.IsCurrentModePowerSaver;
			rbModeBalanced.Checked = pmm.IsCurrentModeBalanced;
			rbModePerformance.Checked = pmm.IsCurrentModePerformance;
		}

		void DrawPowerPlans()
		{
			string[] plansNames = ppm.GetAllPowerPlansNames().ToArray();

			void DisplaySelectedPowerPlanInComboForMode(ComboBox cmb, Status mode)
			{
				ignoreEvents = true;
				{
					// get selected pp name
					var ppName = ppm.GetSelectedPowerPlanNameForStatus(mode);
					cmb.Items.Clear();
					cmb.Items.AddRange(plansNames);
					cmb.SelectedItem = null;

					if (!string.IsNullOrEmpty(ppName))
					{
						cmb.SelectedIndex = cmb.Items.IndexOf(ppName);
					}
				}
				ignoreEvents = false;
			}

			DisplaySelectedPowerPlanInComboForMode(cmbPowerPlanIdle, Status.idle);
			DisplaySelectedPowerPlanInComboForMode(cmbPowerPlanBalanced, Status.balanced);
			DisplaySelectedPowerPlanInComboForMode(cmbPowerPlanPerformance, Status.performance);

			buttonResetForced.Enabled = im.IsForced;
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

		void DrawCurrentMode()
		{
			// show current power mode
			//labelCurrentPowerMode.Text = pmm.GetCurrentPowerModeName();

			// show current status
			if (!pmm.IsCurrentModeBalanced)
			{
				labelStatus.Text = "NOT WORKING due to PowerMode not Balanced (PowerPlans are applied by Windows only with balanced PowerMode)";
				pictureBoxStatus.Image = Resources.idle.ToBitmap();
			}
			else
			{
				switch (im.CurrentMode)
				{
					case Status.idle:
						labelStatus.Text = ppm.GetSelectedPowerPlanNameForStatus(im.CurrentMode) + " due to " + im.CurrentModeReason;
						pictureBoxStatus.Image = Resources.idle.ToBitmap();
						break;
					case Status.balanced:
						labelStatus.Text = ppm.GetSelectedPowerPlanNameForStatus(im.CurrentMode) + " due to " + im.CurrentModeReason;
						pictureBoxStatus.Image = Resources.balanced.ToBitmap();
						break;
					case Status.performance:
						labelStatus.Text = ppm.GetSelectedPowerPlanNameForStatus(im.CurrentMode) + " due to " + im.CurrentModeReason;
						pictureBoxStatus.Image = Resources.performance.ToBitmap();
						break;
				}
			}
		}

		void buttonIdleToBalanced_Click(object sender, EventArgs e)
		{
			if (listBoxIdle.SelectedItems == null) return;

			// move idle to balanced
			im.AddBalancedProcess(listBoxIdle.SelectedItems.Cast<string>());

			DrawProcesses();
		}

		void buttonBalancedToIdle_Click(object sender, EventArgs e)
		{
			if (listBoxBalanced.SelectedItems == null) return;

			// move balanced to idle
			im.AddIdleProcess(listBoxBalanced.SelectedItems.Cast<string>());

			DrawProcesses();
		}

		void buttonBalancedToPerf_Click(object sender, EventArgs e)
		{
			if (listBoxBalanced.SelectedItems == null) return;

			// move balanced to perf
			im.AddPerformanceProcess(listBoxBalanced.SelectedItems.Cast<string>());

			DrawProcesses();
		}

		void buttonPerfToBalanced_Click(object sender, EventArgs e)
		{
			if (listBoxPerformance.SelectedItems == null) return;

			// move balanced to idle
			im.AddBalancedProcess(listBoxPerformance.SelectedItems.Cast<string>());

			DrawProcesses();
		}

		void buttonRefreshPrcesses_Click(object sender, EventArgs e)
		{
			Draw();
		}

		void cmbPowerPlanIdle_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ignoreEvents) return;

			Status mode = Status.idle;
			string selection = cmbPowerPlanIdle.SelectedItem.ToString();
			Debug.Log("power plan named " + selection + " selected for mode " + mode);
			ppm.SelectPowerPlanForStatus(selection, mode);
		}

		void cmbPowerPlanBalanced_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ignoreEvents) return;

			Status mode = Status.balanced;
			string selection = cmbPowerPlanBalanced.SelectedItem.ToString();
			Debug.Log("power plan named " + selection + " selected for mode " + mode);
			ppm.SelectPowerPlanForStatus(selection, mode);
		}

		void cmbPowerPlanPerformance_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ignoreEvents) return;

			Status mode = Status.performance;
			string selection = cmbPowerPlanPerformance.SelectedItem.ToString();
			Debug.Log("power plan named " + selection + " selected for mode " + mode);
			ppm.SelectPowerPlanForStatus(selection, mode);
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

		void toggleManualHibernate_CheckedChanged(object sender, EventArgs e)
		{
			im.ManualHibernation = toggleManualHibernate.Checked;
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
			ppm.HibernateTimeout = (uint)hibernateTimeout.Value;
		}

		#endregion

		#region power modes

		void buttonRefreshPowerModes_Click(object sender, EventArgs e)
		{
			Draw();
		}

		void rbModePowerSaver_Click(object sender, EventArgs e)
		{
			pmm.ApplyBatterySaverPowerMode();
			Draw();
		}

		void rbModeBalanced_Click(object sender, EventArgs e)
		{
			pmm.ApplyBalancedPowerMode();
			Draw();
		}

		void rbModePerformance_Click(object sender, EventArgs e)
		{
			pmm.ApplyPerformancePowerMode();
			Draw();
		}

		#endregion

		void buttonResetForced_Click(object sender, EventArgs e)
		{
			im.ResetForced();
			Draw();
		}

		void buttonForceIdle_Click(object sender, EventArgs e)
		{
			im.ForceStatus(Status.idle);
			Draw();
		}

		void buttonForceBalanced_Click(object sender, EventArgs e)
		{
			im.ForceStatus(Status.balanced);
			Draw();
		}

		void buttonForcePerformance_Click(object sender, EventArgs e)
		{
			im.ForceStatus(Status.performance);
			Draw();
		}

		void buttonReloadPlans_Click(object sender, EventArgs e)
		{
			ppm.ReadPowerPlans();
		}

		void buttonQuit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}