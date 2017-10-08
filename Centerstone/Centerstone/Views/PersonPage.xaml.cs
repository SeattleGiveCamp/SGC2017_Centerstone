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
        
        public Person Person { get; set; }
        public string[] IncomeSourceOptions { get; set; } = IncomeSources.All;
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
            var selectedIncomeSource = (IncomeSource) ((Button)sender).CommandParameter;
            Person.IncomeSources.Remove(selectedIncomeSource);
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
            //picker.ItemsSource = IncomeSources.All;

        }

		public void Handle_SsnReceived (HifImage img)
		{
			
		}
    }
}

