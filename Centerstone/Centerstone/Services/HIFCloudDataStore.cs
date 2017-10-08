using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Plugin.Connectivity;
using Centerstone.Models;

namespace Centerstone
{
    public class HIFCloudDataStore : IHIFDataStore<IncomeRules>
    {
        HttpClient client;
        IEnumerable<IncomeRules> items;

        public HIFCloudDataStore()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.BackendUrl}/");

            items = new List<IncomeRules>();
        }

        public async Task<IEnumerable<IncomeRules>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && CrossConnectivity.Current.IsConnected)
            {
                var json = await client.GetStringAsync($"/api/hif/incomerules");
                items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<IncomeRules>>(json));
            }

            return items;
        }

		public Task<string> GetIncomeRulesString()
		{
			return client.GetStringAsync($"/api/hif/incomerules");
		}

		public List<IncomeRules> GetIncomeRulesFromString(string json)
		{
			return JsonConvert.DeserializeObject<List<IncomeRules>>(json);
		}
    }
}
