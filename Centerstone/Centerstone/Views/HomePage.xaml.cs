using System;
using System.Collections.Generic;
using Centerstone.Helpers;
using Centerstone.Models;
using Xamarin.Forms;

namespace Centerstone.Views
{
	public partial class HomePage : ContentPage
	{
		HIF hif;

		public HomePage (HIF hif)
		{
			this.hif = hif;
			InitializeComponent ();
			BindingContext = hif;
		}

		void Handle_BasicInfoClicked (object sender, System.EventArgs e)
		{
			Navigation.PushAsync (new BasicInfoPage (hif));
		}

		void Handle_EnergyClicked (object sender, System.EventArgs e)
		{
			Navigation.PushAsync (new EnergyPage (hif));
		}

		void Handle_PeopleClicked (object sender, System.EventArgs e)
		{
			Navigation.PushAsync (new PeoplePage (hif));
		}

		void Handle_ImagesClicked (object sender, System.EventArgs e)
		{
			Navigation.PushAsync (new ImagesPage ());
		}

		void Handle_TipsClicked (object sender, System.EventArgs e)
		{
			Navigation.PushAsync (new TipsPage ());
		}

        //void Handle_IncomesClicked(object sender, System.EventArgs e)
        //{
        //    Navigation.PushAsync(new NoIncomePage(hif));
        //}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			try {
				hif.WriteFile ();
				Settings.LastApplicationPath = hif.UniqueApplicationId.ToString ("N");
			}
			catch (Exception ex) {
				Console.WriteLine (ex);
			}
		}

		public async void Handle_StartOver(object sender, EventArgs e)
		{
			var cont = await DisplayAlert("Delete Current Application?", "A new application will be blank and you will have to enter all your information again.", "Start Over", "Cancel");
			if (!cont)
				return;

			var newHif = HIF.CreateNew();
			hif.Delete();
			hif = newHif;
			BindingContext = newHif;
		}
	}
}
