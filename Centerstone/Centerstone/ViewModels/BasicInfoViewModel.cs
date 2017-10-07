using System;
using System.Linq;
using System.Windows.Input;
using Centerstone.Models;
using Xamarin.Forms;

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

			HIF.PropertyChanged += (sender, e) => {
				OnPropertyChanged ("HIF");
				OnPropertyChanged ("NumberOfAdults");
				OnPropertyChanged ("NumberOfChildren");
				OnPropertyChanged ("MinimumIncome");
			};

			IncreaseAdults = new Command (HIF.IncreaseAdults);
			DecreaseAdults = new Command (HIF.DecreaseAdults);
			IncreaseChildren = new Command (HIF.IncreaseChildren);
			DecreaseChildren = new Command (HIF.DecreaseChildren);
		}
	}
}
