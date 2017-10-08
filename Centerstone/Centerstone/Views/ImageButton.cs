using System;
using Centerstone.Models;
using Plugin.Media;
using Xamarin.Forms;

namespace Centerstone.Views
{
	public class ImageButton : Button
	{
		public event ImageTakenEventHandler ImageTaken;

		public ImageButton ()
		{
			Text = "Take a Picture!";
			Clicked += Handle_Click;
		}

		async void Handle_Click (object sender, EventArgs e)
		{
			if (!CrossMedia.Current.IsTakePhotoSupported) {
				return;
			}
			var imageMediaFile = await CrossMedia.Current.TakePhotoAsync (new Plugin.Media.Abstractions.StoreCameraMediaOptions () {
				MaxWidthHeight = 2048,
			});
			Console.WriteLine ("IMAGE " + imageMediaFile.Path);
			var i = new HifImage {
				Id = Guid.NewGuid (),
				Path = imageMediaFile.Path,
			};
			ImageTaken?.Invoke (i);
		}
	}

	public delegate void ImageTakenEventHandler (HifImage image);
}

