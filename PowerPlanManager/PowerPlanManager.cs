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

namespace PowerPlanManager
{
	internal class PowerPlanManager
	{

		internal class LegacyPowerPlan
		{
			public uint index;
			public Guid guid;
			public string name;
		}

		#region extern

		enum AccessFlags : uint
		{
			ACCESS_SCHEME = 16,
			ACCESS_SUBGROUP = 17,
			ACCESS_INDIVIDUAL_SETTING = 18
		}

		private const uint ERROR_MORE_DATA = 234;

		private static Guid NO_SUBGROUP_GUID = new Guid("fea3413e-7e05-4911-9a71-700331f1c294");
		private static Guid GUID_DISK_SUBGROUP = new Guid("0012ee47-9041-4b5d-9b77-535fba8b1442");
		private static Guid GUID_SYSTEM_BUTTON_SUBGROUP = new Guid("4f971e89-eebd-4455-a8de-9e59040e7347");
		private static Guid GUID_PROCESSOR_SETTINGS_SUBGROUP = new Guid("54533251-82be-4824-96c1-47b60b740d00");
		private static Guid GUID_VIDEO_SUBGROUP = new Guid("7516b95f-f776-4464-8c53-06167f40cc99");
		private static Guid GUID_BATTERY_SUBGROUP = new Guid("e73a048d-bf27-4f12-9731-8b2076e8891f");
		private static Guid GUID_SLEEP_SUBGROUP = new Guid("238C9FA8-0AAD-41ED-83F4-97BE242C8F20");
		private static Guid GUID_PCIEXPRESS_SETTINGS_SUBGROUP = new Guid("501a4d13-42af-4429-9fd1-a8218c268e20");

		[DllImport("PowrProf.dll")]
		static extern UInt32 PowerEnumerate(IntPtr RootPowerKey, IntPtr SchemeGuid, IntPtr SubGroupOfPowerSettingGuid, UInt32 AcessFlags, UInt32 Index, ref Guid Buffer, ref UInt32 BufferSize);

		[DllImport("PowrProf.dll")]
		static extern UInt32 PowerReadFriendlyName(IntPtr RootPowerKey, ref Guid SchemeGuid, IntPtr SubGroupOfPowerSettingGuid, IntPtr PowerSettingGuid, IntPtr Buffer, ref UInt32 BufferSize);

		[DllImport("powrprof.dll")]
		static extern UInt32 PowerGetActiveScheme(IntPtr UserRootPowerKey, ref IntPtr ActivePolicyGuid);

		[DllImport("PowrProf.dll", CharSet = CharSet.Unicode)]
		static extern UInt32 PowerSetActiveScheme(IntPtr RootPowerKey, [MarshalAs(UnmanagedType.LPStruct)] Guid SchemeGuid);

		[DllImport("powrprof.dll")]
		static extern uint PowerReadACValue( IntPtr RootPowerKey, IntPtr SchemeGuid, IntPtr SubGroupOfPowerSettingGuid, ref Guid PowerSettingGuid, ref int Type, ref IntPtr Buffer, ref uint BufferSize );

		[DllImport("kernel32.dll")] 
		static extern IntPtr LocalFree( IntPtr hMem );

		#endregion

		internal Action PowerPlanChangedEvent;

		DataManager dm;
		bool enabled = false;
		Dictionary<IdleManager.TargetStatus, LegacyPowerPlan> statusPlans = new Dictionary<IdleManager.TargetStatus, LegacyPowerPlan>();
		Dictionary<Guid, LegacyPowerPlan> availablePlans = new Dictionary<Guid, LegacyPowerPlan>();
		LegacyPowerPlan currentPlan = null;

		public IReadOnlyDictionary<IdleManager.TargetStatus, LegacyPowerPlan> StatusPlans => statusPlans;
		public IReadOnlyDictionary<Guid, LegacyPowerPlan> AvailablePlans => availablePlans;
		public LegacyPowerPlan CurrentPlan => currentPlan;

		internal bool Enabled
		{
			get => enabled;
			set
			{
				enabled = value;
				dm.SetPref("ppm_enabled", enabled.ToString());
			}
		}

		internal PowerPlanManager(DataManager dm)
		{
			this.dm = dm;
			Debug.Log("initializing power plan manager");
			Refresh();
		}

		internal void Refresh()
		{
			availablePlans = GetAvailablePowerPlans();
			currentPlan = GetPowerPlanFromGuid(GetCurrentPowerPlan());

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

		internal LegacyPowerPlan GetPowerPlanFromName(string s)
		{
			foreach (var v in availablePlans)
			{
				if (v.Value.name.Equals(s)) return v.Value;
			}

			return null;
		}

		internal LegacyPowerPlan GetPowerPlanFromGuid(Guid guid)
		{
			if (availablePlans.ContainsKey(guid)) return availablePlans[guid];
			return null;
		}

		internal void AssociatePowerPlanWithStatus(string name, IdleManager.TargetStatus status)
		{
			LegacyPowerPlan pp = GetPowerPlanFromName(name);
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


		void ApplyPowerPlan(LegacyPowerPlan targetPlan)
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

		static Dictionary<Guid, LegacyPowerPlan> GetAvailablePowerPlans()
		{
			Dictionary<Guid, LegacyPowerPlan> dic = new Dictionary<Guid, LegacyPowerPlan>();
			{
				Guid schemeGuid = Guid.Empty;
				uint sizeSchemeGuid = (uint)Marshal.SizeOf(typeof(Guid));
				uint schemeIndex = 0;
				while (PowerEnumerate(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, (uint)AccessFlags.ACCESS_SCHEME, schemeIndex, ref schemeGuid, ref sizeSchemeGuid) == 0)
				{
					LegacyPowerPlan pp = new LegacyPowerPlan();
					pp.index = schemeIndex;
					pp.guid = schemeGuid;
					pp.name = ReadFriendlyName(schemeGuid);
					Debug.Log("power plan found: " + pp.name);

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
