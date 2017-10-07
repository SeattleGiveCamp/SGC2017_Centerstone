using System;
using System.Collections.Generic;
using System.Linq;

namespace Centerstone.Models
{
	public class HIF
	{
		public string Zip { get; set; }

		public System.Collections.ObjectModel.ObservableCollection<Person> People { get; set; }
		public IEnumerable<Person> Adults => People.Where (x => x.DesignatedAdult);
		public IEnumerable<Person> Children => People.Where (x => !x.DesignatedAdult);

		string ContactEmail;
		string ContactPhone;

		public decimal MonthlyHouseholdIncome { get; set; }

		HouseholdType HouseholdType;
		string HouseholdStatus;

		public HIF ()
		{
		}
	}
}
