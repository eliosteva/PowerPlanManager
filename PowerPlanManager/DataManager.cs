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
	internal class DataManager
	{

		const string dataFileName = "PowerPlanManager.xml";
		string dataFilePath = "";

		SelfInstaller si;
		
		Dictionary<string, string> prefs = new Dictionary<string, string>();


		internal DataManager(SelfInstaller si)
		{
			this.si = si;

			Debug.Log("initializing data manager");

			//dataFilePath = Path.Combine(si.AppDataDirPath, dataFileName);
			dataFilePath = dataFileName;

			// load prefs
			LoadPrefs();
		}

		void LoadPrefs()
		{
			prefs.Clear();
			try
			{
				if (File.Exists(dataFilePath))
				{
					var lines = File.ReadAllLines(dataFilePath);
					foreach (var line in lines)
					{
						string[] split = line.Split('=');
						prefs.Add(split[0], split[1]);
					}
				}
				else Debug.LogWarning("pref file not found: " + dataFilePath);
			}
			catch(Exception ex)
			{
				Debug.LogError("failed to read prefs: " + ex.ToString());
				prefs.Clear();
			}
		}

		public void SetPref(string key, string value)
		{
			if (!prefs.ContainsKey(key)) prefs.Add(key, value);
			else prefs[key] = value;

			SavePrefs();
		}

		public string GetPref(string key)
		{
			return prefs.ContainsKey(key) ? prefs[key] : "";
		}

		public T GetPref<T>(string key, T def)
		{
			return prefs.ContainsKey(key) ? (T)Convert.ChangeType(prefs[key], typeof(T)) : def;
		}

		void SavePrefs()
		{
			string s = "";
			foreach(var v in prefs)
			{
				s += v.Key + "=" + v.Value + "\n";
			}
			s = s.Trim();

			if (!Directory.Exists(si.AppDataDirPath)) Directory.CreateDirectory(si.AppDataDirPath);
			File.WriteAllText(dataFilePath, s);
		}
	}
}
