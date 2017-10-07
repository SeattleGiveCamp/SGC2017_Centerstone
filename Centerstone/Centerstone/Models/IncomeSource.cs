using System;
using System.Collections.ObjectModel;

namespace Centerstone.Models
{
	public class IncomeSource
	{
		public IncomeSourceType IncomeSourceType { get; set; }

		public ObservableCollection<Image> Image { get; set; }
	}
}
