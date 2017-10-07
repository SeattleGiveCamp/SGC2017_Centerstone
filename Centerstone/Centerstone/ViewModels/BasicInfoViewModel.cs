using System;
using System.Linq;
using System.Windows.Input;
using Centerstone.Models;

namespace Centerstone.ViewModels
{
	public class BasicInfoViewModel : ViewModelBase
	{
		public HIF HIF { get; set; }

		public int NumberOfAdults => HIF.Adults.Count ();

		public int NumberOfChildren => HIF.Children.Count ();

		public decimal MinimumIncome => 1250.0M;

		public string MinimumIncomeText => MinimumIncome.ToString ();

		public ICommand IncreaseAdults { get; }
		public ICommand DecreaseAdults { get; }
		public ICommand IncreaseChildren { get; }
		public ICommand DecreaseChildren { get; }

		public BasicInfoViewModel (HIF hif)
		{
			HIF = hif;
		}
	}
}
