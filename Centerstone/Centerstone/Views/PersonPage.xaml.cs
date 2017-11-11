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
        readonly HIF Hif;
        public Person Person { get; set; }
        public string[] IncomeSourceOptions { get; set; } = IncomeSources.All;
        public PersonViewModel viewModel;
        public PersonPage(HIF hif, Person person)
        {

            InitializeComponent();
            Hif = hif;
            Person = person;
            viewModel = new PersonViewModel(person);
            BindingContext = viewModel;
            InitPickerItmes(RacePicker, Races.All, viewModel.Person.CensusData.Race);
            InitPickerItmes(GenderPicker, Genders.All, viewModel.Person.CensusData.Gender);
            InitPickerItmes(EthnicityPicker, Ethnicities.All, viewModel.Person.CensusData.Ethnicity);
            InitPickerItmes(EducationPicker, Educations.All, viewModel.Person.CensusData.Education);
            InitPickerItmes(RelationPicker, Educations.All, viewModel.Person.CensusData.Relation);

            RacePicker.SelectedIndexChanged += (sender, args) =>
            {
                viewModel.Person.CensusData.Race = BindOnChange(RacePicker, Races.All);
            };
            GenderPicker.SelectedIndexChanged += (sender, args) =>
            {
                viewModel.Person.CensusData.Gender = BindOnChange(GenderPicker, Genders.All);
            };
            EthnicityPicker.SelectedIndexChanged += (sender, args) =>
            {
                viewModel.Person.CensusData.Ethnicity = BindOnChange(EthnicityPicker, Ethnicities.All);
            };
            EducationPicker.SelectedIndexChanged += (sender, args) =>
            {
                viewModel.Person.CensusData.Education = BindOnChange(EducationPicker, Educations.All);
            };
            RelationPicker.SelectedIndexChanged += (sender, args) =>
            {
                viewModel.Person.CensusData.Relation = BindOnChange(RelationPicker, Relations.All);
            };

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

        public void InitPickerItmes(Picker picker, string[] allItmes, string selectedItem)
        {
            picker.ItemsSource = allItmes;
            picker.SelectedIndex = Array.IndexOf(allItmes, selectedItem);
        }

        public string BindOnChange(Picker picker, string[] allItmes)
        {
            if (picker.SelectedIndex >= 0 && picker.SelectedIndex < allItmes.Length)
            {
                string name = allItmes[picker.SelectedIndex];
                return name;
            }
            return null;
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
            Navigation.PushAsync(new NoIncomePage(Hif, Person));
        }
    }
}

