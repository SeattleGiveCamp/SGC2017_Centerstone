using Centerstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Centerstone.Models;
using Xamarin.Forms;

namespace Centerstone
{
    public partial class PersonPage : ContentPage
    {
        public Person Person { get; set; }

        public Dictionary<string, RelationType> relationOptions = new Dictionary<string, RelationType>
        {
            { "Self", RelationType.Self },
            { "Spouse", RelationType.Spouse },
            { "Partner", RelationType.Partner },
            { "Child", RelationType.Child },
            { "Other Relative", RelationType.OtherRelative },
            { "Other Non Relative", RelationType.OtherNonRelative },
        };
        public Dictionary<string, RaceType> racesOptions = new Dictionary<string, RaceType>
        {
            { "American Indian Or Alaskan Native", RaceType.AmericanIndianOrAlaskanNative },
            { "Asian", RaceType.Asian },
            { "Black Or African American", RaceType.BlackOrAfricanAmerican },
            { "Native Hawaiian Or Other Pacific Islander", RaceType.NativeHawaiianOrOtherPacificIslander },
            { "White", RaceType.White },
            { "Multi Race", RaceType.MultiRace },
            { "Other", RaceType.Other },
        };
        public string[] genderOptions = Enum.GetValues(typeof(GenderType))
                                            .Cast<object>()
                                            .Select(x => x.ToString())
                                            .ToArray();
        
        public Dictionary<string, EthnicityType> ethnicityOptions = new Dictionary<string, EthnicityType>
        {
            { "Hispanic Or Latino", EthnicityType.HispanicOrLatino },
            { "Not Hispanic Or Latino", EthnicityType.NotHispanicOrLatino }
        };
        public Dictionary<string, EducationType> educationTypeOptions = new Dictionary<string, EducationType>
        {
            { "0 - 8", EducationType.ZeroToEight },
            { "9-12 Non-Graduate", EducationType.NightToTwelveNonGraduate },
            { "High School Graduate/GED", EducationType.HighSchooOrGED },
            { "12+ Some Post-Secondary", EducationType.MoreThanTwelve },
            { "2 or 4 Year College Graduate", EducationType.TwoToFourYearCollegeGraduate }
        };

        public Dictionary<string, IncomeSourceType> incomeSourceOptions = new Dictionary<string, IncomeSourceType>
        {
            { "SSI", IncomeSourceType.SSI },
            { "GA", IncomeSourceType.GA },
            { "VA", IncomeSourceType.VA },
            { "Soc Sec", IncomeSourceType.SocSec },
            { "Military", IncomeSourceType.Military },
            { "EarnedIncome", IncomeSourceType.EarnedIncome },
            { "Pension", IncomeSourceType.Pension },
            { "SelfEmployed", IncomeSourceType.SelfEmployed },
            { "ChildSupport", IncomeSourceType.ChildSupport },
            { "Unemployment", IncomeSourceType.Unemployment },
            { "Other", IncomeSourceType.Other }
        };
        public PersonPage(HIF hif, Person person)
        {
            InitializeComponent();

            Person = person;
            BindingContext = this;
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
            foreach (string name in racesOptions.Keys)
            {
                picker.Items.Add(name);
            }
        }

        public void InitGenderPickerItems()
        {
            Picker picker = GenderPicker;
      
            for (int i = 0; i < genderOptions.Length; i++)
            {
                picker.Items.Add(genderOptions[i]);
            }
        }

        public void InitEducationPickerItmes()
        {
            Picker picker = EducationPicker;
            foreach (string name in educationTypeOptions.Keys)
            {
                picker.Items.Add(name);
            }
        }

        public void InitEthnicityPickerItmes()
        {
            Picker picker = EthnicityPicker;
            foreach (string name in ethnicityOptions.Keys)
            {
                picker.Items.Add(name);
            }
        }

        public void InitRelationPickerItmes()
        {
            Picker picker = RelationPicker;
            foreach (string name in relationOptions.Keys)
            {
                picker.Items.Add(name);
            }
        }

        public void InitIncomeSourceItems()
        {
            //Picker picker = IncomeSourceTypePicker;
            //foreach (string name in incomeSourceOptions.Keys)
            //{
            //    picker.Items.Add(name);
            //}
        }
    }
}

