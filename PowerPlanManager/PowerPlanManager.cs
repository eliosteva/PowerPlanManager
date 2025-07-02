using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.ComponentModel;
using static PowerPlanManager.IdleManager;
using System.IO.Pipes;


namespace PowerPlanManager
{

	internal class PowerPlanManager
	{
		enum ProcessorBoostModes
		{
			disabled = 0, // off (good for cool device)
			enabled = 1, // boost clock step by step (good for lowering temp spike frequency) 
			aggressive = 2, // boost clock to upper limitt directly (good for benchmarks/maximizing frames)
			efficient = 3, // lower clock(turns off boost) faster after usage
			efficientAggressive = 4, // Always select the highest possible target frequency above nominal frequency if hardware supports doing so efficiently.
			aggressiveAtGuaranteed = 5, // Always select the highest possible target frequency above guaranteed frequency.
			efficientAggressiveAtGuaranteed = 6, // Always select the highest possible target frequency above guaranteed frequency if hardware supports doing so efficiently.
		}

		class ManagedPowerPlan
		{
			public Guid guid;
			public string name;

			internal ManagedPowerPlan(Guid guid, string name)
			{
				this.guid = guid;
				this.name = name;
			}

			public override string ToString()
			{
				return name + "(" + guid + ")";
			}
		}

		#region properties

		internal uint DisplayTimeout
		{
			get => displayTimeout;
			set 
			{
				if (value != displayTimeout)
				{
					if (value < 0) value = 0;
					displayTimeout = value;
					dm.SetPref("displayTimeout", value.ToString());
					Refresh();
				}
			}
		}

		internal uint SleepTimeout
		{
			get => sleepTimeout;
			set
			{
				if (value != sleepTimeout)
				{
					if (value < 0) value = 0;
					sleepTimeout = value;
					dm.SetPref("sleepTimeout", value.ToString());
					Refresh();
				}
			}
		}

		internal uint HibernateTimeout
		{
			get => hibernateTimeout;
			set
			{
				if (value != hibernateTimeout)
				{
					if (value < 0) value = 0;
					hibernateTimeout = value;
					dm.SetPref("hibernateTimeout", value.ToString());
					Refresh();
				}
			}
		}

		#endregion

		#region fields

		//Balanced: 381b4222-f694-41f0-9685-ff5bb260df2e
		//High performance: 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c
		//Power saver: a1841308-3541-4fab-bc81-f71556f20b4a
		const string PowerPlanGuid_Balanced = "381b4222-f694-41f0-9685-ff5bb260df2e";
		const string PowerPlanName_Balanced = "Balanced";
		const string PowerPlanName_PPM_PowerSaver = "PPM_PowerSaver";
		const string PowerPlanName_PPM_Balanced = "PPM_Balanced";
		const string PowerPlanName_PPM_Performance = "PPM_Performance";

		DataManager dm;
		ManagedPowerPlan defaultPlanBalanced = null;
		ManagedPowerPlan managedPlanPowerSaver = null;
		ManagedPowerPlan managedPlanBalanced = null;
		ManagedPowerPlan managedPlanPerformance = null;
		Dictionary<string, ManagedPowerPlan> otherPlans = new Dictionary<string, ManagedPowerPlan>();

		ManagedPowerPlan selectedPlanPowerSaver = null;
		ManagedPowerPlan selectedPlanBalanced = null;
		ManagedPowerPlan selectedPlanPerformance = null;

		uint displayTimeout = 15;
		uint sleepTimeout = 60;
		uint hibernateTimeout = 60;

		#endregion

		internal PowerPlanManager(DataManager dm)
		{
			this.dm = dm;
			Debug.Log("initializing power plan manager");

			//enabled = dm.GetPref<bool>("ppm_enabled", enabled);
			displayTimeout = dm.GetPref("displayTimeout", displayTimeout);
			sleepTimeout = dm.GetPref("sleepTimeout", sleepTimeout);
			hibernateTimeout = dm.GetPref("hibernateTimeout", hibernateTimeout);


			Refresh();

			// restore selected power plans
			SelectPowerPlanForMode(dm.GetPref("selectedPowerPlanPowerSaver", PowerPlanName_PPM_PowerSaver), Mode.idle);
			SelectPowerPlanForMode(dm.GetPref("selectedPowerPlanBalanced", PowerPlanName_PPM_Balanced), Mode.balanced);
			SelectPowerPlanForMode(dm.GetPref("selectedPowerPlanPerformance", PowerPlanName_PPM_Performance), Mode.performance);
		}

		internal void Refresh()
		{
			void SetOrAddPowerPlan(ref ManagedPowerPlan reference, Guid guid, string name)
			{
				if (reference == null) reference = new ManagedPowerPlan(guid, name);
				else
				{
					reference.guid = guid;
				}
			}

			void ApplyPowerPlanSettings(ManagedPowerPlan pp, ProcessorBoostModes boostMode, uint screenTimeout, uint sleepTimeout, uint hibernateTimeout, uint maxProcThrottle)
			{
				// apply ProcessorBoostModes
				PowerPlanWrapper.SetPlanSetting(pp.guid, SettingSubgroup.PROCESSOR_SETTINGS_SUBGROUP, Setting.PERFBOOSTMODE, PowerMode.DC, 0);
				PowerPlanWrapper.SetPlanSetting(pp.guid, SettingSubgroup.PROCESSOR_SETTINGS_SUBGROUP, Setting.PERFBOOSTMODE, PowerMode.AC, (uint)(int)boostMode);

				PowerPlanWrapper.SetPlanSetting(pp.guid, SettingSubgroup.VIDEO_SUBGROUP, Setting.VIDEOIDLE, PowerMode.DC, 60);
				PowerPlanWrapper.SetPlanSetting(pp.guid, SettingSubgroup.VIDEO_SUBGROUP, Setting.VIDEOIDLE, PowerMode.AC, screenTimeout * 60);

				PowerPlanWrapper.SetPlanSetting(pp.guid, SettingSubgroup.SLEEP_SUBGROUP, Setting.STANDBYIDLE, PowerMode.DC, 60);
				PowerPlanWrapper.SetPlanSetting(pp.guid, SettingSubgroup.SLEEP_SUBGROUP, Setting.STANDBYIDLE, PowerMode.AC, sleepTimeout * 60);

				PowerPlanWrapper.SetPlanSetting(pp.guid, SettingSubgroup.SLEEP_SUBGROUP, Setting.HIBERNATEIDLE, PowerMode.DC, 60);
				PowerPlanWrapper.SetPlanSetting(pp.guid, SettingSubgroup.SLEEP_SUBGROUP, Setting.HIBERNATEIDLE, PowerMode.AC, hibernateTimeout * 60);

				PowerPlanWrapper.SetPlanSetting(pp.guid, SettingSubgroup.PROCESSOR_SETTINGS_SUBGROUP, Setting.PROCTHROTTLEMIN, PowerMode.DC, 5);
				PowerPlanWrapper.SetPlanSetting(pp.guid, SettingSubgroup.PROCESSOR_SETTINGS_SUBGROUP, Setting.PROCTHROTTLEMIN, PowerMode.AC, 5);

				PowerPlanWrapper.SetPlanSetting(pp.guid, SettingSubgroup.PROCESSOR_SETTINGS_SUBGROUP, Setting.PROCTHROTTLEMAX, PowerMode.DC, 50);
				PowerPlanWrapper.SetPlanSetting(pp.guid, SettingSubgroup.PROCESSOR_SETTINGS_SUBGROUP, Setting.PROCTHROTTLEMAX, PowerMode.AC, maxProcThrottle);
			}

			List<Guid> plans = PowerPlanWrapper.ListPlans();
			foreach(var plan in plans)
			{
				string name = PowerPlanWrapper.GetPlanName(plan);

				// match or create power plans with ManagedPowerPlan
				if (defaultPlanBalanced == null && plan.Equals(PowerPlanGuid_Balanced)) SetOrAddPowerPlan(ref defaultPlanBalanced, plan, PowerPlanName_Balanced);
				if (defaultPlanBalanced == null && name.Equals(PowerPlanName_Balanced)) SetOrAddPowerPlan(ref defaultPlanBalanced, plan, PowerPlanName_Balanced);

				if (managedPlanPowerSaver == null && name.Equals(PowerPlanName_PPM_PowerSaver)) SetOrAddPowerPlan(ref managedPlanPowerSaver, plan, PowerPlanName_PPM_PowerSaver);
				if (managedPlanBalanced == null && name.Equals(PowerPlanName_PPM_Balanced)) SetOrAddPowerPlan(ref managedPlanBalanced, plan, PowerPlanName_PPM_Balanced);
				if (managedPlanPerformance == null && name.Equals(PowerPlanName_PPM_Performance)) SetOrAddPowerPlan(ref managedPlanPerformance, plan, PowerPlanName_PPM_Performance);

				else
				{
					if (!otherPlans.ContainsKey(name))
					{
						ManagedPowerPlan otherPlan = null;
						SetOrAddPowerPlan(ref otherPlan, plan, name);
						otherPlans.Add(name, otherPlan);
					}
				}
			}

			// apply default settings to managed plans if they exists
			if (managedPlanPowerSaver != null) ApplyPowerPlanSettings(managedPlanPowerSaver, ProcessorBoostModes.disabled, displayTimeout, sleepTimeout, hibernateTimeout, 50);
			if (managedPlanBalanced != null) ApplyPowerPlanSettings(managedPlanBalanced, ProcessorBoostModes.disabled, displayTimeout, 0, 0, 100);
			if (managedPlanPerformance != null) ApplyPowerPlanSettings(managedPlanPerformance, ProcessorBoostModes.enabled, 0, 0, 0, 100);
		}

		internal bool HasManagedPlansInstalled()
		{
			Refresh();

			return managedPlanPowerSaver != null && managedPlanBalanced != null && managedPlanPerformance != null;
		}

		internal bool AskToInstallCustomPlans()
		{
			Debug.Log("asking to install");
			dm.SetPref("askedToInstall", true.ToString());
			DialogResult dr = MessageBox.Show("Managed PowerPlans not installed. Install?", "", MessageBoxButtons.YesNo);
			if (dr == System.Windows.Forms.DialogResult.Yes)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		internal bool AskedToInstallManagedPlans()
		{
			return dm.GetPref("askedToInstall") == true.ToString();
		}

		internal void InstallManagedPlans()
		{
			// must have balanced power plan
			Refresh();
			if (defaultPlanBalanced == null)
			{
				MessageBox.Show("Cannot install managed PowerPlans, default Balanced PowerPlan not found", "");
				return;
			}

			Debug.Log("installing managed PowerPlans");
			IntPtr RetrPointer = IntPtr.Zero;

			// duplicate managed plans from default balanced
			if (managedPlanPowerSaver == null) DuplicatePowerPlan(defaultPlanBalanced, PowerPlanName_PPM_PowerSaver);
			if (managedPlanBalanced == null) DuplicatePowerPlan(defaultPlanBalanced, PowerPlanName_PPM_Balanced);
			if (managedPlanPerformance == null) DuplicatePowerPlan(defaultPlanBalanced, PowerPlanName_PPM_Performance);

			// refresh (and apply settings to managed plans)
			Refresh();

			// select managed plans
			Debug.Log("selecting managed PowerPlans");
			selectedPlanPowerSaver = managedPlanPowerSaver;
			selectedPlanBalanced = managedPlanBalanced;
			selectedPlanPerformance = managedPlanPerformance;
		}

		internal void UninstallManagedPlans()
		{
			if (managedPlanPowerSaver != null) PowerPlanWrapper.DeletePlan(managedPlanPowerSaver.guid);
			if (managedPlanBalanced != null) PowerPlanWrapper.DeletePlan(managedPlanBalanced.guid);
			if (managedPlanPerformance != null) PowerPlanWrapper.DeletePlan(managedPlanPerformance.guid);
		}


		internal void ApplyPowerMode(Mode mode)
		{
			Debug.Log("applying power mode " + mode);
			switch (mode)
			{
				case Mode.idle: ApplyPowerPlan(selectedPlanPowerSaver); break;
				case Mode.balanced: ApplyPowerPlan(selectedPlanBalanced); break;
				case Mode.performance: ApplyPowerPlan(selectedPlanPerformance); break;
			}
		}

		internal List<string> GetAllPowerPlansNames()
		{
			List<string> names = new List<string>();

			void Add(ManagedPowerPlan managedPowerPlan)
			{
				if (managedPowerPlan != null && !names.Contains(managedPowerPlan.name)) names.Add(managedPowerPlan.name);
			}

			Add(defaultPlanBalanced);
			Add(managedPlanPowerSaver);
			Add(managedPlanBalanced);
			Add(managedPlanPerformance);
			foreach(var v in otherPlans)
			{
				Add(v.Value);
			}

			return names;
		}

		internal string GetSelectedPowerPlanNameForMode(Mode mode)
		{
			switch (mode)
			{
				case Mode.idle: return selectedPlanPowerSaver?.name;
				case Mode.balanced: return selectedPlanBalanced?.name;
				case Mode.performance: return selectedPlanPerformance?.name;
				default: throw new Exception();
			}
		}

		internal void SelectPowerPlanForMode(string name, Mode mode)
		{
			Debug.Log("selecting power plan with name " + name + " for mode " + mode);
			var powerPlan = GetPowerPlanWithName(name);
			if (powerPlan == null)
			{
				Debug.LogError("cannot select power plan with name " + name + " for mode " + mode);
				return;
			}

			switch (mode)
			{
				case Mode.idle:
					selectedPlanPowerSaver = powerPlan;
					dm.SetPref("selectedPowerPlanPowerSaver", name);
					break;
				case Mode.balanced:
					selectedPlanBalanced = powerPlan;
					dm.SetPref("selectedPowerPlanBalanced", name);
					break;
				case Mode.performance:
					selectedPlanPerformance = powerPlan;
					dm.SetPref("selectedPowerPlanPerformance", name);
					break;
				default: throw new Exception();
			}
		}

		ManagedPowerPlan GetPowerPlanWithName(string name)
		{
			if (name.Equals(PowerPlanName_Balanced) && defaultPlanBalanced != null) return defaultPlanBalanced;
			else if (name.Equals(PowerPlanName_PPM_PowerSaver) && managedPlanPowerSaver != null) return managedPlanPowerSaver;
			else if (name.Equals(PowerPlanName_PPM_Balanced) && managedPlanBalanced != null) return managedPlanBalanced;
			else if (name.Equals(PowerPlanName_PPM_Performance) && managedPlanPerformance != null) return managedPlanPerformance;
			else
			{
				if (otherPlans.ContainsKey(name)) return otherPlans[name];
			}
			return null;
		}


		static void DuplicatePowerPlan(ManagedPowerPlan source, string name)
		{
			// Attempt to duplicate the 'Balanced' Power Scheme.
			Debug.Log("duplicating power plan: " + source);
			Guid results = PowerPlanWrapper.DuplicatePlan(source.guid);

			PowerPlanWrapper.SetPlanName(results, name);
			PowerPlanWrapper.SetPlanDescription(results, "Custom PowerPlan managed by PPM");
		}

		void ApplyPowerPlan(ManagedPowerPlan plan)
		{
			//if (!enabled) return;

			// must have plan
			if (plan == null)
			{
				Debug.LogError("cannot apply power plan: target plan is null");
				return;
			}

			// must be different
			if (PowerPlanWrapper.GetActivePlan() == plan.guid)
			{
				//Debug.LogWarning("cannot apply power plan: plan " + plan.name + " is already active");
				return;
			}

			// apply
			Debug.LogWarning("applying power plan: " + plan.name);
			PowerPlanWrapper.SetActivePlan(plan.guid);

			// check
			if (PowerPlanWrapper.GetActivePlan() != plan.guid)
			{
				Debug.LogError("applied plan " + plan.guid + " but current is " + PowerPlanWrapper.GetActivePlan());
			}
		}




		/*

		internal enum Mode
		{
			Battery,
			Balanced,
			Performance,
		}

		void SetModeViaCmd(Mode mode)
		{
			if (!enabled)
			{
				Debug.LogWarning("cannot apply power mode " + mode + ": disabled");
				return;
			}

			string modeGUID = "";
			switch (mode)
			{
				case Mode.Battery:
					modeGUID = "a1841308-3541-4fab-bc81-f71556f20b4a";
					break;

				default:
				case Mode.Balanced:
					modeGUID = "381b4222-f694-41f0-9685-ff5bb260df2e";
					break;
				case Mode.Performance:
					modeGUID = "8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c";
					break;
			}

			Debug.Log("applying power mode " + mode);
			System.Diagnostics.Process process = new System.Diagnostics.Process();
			System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
			startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
			startInfo.FileName = "cmd.exe";
			startInfo.Arguments = "/c powercfg /setactive " + modeGUID;
			//startInfo.RedirectStandardError = true;
			//startInfo.RedirectStandardOutput = true;
			//startInfo.UseShellExecute = true;
			//startInfo.CreateNoWindow = false;

			process.StartInfo = startInfo;
			process.Start();

			process.WaitForExit();

		}
		*/
	}
}
