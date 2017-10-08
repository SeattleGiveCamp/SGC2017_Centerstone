using Centerstone.Helpers;
using System;
using System.Collections.ObjectModel;

namespace Centerstone.Models
{
	public class IncomeSource
	{
		public string IncomeSourceType { get; set; }

		public ObservableCollection<HifImage> Image { get; set; }
        public string[] IncomeSourceOptions => IncomeSources.All;

    }
}
