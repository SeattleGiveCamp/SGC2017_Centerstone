using Centerstone.Models;
using SignaturePad.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;

namespace Centerstone.Views
{
    public partial class NoIncomePage : ContentPage
    {
        readonly HIF hif;
        public Person Person { get; set; }
        public NoIncomePage(HIF hif, Person person)
        {
            InitializeComponent();
            BindingContext = person;
            signature.StrokeCompleted += (sender, e) =>
            {
                ButtonAccept.IsEnabled = !signature.IsBlank;
            };
        }

        async void Handle_AcceptSignature(object sender, EventArgs e)
        {
            if (signature.IsBlank == false)
            {
				// export the signature bitmap
				using (var stream = await signature.GetImageStreamAsync(SignatureImageFormat.Png))
				{
					Person.NoIncomeSingurate?.Delete();
					Person.NoIncomeSingurate = HifImage.FromPngStream(stream);
				}
				await Navigation.PopToRootAsync(true);
            }
        }
	}
}
