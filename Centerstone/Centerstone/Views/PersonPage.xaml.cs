using Centerstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Centerstone.Models;
using Xamarin.Forms;
using Centerstone.Helpers;
using System.ComponentModel;

namespace Centerstone
{
    public partial class PersonPage : ContentPage
    {
        //public event PropertyChangedEventHandler PropertyChanged;

        //private Person person;
        //public Person Person
        //{
        //    get { return this.person;  }
        //    set
        //    {
        //        this.person = value;
        //        if (PropertyChanged != null)
        //        {
        //            PropertyChanged(this,
        //                new PropertyChangedEventArgs("Person"));
        //        }
        //    }
        //}
        public Person Person { get; set; }
                                           // public string SelectGender { get; set; }
                                           //public Dictionary<string, RelationType> relationOptions = new Dictionary<string, RelationType>
                                           //{
                                           //    { "Self", RelationType.Self },
                                           //    { "Spouse", RelationType.Spouse },
                                           //    { "Partner", RelationType.Partner },
                                           //    { "Child", RelationType.Child },
                                           //    { "Other Relative", RelationType.OtherRelative },
                                           //    { "Other Non Relative", RelationType.OtherNonRelative },
                                           //};
                                           //public Dictionary<string, RaceType> racesOptions = new Dictionary<string, RaceType>
                                           //{
                                           //    { "American Indian Or Alaskan Native", RaceType.AmericanIndianOrAlaskanNative },
                                           //    { "Asian", RaceType.Asian },
                                           //    { "Black Or African American", RaceType.BlackOrAfricanAmerican },
                                           //    { "Native Hawaiian Or Other Pacific Islander", RaceType.NativeHawaiianOrOtherPacificIslander },
                                           //    { "White", RaceType.White },
                                           //    { "Multi Race", RaceType.MultiRace },
                                           //    { "Other", RaceType.Other },
                                           //};
                                           //public string[] genderOptions = Enum.GetValues(typeof(GenderType))
                                           //                                    .Cast<object>()
                                           //                                    .Select(x => x.ToString())
                                           //                                    .ToArray();

        //public Dictionary<string, EthnicityType> ethnicityOptions = new Dictionary<string, EthnicityType>
        //{
        //    { "Hispanic Or Latino", EthnicityType.HispanicOrLatino },
        //    { "Not Hispanic Or Latino", EthnicityType.NotHispanicOrLatino }
        //};
        //public Dictionary<string, EducationType> educationTypeOptions = new Dictionary<string, EducationType>
        //{
        //    { "0 - 8", EducationType.ZeroToEight },
        //    { "9-12 Non-Graduate", EducationType.NightToTwelveNonGraduate },
        //    { "High School Graduate/GED", EducationType.HighSchooOrGED },
        //    { "12+ Some Post-Secondary", EducationType.MoreThanTwelve },
        //    { "2 or 4 Year College Graduate", EducationType.TwoToFourYearCollegeGraduate }
        //};

        //public Dictionary<string, IncomeSourceType> incomeSourceOptions = new Dictionary<string, IncomeSourceType>
        //{
        //    { "SSI", IncomeSourceType.SSI },
        //    { "GA", IncomeSourceType.GA },
        //    { "VA", IncomeSourceType.VA },
        //    { "Soc Sec", IncomeSourceType.SocSec },
        //    { "Military", IncomeSourceType.Military },
        //    { "EarnedIncome", IncomeSourceType.EarnedIncome },
        //    { "Pension", IncomeSourceType.Pension },
        //    { "SelfEmployed", IncomeSourceType.SelfEmployed },
        //    { "ChildSupport", IncomeSourceType.ChildSupport },
        //    { "Unemployment", IncomeSourceType.Unemployment },
        //    { "Other", IncomeSourceType.Other }
        //};
        public PersonPage(HIF hif, Person person)
        {
            InitializeComponent();

            Person = person;
            BindingContext = person;
            InitRacePickerItems();
            InitGenderPickerItems();
            InitEthnicityPickerItmes();
            InitEducationPickerItmes();
            InitRelationPickerItmes();
        }

        void Handle_AddIncomeTypeClicked(object sender, System.EventArgs e)
        {
            Person.IncomeSources.Add(new IncomeSource());
        }

        void Handle_DeleteIncomeTypeClicked(object sender, System.EventArgs e)
        {
            Person.IncomeSources.Add(new IncomeSource());
        }
        public void InitRacePickerItems()
        {
            Picker picker = RacePicker;
            picker.ItemsSource = Races.All;
        }

        public void InitGenderPickerItems()
        {
            Picker picker = GenderPicker;
            picker.ItemsSource = Genders.All;

        }

        public void InitEducationPickerItmes()
        {
            Picker picker = EducationPicker;
            picker.ItemsSource = Educations.All;

        }

        public void InitEthnicityPickerItmes()
        {
            Picker picker = EthnicityPicker;
            picker.ItemsSource = Ethnicities.All;

        }

        public void InitRelationPickerItmes()
        {
            Picker picker = RelationPicker;
            picker.ItemsSource = Relations.All;

        }

        public void InitIncomeSourceItems()
        {
            ////Picker picker = IncomeSourceTypePicker;
            ////picker.ItemsSource = Races.All;

        }
    }
}

