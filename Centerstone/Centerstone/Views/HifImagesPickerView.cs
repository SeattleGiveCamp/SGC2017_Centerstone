using System;
using System.Collections.ObjectModel;
using Centerstone.Models;
using Xamarin.Forms;

namespace Centerstone.Views
{
	public class HifImagesPickerView : StackLayout
	{
        //public event ImagesTakenEventHandler ImagesTaken;

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
            Orientation = StackOrientation.Vertical;
            MinimumHeightRequest = 20;
            CreateUI();
        }

		void CreateUI()
		{
			Children.Clear();
			var ib = new ImageButton();
			ib.ImageTaken += Ib_ImageTaken;;
			Children.Add(ib);
		}

		void Ib_ImageTaken(HifImage image)
		{
            Children.Add(new Image
            {
                Source = FileImageSource.FromFile(image.Path)
                
            });
            image.byteImage = image.ConvertImageToByteArray();
            Images.Add(image);

        }
        //public delegate void ImagesTakenEventHandler(ObservableCollection<HifImage> Images);
    }
}
