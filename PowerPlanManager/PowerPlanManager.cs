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


namespace PowerPlanManager
{

	internal class PowerPlanManager
	{
		internal enum PowerModes
		{
			idle = 0,
			balanced = 1,
			performance = 2,
		}

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

		class PowerPlan
		{
			public Guid guid;
			public string name;

			internal PowerPlan(Guid guid, string name)
			{
				this.guid = guid;
				this.name = name;
			}

			public override string ToString()
			{
				return name + "(" + guid + ")";
			}
		}

		const string PowerPlanGuid_Balanced = "381b4222-f694-41f0-9685-ff5bb260df2e";
		const string PowerPlanName_Balanced = "Balanced";
		const string PowerPlanName_PPM_PowerSaver = "PPM_PowerSaver";
		const string PowerPlanName_PPM_Balanced = "PPM_Balanced";
		const string PowerPlanName_PPM_Performance = "PPM_Performance";

		internal Action PowerPlanAppliedEvent;

		internal bool Enabled
		{
			get => enabled;
			set
			{
				enabled = value;
				dm.SetPref("ppm_enabled", enabled.ToString());
			}
		}

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

		DataManager dm;
		bool enabled = false;
		PowerPlan defaultPlanBalanced = null;
		PowerPlan customPlanPowerSaver = null;
		PowerPlan customPlanBalanced = null;
		PowerPlan customPlanPerformance = null;

		uint displayTimeout = 15;
		uint sleepTimeout = 60;
		uint hibernateTimeout = 60;



		internal PowerPlanManager(DataManager dm)
		{
			this.dm = dm;
			Debug.Log("initializing power plan manager");

			enabled = dm.GetPref<bool>("ppm_enabled", enabled);
			displayTimeout = dm.GetPref("displayTimeout", displayTimeout);
			sleepTimeout = dm.GetPref("sleepTimeout", sleepTimeout);
			hibernateTimeout = dm.GetPref("hibernateTimeout", hibernateTimeout);

			Refresh();
		}

		internal void Refresh()
		{
			void SetOrAddPowerPlan(ref PowerPlan reference, Guid guid, string name)
			{
				if (reference == null) reference = new PowerPlan(guid, name);
				else
				{
					reference.guid = guid;
				}
			}

			void ApplyPowerPlanSettings(PowerPlan pp, ProcessorBoostModes boostMode, uint screenTimeout, uint sleepTimeout, uint hibernateTimeout, uint maxProcThrottle)
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

			var plans = PowerPlanWrapper.ListPlans();
			foreach(var plan in plans)
			{
				string name = PowerPlanWrapper.GetPlanName(plan);

				if (plan.Equals(PowerPlanGuid_Balanced)) SetOrAddPowerPlan(ref defaultPlanBalanced, plan, PowerPlanName_Balanced);
				else if (name.Equals(PowerPlanName_Balanced)) SetOrAddPowerPlan(ref defaultPlanBalanced, plan, PowerPlanName_Balanced);
				else if (name.Equals(PowerPlanName_PPM_PowerSaver)) SetOrAddPowerPlan(ref customPlanPowerSaver, plan, PowerPlanName_PPM_PowerSaver);
				else if (name.Equals(PowerPlanName_PPM_Balanced)) SetOrAddPowerPlan(ref customPlanBalanced, plan, PowerPlanName_PPM_Balanced);
				else if (name.Equals(PowerPlanName_PPM_Performance)) SetOrAddPowerPlan(ref customPlanPerformance, plan, PowerPlanName_PPM_Performance);
			}

			if (customPlanPowerSaver != null) ApplyPowerPlanSettings(customPlanPowerSaver, ProcessorBoostModes.disabled, displayTimeout, sleepTimeout, hibernateTimeout, 50);
			if (customPlanBalanced != null) ApplyPowerPlanSettings(customPlanBalanced, ProcessorBoostModes.disabled, displayTimeout, 0, 0, 100);
			if (customPlanPerformance != null) ApplyPowerPlanSettings(customPlanPerformance, ProcessorBoostModes.enabled, 0, 0, 0, 100);

			//Guid current = PowerPlanWrapper.GetActivePlan();

			//if (customPlanBalanced != null)
			//{
			//	var res = PowerPlanWrapper.GetPlanSetting(customPlanPowerSaver.guid, SettingSubgroup.PROCESSOR_SETTINGS_SUBGROUP, Setting.PROCTHROTTLEMAX, PowerMode.AC);
			//	Debug.Log(res.ToString());
			//}

		}

		internal bool IsInstalled()
		{
			Refresh();

			return customPlanPowerSaver != null && customPlanBalanced != null && customPlanPerformance != null;
		}

		internal bool AskToInstall()
		{
			DialogResult dr = MessageBox.Show("Custom power plans not installed. Install?", "", MessageBoxButtons.YesNo);
			if (dr == System.Windows.Forms.DialogResult.Yes)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		internal void Install()
		{
			// must have balanced power plan
			if (defaultPlanBalanced == null)
			{
				MessageBox.Show("Default Balanced PowerPlan not found", "");
				return;
			}

			Debug.Log("installing custom power plans");
			IntPtr RetrPointer = IntPtr.Zero;
			if (customPlanPowerSaver == null) DuplicatePowerPlan(defaultPlanBalanced, PowerPlanName_PPM_PowerSaver);
			if (customPlanBalanced == null) DuplicatePowerPlan(defaultPlanBalanced, PowerPlanName_PPM_Balanced);
			if (customPlanPerformance == null) DuplicatePowerPlan(defaultPlanBalanced, PowerPlanName_PPM_Performance);
			Refresh();
		}

		internal void ApplyPowerMode(PowerModes powerMode)
		{
			switch (powerMode)
			{
				case PowerModes.idle: ApplyPowerPlan(customPlanPowerSaver); break;
				case PowerModes.balanced: ApplyPowerPlan(customPlanBalanced); break;
				case PowerModes.performance: ApplyPowerPlan(customPlanPerformance); break;
			}
		}



		static void DuplicatePowerPlan(PowerPlan source, string name)
		{
			Guid result = new Guid();
			IntPtr RetrPointer = IntPtr.Zero;

			// Attempt to duplicate the 'Balanced' Power Scheme.
			Debug.Log("duplicating power plan: " + source);
			Guid results = PowerPlanWrapper.DuplicatePlan(source.guid);

			PowerPlanWrapper.SetPlanName(result, name);
			PowerPlanWrapper.SetPlanDescription(result, "Custom PowerPlan managed by PPM");
		}

		void ApplyPowerPlan(PowerPlan powerPlan)
		{
			if (!enabled) return;

			//// must have target
			//if (targetPlan == null)
			//{
			//	Debug.LogWarning("cannot apply power plan: plan is null");
			//	return;
			//}

			//// must be different
			//if (currentPlan == targetPlan)
			//{
			//	Debug.LogWarning("cannot apply power plan: plan " + targetPlan.name + " is already active");
			//	return;
			//}

			// apply
			Debug.LogWarning("applying power plan: " + powerPlan.name);
			PowerPlanWrapper.SetActivePlan(powerPlan.guid);

			// check
			//currentPlan = GetPowerPlanFromGuid(GetCurrentPowerPlan());
			//if (currentPlan != targetPlan) Debug.LogError("applied plan " + targetPlan.name + " but current is " + currentPlan.name);

			PowerPlanAppliedEvent?.Invoke();
		}



		/*
		internal class PowerPlan
		{
			public uint index;
			public Guid guid;
			public string name;

			public override string ToString()
			{
				return "[" + index + "] " + name + "(" + guid + ")";
			}
		}

		#region extern

		enum AccessFlags : uint
		{
			ACCESS_SCHEME = 16,
			ACCESS_SUBGROUP = 17,
			ACCESS_INDIVIDUAL_SETTING = 18
		}

		const uint ERROR_MORE_DATA = 234;

		static Guid NO_SUBGROUP_GUID = new Guid("fea3413e-7e05-4911-9a71-700331f1c294");
		static Guid GUID_DISK_SUBGROUP = new Guid("0012ee47-9041-4b5d-9b77-535fba8b1442");
		static Guid GUID_SYSTEM_BUTTON_SUBGROUP = new Guid("4f971e89-eebd-4455-a8de-9e59040e7347");
		static Guid GUID_PROCESSOR_SETTINGS_SUBGROUP = new Guid("54533251-82be-4824-96c1-47b60b740d00");
		static Guid GUID_VIDEO_SUBGROUP = new Guid("7516b95f-f776-4464-8c53-06167f40cc99");
		static Guid GUID_BATTERY_SUBGROUP = new Guid("e73a048d-bf27-4f12-9731-8b2076e8891f");
		static Guid GUID_SLEEP_SUBGROUP = new Guid("238C9FA8-0AAD-41ED-83F4-97BE242C8F20");
		static Guid GUID_PCIEXPRESS_SETTINGS_SUBGROUP = new Guid("501a4d13-42af-4429-9fd1-a8218c268e20");

		[DllImport("PowrProf.dll")]
		static extern UInt32 PowerEnumerate(IntPtr RootPowerKey, IntPtr SchemeGuid, IntPtr SubGroupOfPowerSettingGuid, UInt32 AcessFlags, UInt32 Index, ref Guid Buffer, ref UInt32 BufferSize);

		[DllImport("PowrProf.dll")]
		static extern UInt32 PowerReadFriendlyName(IntPtr RootPowerKey, ref Guid SchemeGuid, IntPtr SubGroupOfPowerSettingGuid, IntPtr PowerSettingGuid, IntPtr Buffer, ref UInt32 BufferSize);

		[DllImport("powrprof.dll")]
		static extern UInt32 PowerGetActiveScheme(IntPtr UserRootPowerKey, ref IntPtr ActivePolicyGuid);

		[DllImport("PowrProf.dll", CharSet = CharSet.Unicode)]
		static extern UInt32 PowerSetActiveScheme(IntPtr RootPowerKey, [MarshalAs(UnmanagedType.LPStruct)] Guid SchemeGuid);

		[DllImport("powrprof.dll", EntryPoint = "PowerDuplicateScheme", SetLastError = true)]
		static extern UInt32 PowerDuplicateScheme(IntPtr RootPowerKey, ref Guid SrcSchemeGuid, ref IntPtr DstSchemeGuid);

		[DllImport("powrprof.dll", CharSet = CharSet.Unicode)]
		private static extern uint PowerWriteFriendlyName(
			[In, Optional] IntPtr RootPowerKey,
			[In] ref Guid SchemeGuid,
			[In, Optional] IntPtr SubGroupOfPowerSettingsGuid,
			[In, Optional] IntPtr PowerSettingGuid,
			[In] string Buffer,
			[In] UInt32 BufferSize
		);

		[DllImport("powrprof.dll", CharSet = CharSet.Unicode)]
		private static extern uint PowerWriteDescription(
			[In, Optional] IntPtr RootPowerKey,
			[In] ref Guid SchemeGuid,
			[In, Optional] IntPtr SubGroupOfPowerSettingsGuid,
			[In, Optional] IntPtr PowerSettingGuid,
			[In] string Buffer,
			[In] UInt32 BufferSize
		);

		[DllImport("powrprof.dll")]
		static extern uint PowerReadACValue( IntPtr RootPowerKey, IntPtr SchemeGuid, IntPtr SubGroupOfPowerSettingGuid, ref Guid PowerSettingGuid, ref int Type, ref IntPtr Buffer, ref uint BufferSize );

		[DllImport("kernel32.dll")] 
		static extern IntPtr LocalFree( IntPtr hMem );

		#endregion

		internal Action PowerPlanChangedEvent;

		DataManager dm;
		bool enabled = false;
		Dictionary<IdleManager.TargetStatus, PowerPlan> statusPlans = new Dictionary<IdleManager.TargetStatus, PowerPlan>();
		Dictionary<Guid, PowerPlan> availablePlans = new Dictionary<Guid, PowerPlan>();
		PowerPlan currentPlan = null;
		PowerPlan defaultPlanBalanced = null;
		PowerPlan customPlanPowerSaver = null;
		PowerPlan customPlanBalanced = null;
		PowerPlan customPlanPerformance = null;

		public IReadOnlyDictionary<IdleManager.TargetStatus, PowerPlan> StatusPlans => statusPlans;
		public IReadOnlyDictionary<Guid, PowerPlan> AvailablePlans => availablePlans;
		public PowerPlan CurrentPlan => currentPlan;

		internal bool Enabled
		{
			get => enabled;
			set
			{
				enabled = value;
				dm.SetPref("ppm_enabled", enabled.ToString());
			}
		}

		const string PowerPlanGuid_Balanced = "381b4222-f694-41f0-9685-ff5bb260df2e";
		const string PowerPlanName_PowerSaver = "PPM_PowerSaver";
		const string PowerPlanName_Balanced = "PPM_Balanced";
		const string PowerPlanName_Performance = "PPM_Performance";

		internal PowerPlanManager(DataManager dm)
		{
			this.dm = dm;
			Debug.Log("initializing power plan manager");
			Refresh();
		}


		internal bool IsInstalled()
		{
			Refresh();

			return customPlanPowerSaver != null && customPlanBalanced != null && customPlanPerformance != null;
		}

		internal bool AskToInstall()
		{
			DialogResult dr = MessageBox.Show("Custom power plans not installed. Install?", "", MessageBoxButtons.YesNo);
			if (dr == System.Windows.Forms.DialogResult.Yes)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		internal void Install()
		{
			// must have balanced power plan
			if (defaultPlanBalanced == null)
			{
				MessageBox.Show("Default Balanced PowerPlan not found", "");
				return;
			}

			Debug.Log("installing custom power plans");
			IntPtr RetrPointer = IntPtr.Zero;
			if (customPlanPowerSaver == null) DuplicatePowerPlan(defaultPlanBalanced, PowerPlanName_PowerSaver);
			if (customPlanBalanced == null) DuplicatePowerPlan(defaultPlanBalanced, PowerPlanName_Balanced);
			if (customPlanPerformance == null) DuplicatePowerPlan(defaultPlanBalanced, PowerPlanName_Performance);
			Refresh();
		}




		internal void Refresh()
		{
			availablePlans = GetAvailablePowerPlans();
			currentPlan = GetPowerPlanFromGuid(GetCurrentPowerPlan());

			foreach (var v in availablePlans)
			{
				if (v.Value.name.Equals(PowerPlanName_PowerSaver)) customPlanPowerSaver = v.Value;
				if (v.Value.name.Equals(PowerPlanName_Balanced)) customPlanBalanced = v.Value;
				if (v.Value.name.Equals(PowerPlanName_Performance)) customPlanPerformance = v.Value;
				if (v.Value.guid.ToString().Equals(PowerPlanGuid_Balanced)) defaultPlanBalanced = v.Value;
			}



			// load from prefs
			statusPlans.Clear();
			statusPlans.Add(IdleManager.TargetStatus.idle, GetPowerPlanFromName(dm.GetPref(IdleManager.TargetStatus.idle.ToString())));
			statusPlans.Add(IdleManager.TargetStatus.balanced, GetPowerPlanFromName(dm.GetPref(IdleManager.TargetStatus.balanced.ToString())));
			statusPlans.Add(IdleManager.TargetStatus.performance, GetPowerPlanFromName(dm.GetPref(IdleManager.TargetStatus.performance.ToString())));
			enabled = dm.GetPref<bool>("ppm_enabled", enabled);

			
		}

		internal void ApplyPowerPlanForStatus(IdleManager.TargetStatus status)
		{
			if (!statusPlans.ContainsKey(status))
			{
				Debug.LogError("cannot apply PowerPlan: no PowerPlan associated with status " + status);
				return;
			}

			// apply plan for status
			ApplyPowerPlan(statusPlans[status]);
		}

		internal PowerPlan GetPowerPlanFromName(string s)
		{
			foreach (var v in availablePlans)
			{
				if (v.Value.name.Equals(s)) return v.Value;
			}

			return null;
		}

		internal PowerPlan GetPowerPlanFromGuid(Guid guid)
		{
			if (availablePlans.ContainsKey(guid)) return availablePlans[guid];
			return null;
		}

		internal void AssociatePowerPlanWithStatus(string name, IdleManager.TargetStatus status)
		{
			PowerPlan pp = GetPowerPlanFromName(name);
			if (pp != null)
			{
				if (!statusPlans.ContainsKey(status))
				{
					Debug.Log("associating PowerPlan " + name + " to status " + status);
					statusPlans.Add(status, pp);

					// save pref
					dm.SetPref(status.ToString(), name);
				}
				else
				{
					// only if changed
					if (statusPlans[status] != pp)
					{
						Debug.Log("associating PowerPlan " + name + " to status " + status);
						statusPlans[status] = pp;

						// save pref
						dm.SetPref(status.ToString(), name);
					}
				}
			}
		}


		void ApplyPowerPlan(PowerPlan targetPlan)
		{
			if (!enabled) return;

			// must have target
			if (targetPlan == null)
			{
				Debug.LogWarning("cannot apply power plan: plan is null");
				return;
			}

			// must be different
			if (currentPlan == targetPlan)
			{
				Debug.LogWarning("cannot apply power plan: plan " + targetPlan.name + " is already active");
				return;
			}

			// apply
			Debug.LogWarning("applying power plan: " + targetPlan.name);
			SetActiveScheme(targetPlan.guid);

			// check
			currentPlan = GetPowerPlanFromGuid(GetCurrentPowerPlan());
			if (currentPlan != targetPlan) Debug.LogError("applied plan " + targetPlan.name + " but current is " + currentPlan.name);

			PowerPlanChangedEvent?.Invoke();
		}


		static string ReadFriendlyName(Guid schemeGuid)
		{
			uint sizeName = 1024;
			IntPtr pSizeName = Marshal.AllocHGlobal((int)sizeName);

			string friendlyName = "";

			try
			{
				PowerReadFriendlyName(IntPtr.Zero, ref schemeGuid, IntPtr.Zero, IntPtr.Zero, pSizeName, ref sizeName);
				friendlyName = Marshal.PtrToStringUni(pSizeName);
			}
			finally
			{
				Marshal.FreeHGlobal(pSizeName);
			}

			return friendlyName;
		}

		static Dictionary<Guid, PowerPlan> GetAvailablePowerPlans()
		{
			Dictionary<Guid, PowerPlan> dic = new Dictionary<Guid, PowerPlan>();
			{
				Guid schemeGuid = Guid.Empty;
				uint sizeSchemeGuid = (uint)Marshal.SizeOf(typeof(Guid));
				uint schemeIndex = 0;
				while (PowerEnumerate(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, (uint)AccessFlags.ACCESS_SCHEME, schemeIndex, ref schemeGuid, ref sizeSchemeGuid) == 0)
				{
					PowerPlan pp = new PowerPlan();
					pp.index = schemeIndex;
					pp.guid = schemeGuid;
					pp.name = ReadFriendlyName(schemeGuid);
					Debug.Log("power plan found: " + pp);

					dic.Add(schemeGuid, pp);

					schemeIndex++;
				}
			}
			return dic;
		}

		static Guid GetCurrentPowerPlan()
		{
			IntPtr ActiveScheme = IntPtr.Zero;
			PowerGetActiveScheme(IntPtr.Zero, ref ActiveScheme);
			Guid ActivePolicy = Marshal.PtrToStructure<Guid>(ActiveScheme);
			return ActivePolicy;
		}

		static void SetActiveScheme(Guid guid)
		{
			PowerSetActiveScheme(IntPtr.Zero, guid);
		}

		static void DuplicatePowerPlan(PowerPlan source, string name)
		{
			Guid result = new Guid();
			IntPtr RetrPointer = IntPtr.Zero;

			// Attempt to duplicate the 'Balanced' Power Scheme.
			Debug.Log("duplicating power plan: " + source);
			PowerDuplicateScheme(IntPtr.Zero, ref source.guid, ref RetrPointer);

			if (RetrPointer != IntPtr.Zero)
			{
				// Function returns a pointer-to-memory, marshal back to our Guid variable.
				result = (Guid)Marshal.PtrToStructure(RetrPointer, typeof(Guid));

				// set name
				name += char.MinValue; // Null-terminate the name string.
				uint bufferSize = (uint)Encoding.Unicode.GetByteCount(name);
				var res = PowerWriteFriendlyName(IntPtr.Zero, ref result, IntPtr.Zero, IntPtr.Zero, name, bufferSize);
				if (res != 0) Debug.LogError("failed to set plan name: error code is " + res);

				// set description
				string description = "Custom PowerPlan managed by PPM" + char.MinValue;
				bufferSize = (uint)Encoding.Unicode.GetByteCount(description);
				res = PowerWriteDescription(IntPtr.Zero, ref result, IntPtr.Zero, IntPtr.Zero, description, bufferSize);
				if (res != 0) Debug.LogError("failed to set plan description: error code is " + res);
			}
			else Debug.LogError("failed to duplicate plan");

		}
		
		*/







		/*

		//Balanced: 381b4222-f694-41f0-9685-ff5bb260df2e
		//High performance: 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c
		//Power saver: a1841308-3541-4fab-bc81-f71556f20b4a

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


		internal void ApplyIdlePowerPlan()
		{
			SetModeViaCmd(Mode.Battery);
		}

		internal void ApplyDefaultPowerPlan()
		{
			SetModeViaCmd(Mode.Balanced);
		}
		*/
	}
}
