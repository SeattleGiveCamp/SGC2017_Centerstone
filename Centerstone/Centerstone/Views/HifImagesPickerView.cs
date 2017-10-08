using System;
using System.Collections.ObjectModel;
using Centerstone.Models;
using Xamarin.Forms;

namespace Centerstone.Views
{
	public class HifImagesPickerView : StackLayout
	{
		public static BindableProperty ImagesProperty =
			BindableProperty.Create("Images", typeof(ObservableCollection<HifImage>), typeof(HifImagesPickerView), null);

		public ObservableCollection<HifImage> Images
		{
			get => (ObservableCollection<HifImage>)GetValue(ImagesProperty);
			set {
				SetValue(ImagesProperty, value);
				if (value != null) CreateUI();
			}
		}

		public HifImagesPickerView()
		{
		}

		void CreateUI()
		{
			Children.Clear();
			var ib = new ImageButton();
			ib.ImageTaken += Ib_ImageTaken;;
			Children.Add(ib);
		}

		void Ib_ImageTaken(Models.HifImage image)
		{
		}
	}
}
