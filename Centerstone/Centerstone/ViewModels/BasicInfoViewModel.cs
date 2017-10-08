using System;
using System.Linq;
using System.Windows.Input;
using Centerstone.Models;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Centerstone.ViewModels
{
	public class BasicInfoViewModel : ViewModelBase
	{
		public HIF HIF { get; set; }
        public ObservableCollection<IncomeRules> rules { get; set; }
        public int NumberOfAdults => HIF.Adults.Count ();

		public int NumberOfChildren => HIF.Children.Count ();
        public int NumberOfPeople => HIF.People.Count();

        public decimal MinimumIncome { get; set; }

		public string MinimumIncomeText => MinimumIncome.ToString ();

		public ICommand IncreaseAdults { get; }
		public ICommand DecreaseAdults { get; }
		public ICommand IncreaseChildren { get; }
		public ICommand DecreaseChildren { get; }

		public BasicInfoViewModel (HIF hif)
		{
			HIF = hif;
            rules = new ObservableCollection<IncomeRules>();
            Task.Run(() => ExecuteLoadItemsCommand()).Wait();

            HIF.PropertyChanged += (sender, e) => {
				OnPropertyChanged ("HIF");
				OnPropertyChanged ("NumberOfAdults");
				OnPropertyChanged ("NumberOfChildren");
				OnPropertyChanged ("MinimumIncome");
                CalculateMaxIncomeAsync(hif.People.Count);
            };

			IncreaseAdults = new Command (HIF.IncreaseAdults);
			DecreaseAdults = new Command (HIF.DecreaseAdults);
			IncreaseChildren = new Command (HIF.IncreaseChildren);
			DecreaseChildren = new Command (HIF.DecreaseChildren);
		}

        public void CalculateMaxIncomeAsync(int maxHousedSize)
        {
            if (maxHousedSize > 0) {
                var foundIncomeRule = rules.FirstOrDefault(x => x.HouseholdSize == maxHousedSize);
                if (foundIncomeRule != null)
                {
                    MinimumIncome = foundIncomeRule.MaxIncome;
                }
            }            
        }

        public async Task GetAllIncomeRules()
        {        
            var items = await HIFDataStore.GetItemsAsync(true);
            foreach (var item in items)
            {
                rules.Add(item);
            }
        }


        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                rules.Clear();
                var items = await HIFDataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    rules.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
