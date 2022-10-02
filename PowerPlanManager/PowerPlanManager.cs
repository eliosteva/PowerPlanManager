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

		[DllImport("PowrProf.dll")]
		static extern UInt32 PowerEnumerate(IntPtr RootPowerKey, IntPtr SchemeGuid, IntPtr SubGroupOfPowerSettingGuid, UInt32 AcessFlags, UInt32 Index, ref Guid Buffer, ref UInt32 BufferSize);

		[DllImport("PowrProf.dll")]
		static extern UInt32 PowerReadFriendlyName(IntPtr RootPowerKey, ref Guid SchemeGuid, IntPtr SubGroupOfPowerSettingGuid, IntPtr PowerSettingGuid, IntPtr Buffer, ref UInt32 BufferSize);

		[DllImport("powrprof.dll")]
		static extern UInt32 PowerGetActiveScheme(IntPtr UserRootPowerKey, ref IntPtr ActivePolicyGuid);

		[DllImport("PowrProf.dll", CharSet = CharSet.Unicode)]
		static extern UInt32 PowerSetActiveScheme(IntPtr RootPowerKey, [MarshalAs(UnmanagedType.LPStruct)] Guid SchemeGuid);

		#endregion

		internal Action PowerPlanChangedEvent;

		DataManager dm;
		bool enabled = false;

		public Dictionary<Guid, LegacyPowerPlan> availablePlans = new Dictionary<Guid, LegacyPowerPlan>();
		public LegacyPowerPlan currentPlan = null;
		public LegacyPowerPlan defaultPlan = null;
		public LegacyPowerPlan idlePlan = null;

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

			availablePlans = GetAvailablePowerPlans();
			currentPlan = GetPowerPlanFromGuid(GetCurrentPowerPlan());

			// load from prefs
			defaultPlan = GetPowerPlanFromName(dm.GetPref("default"));
			idlePlan = GetPowerPlanFromName(dm.GetPref("idle"));
			enabled = dm.GetPref<bool>("ppm_enabled", false);
		}

		internal void ApplyIdlePowerPlan()
		{
			ApplyPowerPlan(idlePlan);
		}

		internal void ApplyDefaultPowerPlan()
		{
			ApplyPowerPlan(defaultPlan);
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
			return availablePlans[guid];
		}



		void ApplyPowerPlan(LegacyPowerPlan targetPlan)
		{
			if (!enabled)
			{
				Debug.LogWarning("cannot apply power plan: disabled");
				return;
			}

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

			string friendlyName;

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
