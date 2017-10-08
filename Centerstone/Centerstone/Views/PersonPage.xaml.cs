using Centerstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Centerstone.Models;
using Xamarin.Forms;
using Centerstone.Helpers;
using System.ComponentModel;
using Centerstone.Views;

namespace Centerstone
{
    public partial class PersonPage : ContentPage
    {
        readonly HIF hif;
        public Person Person { get; set; }
        public string[] IncomeSourceOptions { get; set; } = IncomeSources.All;

		public PersonPage(HIF hif, Person person)
        {
			this.hif = hif;
            Person = person;
            InitializeComponent();

			BindingContext = new PersonViewModel (person);
            InitRacePickerItems();
            InitGenderPickerItems();
            InitEthnicityPickerItmes();
            InitEducationPickerItmes();
            InitRelationPickerItmes();
        }

        void Handle_AddIncomeTypeClicked(object sender, System.EventArgs e)
        {
            Person.IncomeSources.Add(new Centerstone.Models.IncomeSource());
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
			Person.SocialSecurityImage?.Delete ();
			Person.SocialSecurityImage = img;
		}

        public void Handle_GotoSingPageClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new NoIncomePage(hif, Person));
        }
    }
}

