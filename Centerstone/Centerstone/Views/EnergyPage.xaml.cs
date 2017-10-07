using System;
using System.Collections.Generic;
using Centerstone.Models;
using Xamarin.Forms;

namespace Centerstone.Views
{
	public partial class EnergyPage : ContentPage
	{
		public Dictionary<string, HouseholdType> householdTypes = new Dictionary<string, HouseholdType>
		{
			{ "1-3 Families", HouseholdType.Family1To3 },
			{ "4+ Families", HouseholdType.Family4Plus },
			{ "Hi-rise", HouseholdType.HiRise },
			{ "Mobilehome", HouseholdType.Mobile },
			{ "RV", HouseholdType.RV },
		};

		public EnergyPage (HIF hif)
		{
			InitializeComponent ();

			BindingContext = hif;

			InitHouseholdTypeItems ();
		}

		void InitHouseholdTypeItems ()
		{
			//foreach (var name in householdTypes.Values) {
				HouseholdTypePicker.ItemsSource = new List<HouseholdType> (householdTypes.Values);
			//}
		}

		void Handle_Done (object sender, System.EventArgs e)
		{
			Navigation.PopToRootAsync (false);
		}
	}
}
