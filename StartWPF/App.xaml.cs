using CHi.Log;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace StartWPF
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private void Application_Startup(object sender, StartupEventArgs e)
		{
			if (e.Args.Length > 0)
			{
				string args = string.Empty;
				foreach (string arg in e.Args) { args += "|" + arg; }
				Log.Write($"Arguments: {args}");
			}
			else { Log.Write("No arguments given"); }
			MainWindow mainWindow = new MainWindow(e.Args);
			if (mainWindow.Interactive) { mainWindow.Show(); }
		}
	}
}
