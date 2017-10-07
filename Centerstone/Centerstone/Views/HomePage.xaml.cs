using System;
using System.Collections.Generic;
using Centerstone.Models;
using Xamarin.Forms;

namespace Centerstone.Views
{
	public partial class HomePage : ContentPage
	{
		readonly HIF hif;

		public HomePage (HIF hif)
		{
			this.hif = hif;
			InitializeComponent ();
		}

		void Handle_BasicInfoClicked (object sender, System.EventArgs e)
		{
			Navigation.PushAsync (new BasicInfoPage (hif));
		}

		void Handle_EnergyClicked (object sender, System.EventArgs e)
		{
			Navigation.PushAsync (new EnergyPage ());
		}

		void Handle_PeopleClicked (object sender, System.EventArgs e)
		{
			Navigation.PushAsync (new PeoplePage ());
		}

		void Handle_ImagesClicked (object sender, System.EventArgs e)
		{
			Navigation.PushAsync (new ImagesPage ());
		}

		void Handle_TipsClicked (object sender, System.EventArgs e)
		{
			Navigation.PushAsync (new TipsPage ());
		}
	}
}
