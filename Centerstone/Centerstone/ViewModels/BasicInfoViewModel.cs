using System;

namespace Centerstone.ViewModels
{
	public class BasicInfoViewModel : ViewModelBase
	{
		string zip;
		public string Zip {
			get => zip;
			set => SetProperty (ref zip, value);
		}

		string numberOfAdults;
		public string NumberOfAdults {
			get => numberOfAdults;
			set => SetProperty (ref numberOfAdults, value);
		}

		string numberOfChildren;
		public string NumberOfChildren {
			get => numberOfChildren;
			set => SetProperty (ref numberOfChildren, value);
		}

		public BasicInfoViewModel ()
		{
		}
	}
}
