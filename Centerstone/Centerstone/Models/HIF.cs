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
		
		public IEnumerable<Person> Adults => People.Where (x => x.DesignatedAdult);
		public IEnumerable<Person> Children => People.Where (x => !x.DesignatedAdult);

		public string ContactEmail { get; set; } = "";
		public string ContactPhone { get; set; } = "";

		public decimal MonthlyHouseholdIncome { get; set; }

		public HouseholdType HouseholdType { get; set; } = HouseholdType.Family1To3;
		public HouseholdStatus HouseholdStatus { get; set; } = HouseholdStatus.OwnOrBuy;

		public bool TipsAgreedTo { get; set; }

		public HIF ()
		{
			People.CollectionChanged += People_CollectionChanged;
		}

		void People_CollectionChanged (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			OnPropertyChanged ("People");
		}
	}
}
