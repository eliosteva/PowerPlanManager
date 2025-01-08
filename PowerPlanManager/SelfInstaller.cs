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

namespace PowerPlanManager
{
	internal class SelfInstaller
	{

		const string programName = "PowerPlanManager";
		const string companyName = "ElioSoft";
		//const string logFileName = "log.xml";

		string currentAppDirPath;
		string currentAppPath;
		string currentExePath;

		string targetAppDirPath;
		string targetAppPath;
		string targetExePath;

		public string AppDataDirPath => targetAppDirPath;
		
		internal SelfInstaller()
		{
			string appName = Path.GetFileNameWithoutExtension(Application.ExecutablePath);
			currentAppPath = Application.ExecutablePath.Replace(Path.GetExtension(Application.ExecutablePath), "");
			currentAppDirPath = Path.GetDirectoryName(currentAppPath);
			currentExePath = currentAppPath + ".exe";

			targetAppDirPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), companyName);
			targetAppPath = Path.Combine(targetAppDirPath, appName);
			targetExePath = targetAppPath + ".exe";

		}

		internal bool IsAutostarting()
		{
			Debug.Log("checking autostart registry key");
			RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
			if (rk != null)
			{
				string value = rk.GetValue(programName) as string;
				if (!string.IsNullOrEmpty(value))
				{
					if (value.Equals(targetExePath)) return true;
				}
			}
			return false;
		}

		internal void SetAutoStart(bool value)
		{
			Debug.Log("setting autostart registry key to " + value);
			RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
			if (rk != null)
			{
				rk.SetValue(programName, targetExePath);
			}
		}

		internal bool IsInstalled()
		{
			Debug.Log("checking if app is installed");

			// check current dir
			if (currentExePath != targetExePath)
			{
				return false;
			}
			else
			{
				return true;
			}

			// check dir
			//if (currentAppDirPath == targetAppDirPath)
			//{
			//	check registry
			//	using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run"))
			//	{
			//		string value = (string)registryKey.GetValue(programName);
			//		if (!string.IsNullOrEmpty(value) && value == targetExePath)
			//		{
			//			Debug.Log("app is installed (value is: " + value + ")");
			//			return true;
			//		}
			//		else
			//		{
			//			Debug.Log("app is not installed (value is: " + value + ")");
			//			return false;
			//		}
			//	}
			//}
			//else
			//{
			//	Debug.Log("app was not started from install location\ncurrent dir: " + currentAppDirPath + "\ninstall dir: " + targetAppDirPath);
			//	return false;
			//}
		}

		internal bool AskToInstall()
		{
			DialogResult dr = MessageBox.Show("Application not installed. Would you like to install?\nApp will be copied to AppData\\Local and will restart", "", MessageBoxButtons.YesNo);
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
			try
			{
				// check appdata directory
				Debug.Log("installing...");
				if (!Directory.Exists(targetAppDirPath))
				{
					Debug.Log("creating installation directory at: " + targetAppDirPath);
					Directory.CreateDirectory(targetAppDirPath);
				}

				// check if file exist
				if (File.Exists(targetExePath))
				{
					DialogResult dr = MessageBox.Show("File already exists. Overwrite?", "", MessageBoxButtons.YesNo);
					if (dr == System.Windows.Forms.DialogResult.No)
					{
						return;
					}

					// check if file is executing
					Process[] runningProcesses = Process.GetProcesses();
					foreach (Process process in runningProcesses)
					{
						try
						{
							// now check the modules of the process
							foreach (ProcessModule module in process.Modules)
							{
								// if is target path
								if (module.FileName.Equals(targetExePath))
								{
									// kill
									process.Kill();
								}
							}
						}
						catch(System.ComponentModel.Win32Exception ex)
						{
							//Debug.LogError(ex.ToString());
						}
						catch (Exception ex)
						{
							Debug.LogError(ex.ToString());
						}
					}
				}

				// copy executable to localAppData
				Debug.Log("copying file to: " + targetAppPath);
				File.Copy(currentExePath, targetExePath, true);
				//File.Copy(currentAppPath + ".dll", targetAppPath + ".dll", true);
				//File.Copy(currentAppPath + ".runtimeconfig.json", targetAppPath + ".runtimeconfig.json", true);

				// launch via CMD
				Process myProcess = Process.Start(new ProcessStartInfo { Arguments = "/C " + targetExePath, FileName = "cmd", WindowStyle = ProcessWindowStyle.Hidden });
		
				
				//// start other copy with new working dir
				//Debug.Log("starting new copy");
				//ProcessStartInfo psi = new ProcessStartInfo();
				//psi.UseShellExecute = true;
				//psi.WorkingDirectory = targetAppDirPath;
				//psi.FileName = targetExePath;
				//Process myProcess = Process.Start(psi);
				////if (myProcess.ExitCode != 0)
				////{
				////	Debug.Log(myProcess.ExitCode.ToString());
				////	throw new Exception();
				////}
				
			}
			catch (Exception ex)
			{
				Debug.LogError("failed to install: " + ex.ToString());
			}
		}

	}
}
