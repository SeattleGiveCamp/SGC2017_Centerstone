using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Centerstone.Models
{
	public class HIF : BaseModel
	{
		public string Zip { get; set; }

		public ObservableCollection<Person> People { get; set; } = 
			new ObservableCollection<Person> ();
		
		public IEnumerable<Person> Adults => People.Where (x => x.IsDesignatedAdult);
		public IEnumerable<Person> Children => People.Where (x => !x.IsDesignatedAdult);

		public string ContactEmail { get; set; } = "";
		public string ContactPhone { get; set; } = "";

		public decimal MonthlyHouseholdIncome { get; set; }

		public HouseholdType HouseholdType { get; set; } = HouseholdType.Family1To3;
		public HouseholdStatus HouseholdStatus { get; set; } = HouseholdStatus.OwnOrBuy;

		public bool TipsAgreedTo { get; set; }

		public HIF ()
		{
			People.Add (Person.CreateAdult ());
			People.CollectionChanged += People_CollectionChanged;
		}

		void People_CollectionChanged (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			OnPropertyChanged ("People");
		}

		public void IncreaseAdults ()
		{
			People.Add (Person.CreateAdult ());
		}

		public void DecreaseAdults ()
		{
			// Always 1 adult
			if (Adults.Count () <= 1)
				return;
			var toRemove = People.Last (x => x.IsDesignatedAdult);
			People.Remove (toRemove);
		}

		public void IncreaseChildren ()
		{
			People.Add (Person.CreateChild ());
		}

		public void DecreaseChildren ()
		{
			var toRemove = People.LastOrDefault ();
			if (toRemove != null)
				People.Remove (toRemove);
		}
	}
}
