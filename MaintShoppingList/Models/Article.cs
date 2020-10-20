using Newtonsoft.Json;

using System.ComponentModel;

namespace MaintShoppingList.Models
{
	public class Article : INotifyPropertyChanged
	{
		#region [ Fields ]

		private string name;
		private int number;
		private bool isAdvertisement;

		#endregion

		#region [ Properties ]

		public string Name
		{
			get => name;
			set
			{
				if (name != value)
				{
					name = value;
					NotifyPropertyChanged("Name");
				}
			}
		}
		public int Number 
		{ 
			get => number; 
			set
			{
				if (number != value)
				{
					number = value;
					NotifyPropertyChanged("Number");
				}
			}
		}
		public bool IsAdvertisement 
		{ 
			get => isAdvertisement; 
			set
			{
				if (isAdvertisement != value)
				{
					isAdvertisement = value;
					NotifyPropertyChanged("IsAdvertisement");
				}
			}
		}

		[JsonIgnore]
		public bool IsChanged { get; set; }

		#endregion

		#region [ Constructions ]

		/// <summary>
		/// Set the defaults.
		/// </summary>
		public Article()
		{
			Number = 1;
		}

		#endregion

		#region [ Notification ]

		public event PropertyChangedEventHandler PropertyChanged;
		private void NotifyPropertyChanged(string propertyName = "")
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
				if (propertyName != "IsChanged") { IsChanged = true; }
			}
		}

		#endregion
	}
}
