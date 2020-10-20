using MaintShoppingList.Models;

using Newtonsoft.Json;

using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace MaintShoppingList
{
	public class MainModelView
	{
		private readonly MainWindow View;

		public MainModelView(MainWindow view)
		{
			View = view;
		}

		internal void SaveJson()
		{
			ObservableCollection<ShoppingList> shoppingLists =
				(ObservableCollection<ShoppingList>)View.ShoppingListsDataGrid.ItemsSource;

			bool saveJson = shoppingLists
				.Where(x => x.IsChanged)
				.Select(x => x.IsChanged)
				.FirstOrDefault();

			if (saveJson)
			{
				string JsonPath = $"{Directory.GetCurrentDirectory()}\\ShoppingList.json";
				string json = JsonConvert.SerializeObject(shoppingLists, Formatting.Indented);
				using StreamWriter stream = new StreamWriter(JsonPath);
				stream.Write(json);

				foreach (ShoppingList shoppingList in shoppingLists.Where(x => x.IsChanged))
				{
					foreach (Article article in shoppingList.Articles.Where(x => x.IsChanged))
					{
						article.IsChanged = false;
					}
			
					shoppingList.IsChanged = false;
				}
			}
		}
	}
}
