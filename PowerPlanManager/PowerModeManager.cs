using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PowerPlanManager
{
	internal class PowerModeManager
	{

		internal Action PowerModeAppliedEvent;

		internal bool IsCurrentModePowerSaver
		{
			get
			{
				PowerGetEffectiveOverlayScheme(out Guid guid);
				return guid == PowerMode.BetterBattery;
			}
		}

		internal bool IsCurrentModeBalanced
		{
			get
			{
				PowerGetEffectiveOverlayScheme(out Guid guid);
				return guid == PowerMode.BetterPerformance;
			}
		}
		
		internal bool IsCurrentModePerformance
		{
			get
			{
				PowerGetEffectiveOverlayScheme(out Guid guid);
				return guid == PowerMode.BestPerformance;
			}
		}

		DataManager dm;
		
		internal PowerModeManager(DataManager dm)
		{
			this.dm = dm;

		}


		internal string GetCurrentPowerModeName()
		{
			string s = "";
			PowerGetEffectiveOverlayScheme(out Guid guid);
			if (guid == PowerMode.BetterBattery) s = "Best power efficiency";
			else if (guid == PowerMode.BetterPerformance) s = "Balanced";
			else if (guid.ToString() == "3af9B8d9-7c97-431d-ad78-34a8bfea439f") s = "Balanced";
			else if (guid == PowerMode.BestPerformance) s = "Best performance";
			else s = "unknown";
			s += " (" + guid.ToString() + ")";
			return s;
		}

		internal void ApplyBatterySaverPowerMode()
		{
			ApplyPowerMode(PowerMode.BetterBattery);
		}

		internal void ApplyBalancedPowerMode()
		{
			ApplyPowerMode(PowerMode.BetterPerformance);
		}
		
		internal void ApplyPerformancePowerMode()
		{
			ApplyPowerMode(PowerMode.BestPerformance);
		}

		void ApplyPowerMode(Guid powerMode)
		{
			uint result = PowerSetActiveOverlayScheme(powerMode);

			if (result == 0)
			{
				Debug.Log("power mode set to: " + powerMode);
			}
			else
			{
				Debug.LogError("failed to set power mode to: " + powerMode);
			}

			PowerModeAppliedEvent?.Invoke();
		}





		// https://github.com/AaronKelley/PowerMode/blob/main/SetPowerMode.cs

		/// <summary>
		/// Contains GUID constants for the different power modes.
		/// </summary>
		/// <seealso cref="https://docs.microsoft.com/en-us/windows-hardware/customize/desktop/customize-power-slider"/>
		static class PowerMode
		{
			/// <summary>
			/// Better Battery mode.
			/// </summary>
			public static Guid BetterBattery = new Guid("961cc777-2547-4f9d-8174-7d86181b8a7a");

			/// <summary>
			/// Better Performance mode.
			/// </summary>
			//public static Guid BetterPerformance = new Guid("3af9B8d9-7c97-431d-ad78-34a8bfea439f");
			public static Guid BetterPerformance = new Guid("00000000000000000000000000000000");
			
			/// <summary>
			/// Best Performance mode.
			/// </summary>
			public static Guid BestPerformance = new Guid("ded574b5-45a0-4f42-8737-46345c09c238");
		}

		/// <summary>
		/// Retrieves the active overlay power scheme and returns a GUID that identifies the scheme.
		/// </summary>
		/// <param name="EffectiveOverlayPolicyGuid">A pointer to a GUID structure.</param>
		/// <returns>Returns zero if the call was successful, and a nonzero value if the call failed.</returns>
		[DllImportAttribute("powrprof.dll", EntryPoint = "PowerGetEffectiveOverlayScheme")]
		static extern uint PowerGetEffectiveOverlayScheme(out Guid EffectiveOverlayPolicyGuid);

		/// <summary>
		/// Sets the active power overlay power scheme.
		/// </summary>
		/// <param name="OverlaySchemeGuid">The identifier of the overlay power scheme.</param>
		/// <returns>Returns zero if the call was successful, and a nonzero value if the call failed.</returns>
		[DllImportAttribute("powrprof.dll", EntryPoint = "PowerSetActiveOverlayScheme")]
		static extern uint PowerSetActiveOverlayScheme(Guid OverlaySchemeGuid);

	}
}
