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

			HIF hif = new HIF ();

            MobileCenter.Start($"android={Constants.MobileCenterAndroid};" +
                   $"uwp={Constants.MobileCenterUWP};" +
                   $"ios={Constants.MobileCenteriOS}",
                   typeof(Analytics), typeof(Crashes));


            if (UseMockDataStore)
                DependencyService.Register<MockDataStore>();
            else
                DependencyService.Register<HIFCloudDataStore>();

			MainPage = new NavigationPage (new HomePage (hif));
        }
    }
}
