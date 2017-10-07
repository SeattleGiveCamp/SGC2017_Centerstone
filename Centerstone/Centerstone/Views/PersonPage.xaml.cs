using Centerstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public PersonPage()
        {
            InitializeComponent();

            Person = new Person();
            BindingContext = this;
            InitRacePickerItems();
            InitGenderPickerItems();
            InitEthnicityPickerItmes();
            EducationPicker();
            InitRelationPickerItmes();

        }
        public void InitRacePickerItems()
        {
            Picker picker = this.FindByName<Picker>("RacePicker");
            foreach (string name in racesOptions.Keys)
            {
                picker.Items.Add(name);
            }
        }

        public void InitGenderPickerItems()
        {
            Picker picker = this.FindByName<Picker>("GenderPicker");
      
            for (int i = 0; i < genderOptions.Length; i++)
            {
                picker.Items.Add(genderOptions[i]);
            }
        }

        public void InitEducationPickerItmes()
        {
            Picker picker = this.FindByName<Picker>("EducationPicker");
            foreach (string name in educationTypeOptions.Keys)
            {
                picker.Items.Add(name);
            }
        }

        public void InitEthnicityPickerItmes()
        {
            Picker picker = this.FindByName<Picker>("EthnicityPicker");
            foreach (string name in ethnicityOptions.Keys)
            {
                picker.Items.Add(name);
            }
        }

        public void InitRelationPickerItmes()
        {
            Picker picker = this.FindByName<Picker>("RelationPicker");
            foreach (string name in relationOptions.Keys)
            {
                picker.Items.Add(name);
            }
        }
    }
}

