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



		internal class PowerPlan
		{
			public uint index;
			public Guid guid;
			public string name;
		}

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


		internal Action PowerPlanChangedEvent;

		DataManager dm;

		public Dictionary<Guid, PowerPlan> availablePlans = new Dictionary<Guid, PowerPlan>();
		public PowerPlan currentPlan = null;
		public PowerPlan defaultPlan = null;
		public PowerPlan idlePlan = null;

		internal PowerPlanManager(DataManager dm)
		{
			this.dm = dm;
			Debug.Log("initializing power plan manager");

			availablePlans = GetAvailablePowerPlans();
			currentPlan = GetPowerPlanFromGuid(GetCurrentPowerPlan());

			// load from prefs
			defaultPlan = GetPowerPlanFromName(dm.GetPref("default"));
			idlePlan = GetPowerPlanFromName(dm.GetPref("idle"));
		}


		public PowerPlan GetPowerPlanFromName(string s)
		{
			foreach (var v in availablePlans)
			{
				if (v.Value.name.Equals(s)) return v.Value;
			}

			return null;
		}

		public PowerPlan GetPowerPlanFromGuid(Guid guid)
		{
			return availablePlans[guid];
		}

		internal void ApplyIdlePowerPlan()
		{
			ApplyPowerPlan(idlePlan);
		}

		internal void ApplyDefaultPowerPlan()
		{
			ApplyPowerPlan(defaultPlan);
		}

		void ApplyPowerPlan(PowerPlan targetPlan)
		{
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

	}
}
