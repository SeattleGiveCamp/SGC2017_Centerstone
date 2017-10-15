using System;
using System.Collections.Generic;
using Centerstone.Models;
using Centerstone.ViewModels;
using Xamarin.Forms;

namespace Centerstone.Views
{
	public partial class BasicInfoPage : ContentPage
	{
		public BasicInfoPage (HIF hif)
		{
			InitializeComponent ();

			BindingContext = new BasicInfoViewModel (hif);
		}

		void Handle_StartApplication (object sender, System.EventArgs e)
		{
			Navigation.PopToRootAsync (true);
		}
	}
}
