using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Centerstone.Models;
using Xamarin.Forms;

namespace Centerstone.Views
{
	public partial class HifImagesPickerView : ContentView
	{
		ObservableCollection<HifImage> images;

		public ObservableCollection<HifImage> Images {
			get {
				return images;
			}
			set {
				images = value;
			}
		}

		public HifImagesPickerView ()
		{
			InitializeComponent ();
		}

		void CreateUI ()
		{
			//var addButton = new ImageButton ();
			//ImageList.Children.Clear ();
			//ImageList.Children.Add (addButton);
		}
	}
}
