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
                var stream = await signature.GetImageStreamAsync(SignatureImageFormat.Png);

                if (stream != null)
                {
                    using (var memStream = new MemoryStream())
                    {
                        stream.CopyTo(memStream);
                        byte[] bytesOfSignature = memStream.ToArray();
                        //TODO: these bytes need to be stored in some model.
                        //Person.NoIncomeSingurate
                    }
                }
                await Navigation.PopToRootAsync(false);
            }
        }

    }
}
