using SignaturePad.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;

namespace Centerstone.Views
{
	public partial class TipsPage : ContentPage
	{
		public TipsPage ()
		{
			InitializeComponent ();
            signature.StrokeCompleted += (sender, e) =>
            {
                ButtonAccept.IsEnabled = !signature.IsBlank;
            };
        }

        async void Handle_AcceptSignature(object sender, System.EventArgs e)
        {
			if (signature.IsBlank == false) {
				// export the signature bitmap
				var stream = await signature.GetImageStreamAsync (SignatureImageFormat.Png);

				if (stream != null) {
					using (var memStream = new MemoryStream ()) {
						stream.CopyTo (memStream);
						byte[] bytesOfSignature = memStream.ToArray ();

						//TODO: these bytes need to be stored in some model.
					}
				}
				await Navigation.PopToRootAsync (false);
			}
			else {
				DisplayAlert ("Please sign", "A signature is needed as proof that you read these tips.", "OK");
			}
        }
        
    }
}
