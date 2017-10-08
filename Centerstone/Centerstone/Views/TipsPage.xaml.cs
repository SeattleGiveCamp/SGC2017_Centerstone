using SignaturePad.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;
using Centerstone.Models;

namespace Centerstone.Views
{
	public partial class TipsPage : ContentPage
	{
		readonly HIF hif;

		public TipsPage (HIF hif)
		{
			this.hif = hif;
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
				using (var stream = await signature.GetImageStreamAsync(SignatureImageFormat.Png))
				{
					hif.TipsSignature?.Delete(); 
					hif.TipsSignature = HifImage.FromPngStream(stream);
				}
				await Navigation.PopToRootAsync (true);
			}
			else {
				await DisplayAlert ("Please sign", "A signature is needed as proof that you read these tips.", "OK");
			}
        }
        
    }
}
