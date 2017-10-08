using System;
using Centerstone.Models;
using Xamarin.Forms;

namespace Centerstone.Views
{
	public class HifImageView : Image
	{
		public static BindableProperty HifImageProperty =
			BindableProperty.Create ("HifImageProperty", typeof (HifImage), typeof (HifImageView), null);

		public HifImageView ()
		{
		}

		public HifImage HifImage {
			get => (HifImage)GetValue (HifImageProperty);
			set => SetValue (HifImageProperty, value);
		}

		protected override void OnPropertyChanged (string propertyName = null)
		{
			base.OnPropertyChanged (propertyName);
			if (propertyName == "HifImageProperty") {
				Source = GetImage ();
			}
		}

		ImageSource GetImage ()
		{
			if (HifImage == null)
				return null;
			
			return new FileImageSource () {
				File = HifImage.Path,
			};
		}
	}
}
