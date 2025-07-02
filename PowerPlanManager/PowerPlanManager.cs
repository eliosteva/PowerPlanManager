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

		class PowerPlanWrapper
		{
			public Guid guid;
			public string name;

			internal PowerPlanWrapper(Guid guid, string name)
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
					ApplySettingsToManagedPowerPlans();
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
					ApplySettingsToManagedPowerPlans();
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
					ApplySettingsToManagedPowerPlans();
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

		PowerPlanWrapper systemPlanBalanced = null;
		PowerPlanWrapper managedPlanPowerSaver = null;
		PowerPlanWrapper managedPlanBalanced = null;
		PowerPlanWrapper managedPlanPerformance = null;
		Dictionary<string, PowerPlanWrapper> otherPlans = new Dictionary<string, PowerPlanWrapper>();

		PowerPlanWrapper selectedPlanPowerSaver = null;
		PowerPlanWrapper selectedPlanBalanced = null;
		PowerPlanWrapper selectedPlanPerformance = null;

		uint displayTimeout = 15;
		uint sleepTimeout = 30;
		uint hibernateTimeout = 60;

		#endregion

		internal PowerPlanManager(DataManager dm)
		{
			this.dm = dm;
			Debug.Log("initializing power plan manager");

			// read PowerPlans
			ReadPowerPlans();

			// read prefs
			displayTimeout = dm.GetPref("displayTimeout", displayTimeout);
			sleepTimeout = dm.GetPref("sleepTimeout", sleepTimeout);
			hibernateTimeout = dm.GetPref("hibernateTimeout", hibernateTimeout);

			// read saved selected PowerPlans
			SelectPowerPlanForStatus(dm.GetPref("selectedPowerPlanPowerSaver", PowerPlanName_PPM_PowerSaver), Status.idle);
			SelectPowerPlanForStatus(dm.GetPref("selectedPowerPlanBalanced", PowerPlanName_PPM_Balanced), Status.balanced);
			SelectPowerPlanForStatus(dm.GetPref("selectedPowerPlanPerformance", PowerPlanName_PPM_Performance), Status.performance);
		}

		internal bool Initialize()
		{
			if (!HasManagedPlansInstalled())
			{
				if (!AskedToInstallManagedPlans())
				{
					if (AskToInstallManagedPlans())
					{
						InstallManagedPlans();
					}
					else
					{
						MessageBox.Show("Warning: Managed PowerPlans not installed, please select which PowerPlans to use for each status", "");
						return false;
					}
				}
			}
			return true;
		}

		internal void ApplyPowerPlanForStatus(Status status)
		{
			//Debug.Log("applying PowerPlan for status " + status);
			switch (status)
			{
				case Status.idle: ApplyPowerPlan(selectedPlanPowerSaver); break;
				case Status.balanced: ApplyPowerPlan(selectedPlanBalanced); break;
				case Status.performance: ApplyPowerPlan(selectedPlanPerformance); break;
			}
		}

		internal List<string> GetAllPowerPlansNames()
		{
			List<string> names = new List<string>();

			void Add(PowerPlanWrapper managedPowerPlan)
			{
				if (managedPowerPlan != null && !names.Contains(managedPowerPlan.name)) names.Add(managedPowerPlan.name);
			}

			Add(systemPlanBalanced);
			Add(managedPlanPowerSaver);
			Add(managedPlanBalanced);
			Add(managedPlanPerformance);
			foreach (var v in otherPlans)
			{
				Add(v.Value);
			}

			return names;
		}

		internal string GetSelectedPowerPlanNameForStatus(Status status)
		{
			switch (status)
			{
				case Status.idle: return selectedPlanPowerSaver?.name;
				case Status.balanced: return selectedPlanBalanced?.name;
				case Status.performance: return selectedPlanPerformance?.name;
				default: throw new Exception();
			}
		}

		internal void SelectPowerPlanForStatus(string name, Status status)
		{
			Debug.Log("selecting PowerPlan with name " + name + " for status " + status);
			var powerPlan = GetPowerPlanWithName(name);
			if (powerPlan == null)
			{
				Debug.LogError("cannot select PowerPlan with name " + name + " for status " + status);
				return;
			}

			switch (status)
			{
				case Status.idle:
					selectedPlanPowerSaver = powerPlan;
					dm.SetPref("selectedPowerPlanPowerSaver", name);
					break;
				case Status.balanced:
					selectedPlanBalanced = powerPlan;
					dm.SetPref("selectedPowerPlanBalanced", name);
					break;
				case Status.performance:
					selectedPlanPerformance = powerPlan;
					dm.SetPref("selectedPowerPlanPerformance", name);
					break;
				default: throw new Exception();
			}
		}

		internal void ReadPowerPlans()
		{
			void SetOrAddPowerPlan(ref PowerPlanWrapper reference, Guid guid, string name)
			{
				if (reference == null) reference = new PowerPlanWrapper(guid, name);
				else
				{
					reference.guid = guid;
				}
			}

			List<Guid> plans = PowerPlansApiWrapper.ListPlans();
			foreach (var plan in plans)
			{
				string name = PowerPlansApiWrapper.GetPlanName(plan);

				// try to find Balanced PowerPlan
				if (systemPlanBalanced == null && plan.Equals(PowerPlanGuid_Balanced)) SetOrAddPowerPlan(ref systemPlanBalanced, plan, PowerPlanName_Balanced);
				if (systemPlanBalanced == null && name.Equals(PowerPlanName_Balanced)) SetOrAddPowerPlan(ref systemPlanBalanced, plan, PowerPlanName_Balanced);

				// try to find managed PowerPlans, if installed
				if (managedPlanPowerSaver == null && name.Equals(PowerPlanName_PPM_PowerSaver)) SetOrAddPowerPlan(ref managedPlanPowerSaver, plan, PowerPlanName_PPM_PowerSaver);
				if (managedPlanBalanced == null && name.Equals(PowerPlanName_PPM_Balanced)) SetOrAddPowerPlan(ref managedPlanBalanced, plan, PowerPlanName_PPM_Balanced);
				if (managedPlanPerformance == null && name.Equals(PowerPlanName_PPM_Performance)) SetOrAddPowerPlan(ref managedPlanPerformance, plan, PowerPlanName_PPM_Performance);

				// read all other PowerPlans
				else
				{
					if (!otherPlans.ContainsKey(name))
					{
						PowerPlanWrapper otherPlan = null;
						SetOrAddPowerPlan(ref otherPlan, plan, name);
						otherPlans.Add(name, otherPlan);
					}
				}
			}
		}


		bool HasManagedPlansInstalled()
		{
			bool isInstalled = managedPlanPowerSaver != null && managedPlanBalanced != null && managedPlanPerformance != null;
			if (isInstalled) Debug.Log("managed PowerPlans already installed");
			else Debug.Log("managed PowerPlans not installed");
			return isInstalled;
		}

		bool AskToInstallManagedPlans()
		{
			Debug.Log("asking to install managed PowerPlans");

			dm.SetPref("askedToInstall", true.ToString());
			DialogResult dr = MessageBox.Show("Managed PowerPlans not installed. Install?", "", MessageBoxButtons.YesNo);
			if (dr == System.Windows.Forms.DialogResult.Yes)
			{
				Debug.Log("user accepted managed PowerPlans installation");
				return true;
			}
			else
			{
				Debug.Log("user refused managed PowerPlans installation");
				return false;
			}
		}

		bool AskedToInstallManagedPlans()
		{
			bool alreadyAsked = dm.GetPref("askedToInstall") == true.ToString();
			if (alreadyAsked) Debug.Log("already asked to install managed PowerPlans, will not ask again");
			return alreadyAsked;
		}

		void InstallManagedPlans()
		{
			Debug.Log("installing managed PowerPlans");

			// must have balanced power plan
			if (systemPlanBalanced == null)
			{
				string s = "Cannot install managed PowerPlans, no Balanced PowerPlan found";
				Debug.LogWarning(s);
				MessageBox.Show(s, "");
				return;
			}

			IntPtr RetrPointer = IntPtr.Zero;

			// duplicate managed plans from default balanced
			if (managedPlanPowerSaver == null) DuplicatePowerPlan(systemPlanBalanced, PowerPlanName_PPM_PowerSaver);
			if (managedPlanBalanced == null) DuplicatePowerPlan(systemPlanBalanced, PowerPlanName_PPM_Balanced);
			if (managedPlanPerformance == null) DuplicatePowerPlan(systemPlanBalanced, PowerPlanName_PPM_Performance);

			// apply default settings to managed plans if they exists
			ApplySettingsToManagedPowerPlans();

			// select managed plans
			Debug.Log("selecting managed PowerPlans");
			selectedPlanPowerSaver = managedPlanPowerSaver;
			selectedPlanBalanced = managedPlanBalanced;
			selectedPlanPerformance = managedPlanPerformance;
		}

		void UninstallManagedPlans()
		{
			// TODO check if in use
			if (managedPlanPowerSaver != null) PowerPlansApiWrapper.DeletePlan(managedPlanPowerSaver.guid);
			if (managedPlanBalanced != null) PowerPlansApiWrapper.DeletePlan(managedPlanBalanced.guid);
			if (managedPlanPerformance != null) PowerPlansApiWrapper.DeletePlan(managedPlanPerformance.guid);
		}

		void ApplySettingsToManagedPowerPlans()
		{
			if (managedPlanPowerSaver != null) ApplySettingsToPowerPlan(managedPlanPowerSaver, ProcessorBoostModes.disabled, displayTimeout, sleepTimeout, hibernateTimeout, 50);
			if (managedPlanBalanced != null) ApplySettingsToPowerPlan(managedPlanBalanced, ProcessorBoostModes.disabled, displayTimeout, 0, 0, 100);
			if (managedPlanPerformance != null) ApplySettingsToPowerPlan(managedPlanPerformance, ProcessorBoostModes.enabled, 0, 0, 0, 100);
		}

		void ApplySettingsToPowerPlan(PowerPlanWrapper pp, ProcessorBoostModes boostMode, uint screenTimeout, uint sleepTimeout, uint hibernateTimeout, uint maxProcThrottle)
		{
			// apply ProcessorBoostModes
			PowerPlansApiWrapper.SetPlanSetting(pp.guid, SettingSubgroup.PROCESSOR_SETTINGS_SUBGROUP, Setting.PERFBOOSTMODE, PowerMode.DC, 0);
			PowerPlansApiWrapper.SetPlanSetting(pp.guid, SettingSubgroup.PROCESSOR_SETTINGS_SUBGROUP, Setting.PERFBOOSTMODE, PowerMode.AC, (uint)(int)boostMode);

			PowerPlansApiWrapper.SetPlanSetting(pp.guid, SettingSubgroup.VIDEO_SUBGROUP, Setting.VIDEOIDLE, PowerMode.DC, 60);
			PowerPlansApiWrapper.SetPlanSetting(pp.guid, SettingSubgroup.VIDEO_SUBGROUP, Setting.VIDEOIDLE, PowerMode.AC, screenTimeout * 60);

			PowerPlansApiWrapper.SetPlanSetting(pp.guid, SettingSubgroup.SLEEP_SUBGROUP, Setting.STANDBYIDLE, PowerMode.DC, 60);
			PowerPlansApiWrapper.SetPlanSetting(pp.guid, SettingSubgroup.SLEEP_SUBGROUP, Setting.STANDBYIDLE, PowerMode.AC, sleepTimeout * 60);

			PowerPlansApiWrapper.SetPlanSetting(pp.guid, SettingSubgroup.SLEEP_SUBGROUP, Setting.HIBERNATEIDLE, PowerMode.DC, 60);
			PowerPlansApiWrapper.SetPlanSetting(pp.guid, SettingSubgroup.SLEEP_SUBGROUP, Setting.HIBERNATEIDLE, PowerMode.AC, hibernateTimeout * 60);

			PowerPlansApiWrapper.SetPlanSetting(pp.guid, SettingSubgroup.PROCESSOR_SETTINGS_SUBGROUP, Setting.PROCTHROTTLEMIN, PowerMode.DC, 5);
			PowerPlansApiWrapper.SetPlanSetting(pp.guid, SettingSubgroup.PROCESSOR_SETTINGS_SUBGROUP, Setting.PROCTHROTTLEMIN, PowerMode.AC, 5);

			PowerPlansApiWrapper.SetPlanSetting(pp.guid, SettingSubgroup.PROCESSOR_SETTINGS_SUBGROUP, Setting.PROCTHROTTLEMAX, PowerMode.DC, 50);
			PowerPlansApiWrapper.SetPlanSetting(pp.guid, SettingSubgroup.PROCESSOR_SETTINGS_SUBGROUP, Setting.PROCTHROTTLEMAX, PowerMode.AC, maxProcThrottle);
		}

		void ApplyPowerPlan(PowerPlanWrapper plan)
		{
			//if (!enabled) return;

			// must have plan
			if (plan == null)
			{
				Debug.LogError("cannot apply PowerPlan: target plan is null");
				return;
			}

			// must be different
			if (PowerPlansApiWrapper.GetActivePlan() == plan.guid)
			{
				//Debug.LogWarning("cannot apply PowerPlan: plan " + plan.name + " is already active");
				return;
			}

			// apply
			Debug.LogWarning("applying PowerPlan: " + plan.name);
			PowerPlansApiWrapper.SetActivePlan(plan.guid);

			// check
			if (PowerPlansApiWrapper.GetActivePlan() != plan.guid)
			{
				Debug.LogError("failed to apply PowerPlan " + plan.guid + ", current is " + PowerPlansApiWrapper.GetActivePlan());
			}
		}

		PowerPlanWrapper GetPowerPlanWithName(string name)
		{
			if (name.Equals(PowerPlanName_Balanced) && systemPlanBalanced != null) return systemPlanBalanced;
			else if (name.Equals(PowerPlanName_PPM_PowerSaver) && managedPlanPowerSaver != null) return managedPlanPowerSaver;
			else if (name.Equals(PowerPlanName_PPM_Balanced) && managedPlanBalanced != null) return managedPlanBalanced;
			else if (name.Equals(PowerPlanName_PPM_Performance) && managedPlanPerformance != null) return managedPlanPerformance;
			else
			{
				if (otherPlans.ContainsKey(name)) return otherPlans[name];
			}
			return null;
		}

		static void DuplicatePowerPlan(PowerPlanWrapper source, string name)
		{
			// Attempt to duplicate the 'Balanced' Power Scheme.
			Debug.Log("duplicating power plan: " + source);
			Guid results = PowerPlansApiWrapper.DuplicatePlan(source.guid);

			PowerPlansApiWrapper.SetPlanName(results, name);
			PowerPlansApiWrapper.SetPlanDescription(results, "Custom PowerPlan managed by PPM");
		}

	}
}
