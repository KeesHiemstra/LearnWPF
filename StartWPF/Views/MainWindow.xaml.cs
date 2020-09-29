using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StartWPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public bool Interactive = false;
		private DateTime ShowDate = DateTime.Now.Date.AddDays(-1);

		public MainWindow(string[] args)
		{
			foreach (string arg in args)
			{
				DateTime showDate;
				if (arg.ToLower() == "interactive") { Interactive = true; }
				if (DateTime.TryParse(arg, out showDate)) { ShowDate = showDate; }
			}

			MessageBox.Show(ShowDate.ToString("yyyy-MM-dd"));

			InitializeComponent();

			if (!Interactive) { Close(); }
		}
	}
}
