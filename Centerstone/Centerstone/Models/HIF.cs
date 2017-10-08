using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Centerstone.Helpers;

namespace Centerstone.Models
{
    public class Temp
    {
        public string Name { get; set; }
        public bool Value { get; set; } = false;
        public Temp(string name)
        {
            Name = name;
        }
    }
    public class HIF : BaseModel
    {
        public Guid UniqueApplicationId { get; set; }

        public string Zip { get; set; }
        public Temp[] HeatSourcesTypes => Helpers.HeatSources.All.Select(x => new Temp(x)).ToArray();
        public ObservableCollection<IncomeSource> HeatSourcess { get; set; } =
        new ObservableCollection<IncomeSource>();

		public ObservableCollection<Person> People { get; set; } =
            new ObservableCollection<Person> ();
		
		public IEnumerable<Person> Adults => People.Where (x => x.IsDesignatedAdult);
		public IEnumerable<Person> Children => People.Where (x => !x.IsDesignatedAdult);

		string contactEmail = "";
		public string ContactEmail { get { return contactEmail; } set { SetProperty (ref contactEmail, value); } }

		string contactPhone = "";
		public string ContactPhone { get { return contactPhone; } set { SetProperty (ref contactPhone, value); } }

		decimal monthlyHouseholdIncome;
		public decimal MonthlyHouseholdIncome {
			get => monthlyHouseholdIncome;
			set => SetProperty (ref monthlyHouseholdIncome, value);
		}

		string householdType = "";
		public string HouseholdType { get { return householdType; } set { SetProperty (ref householdType, value); } }

		string householdStatus = "";
		public string HouseholdStatus { get { return householdStatus; } set { SetProperty (ref householdStatus, value); } }

		public ObservableCollection<string> HeatSources { get; set; } =
			new ObservableCollection<string> ();
		public ObservableCollection<HifImage> HeatImages { get; set; } =
			new ObservableCollection<HifImage> ();
		public ObservableCollection<HifImage> LeaseImages { get; set; } =
			new ObservableCollection<HifImage> ();

		public HifImage TipsSignatuure { get; set; }

		public HIF ()
		{
			UniqueApplicationId = Guid.NewGuid ();
			People.Add (Person.CreateAdult ());
			People.CollectionChanged += People_CollectionChanged;
		}

		void People_CollectionChanged (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			OnPropertyChanged ("People");
			OnPropertyChanged ("Adults");
			OnPropertyChanged ("Children");
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
			var toRemove = Children.LastOrDefault ();
			if (toRemove != null)
				People.Remove (toRemove);
		}
	}
}
