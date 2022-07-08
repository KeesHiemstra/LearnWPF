using System.Windows;
using System.Windows.Input;

namespace MaintShoppingList
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly MainModelView MV;

		public MainWindow()
		{
			InitializeComponent();

			MV = new MainModelView(this);
		}

		#region Exit command
		private void ExitCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
		}

		private void ExitCommand_Execute(object sender, ExecutedRoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}
		#endregion

		/// <summary>
		/// Save the articles in json file.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		#region Save command
		private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
		}

		private void SaveCommand_Execute(object sender, ExecutedRoutedEventArgs e)
		{
			MV.SaveJson();
		}
		#endregion

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			MV.SaveJson();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			ShoppingListsDataGrid.ScrollIntoView(
				ShoppingListsDataGrid.Items[ShoppingListsDataGrid.Items.Count - 1]);
			ShoppingListsDataGrid.SelectedItem = 
				ShoppingListsDataGrid.Items[ShoppingListsDataGrid.Items.Count - 1];
		}
	}
}
