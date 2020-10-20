using Newtonsoft.Json;

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace MaintShoppingList.Models
{
	public class ShoppingList : INotifyPropertyChanged
	{

		#region [ Fields ]

		private DateTime date;
		private bool isComplete;
		private ObservableCollection<Article> articles = new ObservableCollection<Article>();
		private bool isChanged;

		#endregion

		#region [ Properties ]

		public DateTime Date
		{ 
			get => date; 
			set
			{
				if (date != value)
				{
					date = value;
					NotifyPropertyChanged("Date");
				}
			}
		}
		public bool IsComplete 
		{ 
			get => isComplete; 
			set
			{
				if (isComplete != value)
				{
					isComplete = value;
					NotifyPropertyChanged("IsComplete");
				}
			}
		}
		public ObservableCollection<Article> Articles 
		{ 
			get => articles; 
			set
			{
				if (articles != value)
				{
					articles = value;
					NotifyPropertyChanged("Articles");
				}
			}
		}

		[JsonIgnore]
		public int NumberArticles
		{
			get
			{
				if (Articles == null) { return -1; }
				return Articles.Count;
			}
		}
		[JsonIgnore]
		public bool IsChanged
		{
			get => isChanged || Articles
					.Where(x => x.IsChanged)
					.Select(x => x.IsChanged)
					.FirstOrDefault();
			set
			{
				isChanged = value || Articles
					.Where(x => x.IsChanged)
					.Select(x => x.IsChanged)
					.FirstOrDefault();

				if (isChanged != value)
				{
					NotifyPropertyChanged("IsChanged");
				}
			}
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
