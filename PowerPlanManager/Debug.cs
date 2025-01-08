using System;
using System.Collections.Generic;
using System.IO;

namespace PowerPlanManager
{
	class Debug
	{

		const string file = "PowerPlanManager.log";

		static string Now
		{
			get
			{
				return DateTime.Now.ToString("yyyy/MM/dd - HH:mm");
			}
		}


		public delegate void StringEventHandler(string message);

		public static StringEventHandler LogEvent;

		public static List<string> messages = new List<string>();

		public static void Log(string message)
		{
			message = Now + " [DEBUG] - " + message;
			Console.WriteLine(message);
			System.Diagnostics.Debug.WriteLine(message);
			messages.Add(message);
			if (LogEvent != null) LogEvent(message);
			Write(new string[] { message });
		}

		public static void LogError(string message)
		{
			message = Now + " [ERROR] - " + message;
			Console.WriteLine(message);
			System.Diagnostics.Debug.WriteLine(message);
			messages.Add(message);
			if (LogEvent != null) LogEvent(message);
			Write(new string[] { message });
		}

		public static void LogWarning(string message)
		{
			message = Now + " [WARNING] - " + message;
			Console.WriteLine(message);
			System.Diagnostics.Debug.WriteLine(message);
			messages.Add(message);
			if (LogEvent != null) LogEvent(message);
			Write(new string[] { message });
		}

		static void Write(string[] lines)
		{
			try
			{
				if (!File.Exists(file))
				{
					File.CreateText(file);
				}
				File.AppendAllLines(file, lines);
			}
			catch
			{
				Console.WriteLine("failed to save log");
			}
		}

		public static void ShowLog()
		{
			if (File.Exists(file))
			{
				System.Diagnostics.Process.Start(file);
			}
		}
	}
}
