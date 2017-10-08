using System;
using System.Collections.ObjectModel;

namespace Centerstone.Models
{
	public class Person : BaseModel
	{
        public string FullName { get; set; }
		public bool IsDesignatedAdult { get; set; }
		public DateTime DateOfBirth { get; set; }

		public Image SocialSecurityImage { get; set; }

		public ObservableCollection<IncomeSource> IncomeSources { get; set; } =
			new ObservableCollection<IncomeSource> ();

		public CensusData CensusData { get; set; } = new CensusData ();

		public Person ()
		{
            CensusData.PropertyChanged += (s, e) => OnPropertyChanged("CensusData");
		}

		public static Person CreateChild ()
		{
			return new Person (); 
		}

		public static Person CreateAdult ()
		{
			return new Person () {
				IsDesignatedAdult = true,
			};
		}
	}
}
