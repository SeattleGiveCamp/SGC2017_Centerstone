using System;
using System.Linq;
using System.Windows.Input;
using Centerstone.Models;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Centerstone.ViewModels
{
	public class BasicInfoViewModel : ViewModelBase
	{
		public HIF HIF { get; set; }
		public static List<IncomeRules> IncomeRules { get; private set; }
        public int NumberOfAdults => HIF.Adults.Count ();

		public int NumberOfChildren => HIF.Children.Count ();
        public int NumberOfPeople => HIF.People.Count();

		public ICommand IncreaseAdults { get; }
		public ICommand DecreaseAdults { get; }
		public ICommand IncreaseChildren { get; }
		public ICommand DecreaseChildren { get; }

		static BasicInfoViewModel()
		{
			string j = null;
			var localPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "incomerule.json");
			if (File.Exists(localPath) && new FileInfo(localPath).Length > 200)
			{
				try
				{
					j = File.ReadAllText(localPath);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex);
				}
			}
			if (string.IsNullOrEmpty(j))
			{
				var assembly = Assembly.GetExecutingAssembly();
				var names = assembly.GetManifestResourceNames();
				var resName = "Centerstone.iOS.Data.incomerule.json";
				if (!names.Contains(resName))
				{
					resName = "Centerstone.Droid.Data.incomerule.json";
				}

				using (Stream stream = assembly.GetManifestResourceStream(resName))
				{
					using (StreamReader r = new StreamReader(stream))
					{
						j = r.ReadToEnd();
					}
				}
			}

			var dataStore = new HIFCloudDataStore();

			IncomeRules = new List<Models.IncomeRules>();
			try
			{
				IncomeRules = dataStore.GetIncomeRulesFromString(j);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}

			//
			// Refresh from the web
			//
			Task.Run(async () =>
			{
				try
				{
					var j2 = await dataStore.GetIncomeRulesString();
					File.WriteAllText(localPath, j2);
					IncomeRules = dataStore.GetIncomeRulesFromString(j2);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex);
				}
			});
		}

		public BasicInfoViewModel (HIF hif)
		{
			HIF = hif;

			CalculateMaxIncome(hif.People.Count);

            HIF.PropertyChanged += (sender, e) => {
				OnPropertyChanged ("HIF");
				OnPropertyChanged ("NumberOfAdults");
				OnPropertyChanged ("NumberOfChildren");
				OnPropertyChanged ("MinimumIncome");
                CalculateMaxIncome(hif.People.Count);
            };

			IncreaseAdults = new Command (HIF.IncreaseAdults);
			DecreaseAdults = new Command (HIF.DecreaseAdults);
			IncreaseChildren = new Command (HIF.IncreaseChildren);
			DecreaseChildren = new Command (HIF.DecreaseChildren);
		}

		public void CalculateMaxIncome(int maxHousedSize)
        {
            if (maxHousedSize > 0) {
				var foundIncomeRule = IncomeRules.FirstOrDefault(x => x.HouseholdSize == maxHousedSize);
                if (foundIncomeRule != null)
                {
					HIF.MaximumIncome = foundIncomeRule.MaxIncome;
                }
            }            
        }
    }
}
