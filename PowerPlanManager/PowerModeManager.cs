﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PowerPlanManager
{
	internal class PowerModeManager
	{



		internal Action PowerModeChangedEvent;

		DataManager dm;
		bool enabled = true;

		internal bool Enabled
		{
			get => enabled;
			set
			{
				enabled = value;
				dm.SetPref("pmm_enabled", enabled.ToString());
			}
		}

		internal PowerModeManager(DataManager dm)
		{
			this.dm = dm;

			enabled = dm.GetPref<bool>("pmm_enabled", enabled);
		}


		internal string GetCurrentPowerModeName()
		{
			PowerGetEffectiveOverlayScheme(out Guid guid);
			if (guid == PowerMode.BetterBattery) return "Best power efficiency";
			else if (guid == PowerMode.BetterPerformance) return "Balanced";
			else if (guid.ToString() == "3af9B8d9-7c97-431d-ad78-34a8bfea439f") return "Balanced";
			else if (guid == PowerMode.BestPerformance) return "Best performance";
			else return "unknown";
		}

		internal void ApplyIdlePowerPlan()
		{
			ApplyPowerMode(PowerMode.BetterBattery);
		}

		internal void ApplyDefaultPowerPlan()
		{
			ApplyPowerMode(PowerMode.BetterPerformance);
		}

		void ApplyPowerMode(Guid powerMode)
		{
			if (!enabled) return;

			uint result = PowerSetActiveOverlayScheme(powerMode);

			if (result == 0)
			{
				Debug.Log("power mode set to: " + powerMode);
			}
			else
			{
				Debug.LogError("failed to set power mode to: " + powerMode);
			}

			PowerModeChangedEvent?.Invoke();
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
		private static extern uint PowerGetEffectiveOverlayScheme(out Guid EffectiveOverlayPolicyGuid);

		/// <summary>
		/// Sets the active power overlay power scheme.
		/// </summary>
		/// <param name="OverlaySchemeGuid">The identifier of the overlay power scheme.</param>
		/// <returns>Returns zero if the call was successful, and a nonzero value if the call failed.</returns>
		[DllImportAttribute("powrprof.dll", EntryPoint = "PowerSetActiveOverlayScheme")]
		private static extern uint PowerSetActiveOverlayScheme(Guid OverlaySchemeGuid);

	}
}
