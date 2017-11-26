using System;
using System.Collections.Generic;
using Centerstone.Models;
using Xamarin.Forms;
using Centerstone.Helpers;
using System.Linq;

namespace Centerstone.Views
{
	public partial class EnergyPage : ContentPage
	{
        public HIF hifModel { get; set; }
        public EnergyPage (HIF hif)
		{
            hifModel = hif;

            InitializeComponent ();

			BindingContext = hif;
			//HouseholdTypePicker.ItemsSource = HouseholdTypes.All;
			//HouseholdStatusPicker.ItemsSource = HouseholdStatuses.All;
            //HeatSourcesPicker.ItemsSource = HeatSources.All;
            InitPickerItmes(HouseholdTypePicker, HouseholdTypes.All, hif.HouseholdType);
            InitPickerItmes(HouseholdStatusPicker, HouseholdStatuses.All, hif.HouseholdStatus);
            HouseholdTypePicker.SelectedIndexChanged += (sender, args) =>
            {
                hif.HouseholdType = BindOnChange(HouseholdTypePicker, HouseholdTypes.All);
            };
            HouseholdStatusPicker.SelectedIndexChanged += (sender, args) =>
            {
                hif.HouseholdStatus = BindOnChange(HouseholdStatusPicker, HouseholdStatuses.All);
            };
        }

        void Handle_Toggled(object sender, System.EventArgs e)
        {
        }
        void Handle_ItemClicked(object sender, System.EventArgs e)
        {
            //var data = ((SwitchCell)sender);
        }

        void Handle_Done (object sender, System.EventArgs e)
		{
			Navigation.PopToRootAsync (true);
		}

        //void Handle_AddIncomeTypeClicked(object sender, System.EventArgs e)
        //{
        //    hifModel.HeatSources.Add();
        //}

        void Handle_DeleteIncomeTypeClicked(object sender, System.EventArgs e)
        {
            var selectItem = (string)((Button)sender).CommandParameter;
            //hifModel.HeatSources.Remove(selectItem);
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
    }


}
