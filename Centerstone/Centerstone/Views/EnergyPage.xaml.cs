using System;
using System.Collections.Generic;
using Centerstone.Models;
using Xamarin.Forms;

namespace Centerstone.Views
{
	public partial class EnergyPage : ContentPage
	{
		public EnergyPage (HIF hif)
		{
			InitializeComponent ();

			BindingContext = hif;

			HouseholdTypePicker.ItemsSource = HouseholdTypes.All;
			HouseholdStatusPicker.ItemsSource = HouseholdStatuses.All;
			HeatSourcesPicker.ItemsSource = HeatSources.All;
		}

		void Handle_Done (object sender, System.EventArgs e)
		{
			Navigation.PopToRootAsync (false);
		}
	}
}
