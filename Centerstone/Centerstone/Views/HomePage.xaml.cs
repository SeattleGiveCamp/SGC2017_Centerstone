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
			Navigation.PushAsync (new TipsPage (hif));
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

		public async void Handle_Submit(object sender, EventArgs e)
		{
			var reasons = hif.CantSubmitReasons;
			if (reasons.Count > 0)
			{
				var m = String.Join("\n\n", reasons);
				await DisplayAlert("Cannot Submit Application", m, "OK");
				return;
			}

			var cont = await DisplayAlert("Submit Current Application?", "You can only submit an application once. Please make sure it's completely filled out before continuing to submit.", "Submit", "Cancel");
			if (!cont)
				return;

			try
			{
				var client = new System.Net.Http.HttpClient();
				client.BaseAddress = new Uri("https://hif-registration.azurewebsites.net/");

				var json = hif.ToJson();
				await client.PostAsync("/api/Hif", new System.Net.Http.StringContent(json));

				await DisplayAlert("Success!", "Your application was succesfully posted to Centerstone. You will hear back from us soon!", "OK");

				hif.Submitted = true;
				hif.SubmittedTime = DateTimeOffset.Now;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				await DisplayAlert("Failed to Communicate", ex.Message, "OK");
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
