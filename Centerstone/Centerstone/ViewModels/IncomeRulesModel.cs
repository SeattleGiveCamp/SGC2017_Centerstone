using Centerstone.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Centerstone
{
    public class IncomeRulesModel : ViewModelBase
    {
        public ObservableCollection<IncomeRules> IncomeRules { get; set; }
        public Command LoadItemsCommand { get; set; }

        public IncomeRulesModel()
        {
            IncomeRules = new ObservableCollection<IncomeRules>();
            ExecuteLoadItemsCommand();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                IncomeRules.Clear();
                var items = await HIFDataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    IncomeRules.Add(item);
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
