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

		// https://learn.microsoft.com/en-us/windows-hardware/design/device-experiences/display--sleep--and-hibernate-idle-timers

		// query: powercfg /Q

		// https://www.codeproject.com/Tips/480049/Shut-Down-Restart-Log-off-Lock-Hibernate-or-Sleep

		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			//Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(true);

			Debug.Initialize();
			Debug.Log(" ====================== started");

			SelfInstaller si = new SelfInstaller();
			DataManager dm = new DataManager(si);
			PowerModeManager pmm = new PowerModeManager(dm);
			PowerPlanManager ppm = new PowerPlanManager(dm);
			bool showForm = false;
#if DEBUG
			showForm = true;
#endif

			// application must be installed
			if (!si.Initialize())
			{
				return;
			}

			// initialize power plans
			if (!ppm.Initialize())
			{
				showForm = true;
			}

			// init idle
			IdleManager im = new IdleManager(dm, ppm, pmm);

			// start tray icon
			ControlContainer container = new ControlContainer();
			TrayIconManager nm = new TrayIconManager(si, container, ppm, pmm, im, dm);

			if (showForm) nm.ShowForm();

			// run message pump
			Application.Run();
		}

	}
}
