using System;
using System.Collections.Generic;
using Centerstone.Models;
using Xamarin.Forms;

namespace Centerstone.Views
{
	public partial class PeoplePage : ContentPage
	{
		readonly HIF hif;

		public PeoplePage (HIF hif)
		{
			this.hif = hif;
			InitializeComponent ();

			BindingContext = hif;
		}

		async void OnItemSelected (object sender, SelectedItemChangedEventArgs args)
		{
			var item = args.SelectedItem as Person;
			if (item == null)
				return;

			await Navigation.PushAsync (new PersonPage (hif, item));

			// Manually deselect item
			PeopleListView.SelectedItem = null;
		}
	}
}
