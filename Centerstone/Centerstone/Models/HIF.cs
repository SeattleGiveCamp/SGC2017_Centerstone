using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Centerstone.Helpers;
using Newtonsoft.Json;

namespace Centerstone.Models
{
    public class Temp
    {
        public string Name { get; set; }
        public bool Value { get; set; } = false;
        public Temp(string name)
        {
            Name = name;
        }
    }
    public class HIF : BaseModel
    {
        public Guid UniqueApplicationId { get; set; }

		public DateTimeOffset CreatedTime { get; set; }

        public string Zip { get; set; }

		decimal maximumIncome = 0.0M;
		public decimal MaximumIncome
		{
			get => maximumIncome;
			set
			{
				if (SetProperty(ref maximumIncome, value))
					OnPropertyChanged("MaximumIncomeText");
			}
		}

		public string MaximumIncomeText => MaximumIncome.ToString("C");

        public Temp[] HeatSourcesTypes { get; set; } = HeatSources.All.Select(x => new Temp(x)).ToArray();
        //public ObservableCollection<string> HeatSourcess { get; set; } =
        //new ObservableCollection<string>();
		
		public ObservableCollection<Person> People { get; set; } =
            new ObservableCollection<Person> ();
		
		public IEnumerable<Person> Adults => People.Where (x => x.IsDesignatedAdult);
		public IEnumerable<Person> Children => People.Where (x => !x.IsDesignatedAdult);

		string contactEmail = "";
		public string ContactEmail { get { return contactEmail; } set { SetProperty (ref contactEmail, value); } }

		string contactPhone = "";
		public string ContactPhone { get { return contactPhone; } set { SetProperty (ref contactPhone, value); } }

		decimal monthlyHouseholdIncome;
		public decimal MonthlyHouseholdIncome {
			get => monthlyHouseholdIncome;
			set => SetProperty (ref monthlyHouseholdIncome, value);
		}

		string householdType = "";
		public string HouseholdType { get { return householdType; } set { SetProperty (ref householdType, value); } }

		string householdStatus = "";
		public string HouseholdStatus { get { return householdStatus; } set { SetProperty (ref householdStatus, value); } }

		//ObservableCollection<string> heatSources = new ObservableCollection<string> ();
		ObservableCollection<HifImage> heatImages = new ObservableCollection<HifImage> ();
		ObservableCollection<HifImage> leaseImages = new ObservableCollection<HifImage> ();

		//public ObservableCollection<string> HeatSources {
		//	get => heatSources;
		//	set {
		//		if (SetProperty(ref heatSources, value))
		//			OnCollectionPropertyChanged("HeatSources");
		//	}
		//}

		public ObservableCollection<HifImage> HeatImages {
			get => heatImages;
			set {
				if (SetProperty(ref heatImages, value))
					OnCollectionPropertyChanged("HeatImages");
			}
		}

		public ObservableCollection<HifImage> LeaseImages {
			get => leaseImages;
			set {
				if (SetProperty(ref leaseImages, value))
					OnCollectionPropertyChanged("LeaseImages");
			}
		}

		HifImage tipsSignature;
		public HifImage TipsSignature
		{
			get => tipsSignature;
			set => SetProperty(ref  tipsSignature, value);
		}

		bool submitted = false;
		public bool Submitted
		{
			get => submitted;
			set => SetProperty(ref submitted, value);
		}

		DateTimeOffset submittedTime = DateTimeOffset.Now;
		public DateTimeOffset SubmittedTime
		{
			get => submittedTime;
			set => SetProperty(ref submittedTime, value);
		}

		public HIF ()
		{
			CreatedTime = DateTimeOffset.Now;
			UniqueApplicationId = Guid.NewGuid ();
            People.CollectionChanged += (s, e) => OnPropertyChanged("People");

            //People.CollectionChanged += People_CollectionChanged;
            //HeatSources.CollectionChanged += (s, e) => OnPropertyChanged ("HeatSources");
			HeatImages.CollectionChanged += (s, e) => OnPropertyChanged ("HeatImages");
			LeaseImages.CollectionChanged += (s, e) => OnPropertyChanged ("LeaseImages");
		}

		void OnCollectionPropertyChanged (string propertyName)
		{
			if (propertyName == "People" && People != null) {
				People.CollectionChanged += People_CollectionChanged;
			}
			//if (propertyName == "HeatSources" && HeatSources != null) {
			//	HeatSources.CollectionChanged += (s, e) => OnPropertyChanged ("HeatSources");
			//}
			if (propertyName == "HeatImages" && HeatImages != null) {
				HeatImages.CollectionChanged += (s, e) => OnPropertyChanged ("HeatImages");
			}
			if (propertyName == "LeaseImages" && LeaseImages != null) {
				LeaseImages.CollectionChanged += (s, e) => OnPropertyChanged ("LeaseImages");
			}
		}

		void People_CollectionChanged (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			OnPropertyChanged ("People");
			OnPropertyChanged ("Adults");
			OnPropertyChanged ("Children");
		}

		public void IncreaseAdults ()
		{
			People.Add (Person.CreateAdult ());
		}

		public void DecreaseAdults ()
		{
			// Always 1 adult
			if (Adults.Count () <= 1)
				return;
			var toRemove = People.Last (x => x.IsDesignatedAdult);
			People.Remove (toRemove);
		}

		public void IncreaseChildren ()
		{
			People.Add (Person.CreateChild ());
		}

		public void DecreaseChildren ()
		{
			var toRemove = Children.LastOrDefault ();
			if (toRemove != null)
				People.Remove (toRemove);
		}

		public string ToJson ()
		{
			return JsonConvert.SerializeObject (this);
		}

		public static HIF ReadFile (string path)
		{
			return JsonConvert.DeserializeObject<HIF> (System.IO.File.ReadAllText (path));
		}

		public static HIF CreateNew()
		{
			var hif = new HIF();
			var a = Person.CreateAdult();
			a.IsPrimary = true;
			hif.People.Add(a);
			return hif;
		}

		public void WriteFile ()
		{
			var j = ToJson ();
			var path = System.IO.Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments), UniqueApplicationId.ToString ("N"));
			Console.WriteLine ("SAVED " + path);
			System.IO.File.WriteAllText (path, j);
		}

		string Path => System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), UniqueApplicationId.ToString("N"));

		public IEnumerable<HifImage> AllImages
		{
			get
			{
				var ssns = People.Where(x => x.SocialSecurityImage != null).Select(x => x.SocialSecurityImage);
				var heats = HeatImages;
				var leases = LeaseImages;
				return ssns.Concat(heats).Concat(leases);
			}
		}

		public void Delete()
		{
			foreach (var i in AllImages)
			{
				try
				{
					System.IO.File.Delete(i.Path);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex);
				}
			}
			try
			{
				System.IO.File.Delete(Path);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
		}

		public static readonly int[] ValidZipCodes = {
			98101, 98102, 98103, 98104, 98105, 98107, 98109, 98122, 98115, 98116, 98117, 98118, 98119, 98121, 98125, 98122, 98126, 98133, 98134, 98144, 98136, 98155, 98177, 98199,
		};

		public List<string> CantSubmitReasons {
			get {
				var r = new List<string> ();
				var hasContact = !string.IsNullOrWhiteSpace (ContactEmail) ||
				                       !string.IsNullOrWhiteSpace (ContactPhone);
				if (!hasContact) {
					r.Add ("You must supply an email or phone number in the Basic Info section.");
				}

				int zip;
				Int32.TryParse ((Zip ?? "").Trim(), out zip);
				if (!ValidZipCodes.Contains (zip)) {
					r.Add ($"You live in a ZIP code served by another organization, please call us at (206) 812-4940 to check if you can receive services.");
				}

				return r;
			}
		}
	}
}
