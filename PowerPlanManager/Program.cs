using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPlanManager
{
	static class Program
	{

		// https://stackoverflow.com/questions/56220823/retrieve-state-of-windows-10-power-mode-slider


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

			// ask to install if not installed
			SelfInstaller si = new SelfInstaller();
//#if !DEBUG
			if (!si.IsInstalled() && si.AskToInstall())
			{
				si.Install();
				Application.Exit();
				return;
			}
//#endif

			// init data
			DataManager dm = new DataManager(si);

			// init power plans
			PowerPlanManager ppm = new PowerPlanManager(dm);
			PowerModeManager pmm = new PowerModeManager(dm);

			// init idle
			IdleManager im = new IdleManager(dm, ppm, pmm);

			// start tray icon
			ControlContainer container = new ControlContainer();
			TrayIconManager nm = new TrayIconManager(si, container, ppm, pmm, im , dm);

			// run message pump
			Application.Run();
		}

	}
}
