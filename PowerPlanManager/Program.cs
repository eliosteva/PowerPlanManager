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
			//Application.EnableVisualStyles();
			//Application.SetCompatibleTextRenderingDefault(false);
			//Application.Run(new FormPowerPlanManager());

			Debug.Log(" ====================== started");

			// ask to install if not installed
			SelfInstaller si = new SelfInstaller();
			if (!si.IsInstalled() && si.AskToInstall())
			{
				Application.Exit();
				return;
			}

			// init data
			DataManager dm = new DataManager(si);

			// init power plans
			PowerPlanManager ppm = new PowerPlanManager(dm);

			// init idle
			IdleManager im = new IdleManager(dm, ppm);

			// start tray icon
			ControlContainer container = new ControlContainer();
			TrayIconManager nm = new TrayIconManager(si, container, ppm, im , dm);

			// run message pump
			Application.Run();
		}


		
	}
}
