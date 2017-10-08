using Centerstone.Helpers;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using System;

using Xamarin.Forms;
using Centerstone.Views;
using Centerstone.Models;

namespace Centerstone
{
    public partial class App : Application
    {
        public static bool UseMockDataStore = false;
        public static string BackendUrl = "http://hif-registration.azurewebsites.net";

        public App()
        {
            InitializeComponent();

            MobileCenter.Start($"android={Constants.MobileCenterAndroid};" +
                   $"uwp={Constants.MobileCenterUWP};" +
                   $"ios={Constants.MobileCenteriOS}",
                   typeof(Analytics), typeof(Crashes));

            if (UseMockDataStore)
                DependencyService.Register<MockDataStore>();
            else
                DependencyService.Register<HIFCloudDataStore>();

			//
			// Load Application
			//
			var lastPath = Settings.LastApplicationPath;
			var id = Guid.NewGuid ();
			var hif = new HIF () {
				UniqueApplicationId = id,
			};

			if (!string.IsNullOrEmpty (lastPath)) {
				var path = System.IO.Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments), lastPath);
				Console.WriteLine ("TRY READ " + path);
				if (System.IO.File.Exists (path)) {
					hif = HIF.ReadFile (path);
				}
			}

			MainPage = new NavigationPage (new HomePage (hif));
        }
    }
}
