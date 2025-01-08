using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPlanManager
{
	static class Program
	{

		// https://stackoverflow.com/questions/56220823/retrieve-state-of-windows-10-power-mode-slider
		// https://old.reddit.com/r/ZephyrusG14/comments/gho535/important_update_to_properly_disable_boosting/

		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			//Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(true);
			
			Debug.Log(" ====================== started");

			SelfInstaller si = new SelfInstaller();
			DataManager dm = new DataManager(si);
			PowerModeManager pmm = new PowerModeManager(dm);
			PowerPlanManager ppm = new PowerPlanManager(dm);
			if (!ppm.IsInstalled())
			{
				if (ppm.AskToInstall())
				{
					ppm.Install();
				}
				else
				{
					return;
				}
			}

#if !DEBUG
			if (!si.IsInstalled() && si.AskToInstall())
			{
				si.Install();
				Application.Exit();
				return;
			}
#endif

			// init idle
			IdleManager im = new IdleManager(dm, ppm, pmm);

			// start tray icon
			ControlContainer container = new ControlContainer();
			TrayIconManager nm = new TrayIconManager(si, container, ppm, pmm, im, dm);
#if DEBUG
			nm.ShowForm();
#endif

			// run message pump
			Application.Run();
		}

	}
}
