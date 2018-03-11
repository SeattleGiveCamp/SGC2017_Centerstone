using System;
using System.Collections.Generic;
using Centerstone.Models;
using Centerstone.ViewModels;
using Xamarin.Forms;

namespace Centerstone.Views
{
	public partial class BasicInfoPage : ContentPage
	{
        private BasicInfoViewModel viewModel;

        public BasicInfoPage (HIF hif)
		{
			InitializeComponent ();
            viewModel = new BasicInfoViewModel(hif);
            BindingContext = viewModel;
		}

		void Handle_StartApplication (object sender, System.EventArgs e)
		{
			Navigation.PopToRootAsync (true);
		}

        void Handle_SameAddress(object sender, System.EventArgs e)
        {
            viewModel.HIF.MailingStreetAddress = viewModel.HIF.LiveStreetAddress;
            viewModel.HIF.MailingCity = viewModel.HIF.LiveCity;
            viewModel.HIF.MailingState = viewModel.HIF.LiveState;
            viewModel.HIF.MailingZipCode = viewModel.HIF.LiveZipCode;
        }
    }
}
