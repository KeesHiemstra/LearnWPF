using Newtonsoft.Json;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace MaintShoppingList.Models
{
	public class Data : INotifyPropertyChanged
	{
		public ObservableCollection<ShoppingList> ShoppingLists { get; set; }

		public Data()
		{
			LoadShoppingList();
		}

		public event PropertyChangedEventHandler PropertyChanged;
		private void NotifyPropertyChanged(string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		/// <summary>
		/// Load the ShoppingList.json with reserved order on `Date` property 
		/// when the class Data is created.
		/// </summary>
		private void LoadShoppingList()
		{
			List<ShoppingList> shoppingLists = new List<ShoppingList>();

			string JsonPath = $"{Directory.GetCurrentDirectory()}\\ShoppingList.json";

			if (File.Exists(JsonPath))
			{
				using StreamReader stream = File.OpenText(JsonPath);
				string json = stream.ReadToEnd();
				shoppingLists = JsonConvert.DeserializeObject<List<ShoppingList>>(json);
			}

			ShoppingLists = new ObservableCollection<ShoppingList>(shoppingLists
				.OrderByDescending(x => x.Date)
				.ToList());
		}

	}
}
