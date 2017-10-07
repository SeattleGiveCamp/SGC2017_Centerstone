using System;
using System.Collections.ObjectModel;

namespace Centerstone.Models
{
	public class Person
	{
		public bool DesignatedAdult { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }

		public Image SocialSecurityImage { get; set; }

		public ObservableCollection<IncomeSource> IncomeSources { get; set; } =
			new ObservableCollection<IncomeSource> ();

		public CensusData CensusData { get; set; } = new CensusData ();

		public Person ()
		{
		}
	}
}
