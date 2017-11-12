using System;
using System.Collections.ObjectModel;

namespace Centerstone.Models
{
	public class Person : BaseModel
	{
        bool isDesignatedAdult;
		public bool IsDesignatedAdult
        {
            get => isDesignatedAdult;
            set => SetProperty(ref isDesignatedAdult, value);
        }

        public string DisplayAdult => IsDesignatedAdult ? "Adult" : "Child";
        public bool IsPrimary { get; set; }

		public string FullName { get; set; }
		public DateTime DateOfBirth { get; set; }

		public string DisplayFullName =>
			string.IsNullOrWhiteSpace(FullName) ?
		          (isDesignatedAdult ? "Unknown Adult" : "Unknown Child") :
		          FullName;

		string socialSecurityNumber;
		public string SocialSecurityNumber {
			get => socialSecurityNumber;
			set => SetProperty (ref socialSecurityNumber, value);
		}

        HifImage socialSecurityImage;
		public HifImage SocialSecurityImage {
			get => socialSecurityImage;
			set => SetProperty (ref socialSecurityImage, value);
		}

		public ObservableCollection<IncomeSource> IncomeSources { get; set; } =
			new ObservableCollection<IncomeSource> ();
        ObservableCollection<HifImage> incomeSourcesImage = new ObservableCollection<HifImage>();

        public ObservableCollection<HifImage> IncomeSourcesImage
        {
            get => incomeSourcesImage;
            set
            {
                if (SetProperty(ref incomeSourcesImage, value))
                    OnCollectionPropertyChanged("IncomeSourcesImage");
            }
        }
        void OnCollectionPropertyChanged(string propertyName)
        {        
            if (propertyName == "HeatImages" && incomeSourcesImage != null)
            {
                incomeSourcesImage.CollectionChanged += (s, e) => OnPropertyChanged("IncomeSourcesImage");
            }
           
        }
        public CensusData CensusData { get; set; } = new CensusData ();

		public Person ()
		{
            CensusData.PropertyChanged += (s, e) => OnPropertyChanged("CensusData");
		}

		public static Person CreateChild ()
		{
			return new Person (); 
		}

		public static Person CreateAdult ()
		{
			return new Person () {
				IsDesignatedAdult = true,
			};
		}

        //No Income
        HifImage noIncomeSingurate;
        public HifImage NoIncomeSingurate
        {
            get => noIncomeSingurate;
            set => SetProperty(ref noIncomeSingurate, value);
        }
        public string NoIncomeReason { get; set; }
        public string WayOfBasicLiving { get; set; }
    }
}
