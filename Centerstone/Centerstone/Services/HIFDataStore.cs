using Centerstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centerstone
{
    public class HIFDataStore : IHIFDataStore<IncomeRules>
    {
        List<IncomeRules> incomeRules;

        public HIFDataStore()
        {
            incomeRules = new List<IncomeRules>();
            var mockItems = new List<IncomeRules>
            {
                new IncomeRules { RowId = 1, HouseholdSize = 2, MaxIncome = 12.2m, HouseholdAdjust = 0.1m },
                new IncomeRules { RowId = 1, HouseholdSize = 2, MaxIncome = 12.2m, HouseholdAdjust = 0.1m },
                new IncomeRules { RowId = 1, HouseholdSize = 2, MaxIncome = 12.2m, HouseholdAdjust = 0.1m },
            };

            foreach (var item in mockItems)
            {
                incomeRules.Add(item);
            }
        }


        public async Task<IncomeRules> GetItemAsync(int householdSize)
        {
            return await Task.FromResult(incomeRules.FirstOrDefault(s => s.HouseholdSize == householdSize));
        }

        public async Task<IEnumerable<IncomeRules>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(incomeRules);
        }
    }
}
