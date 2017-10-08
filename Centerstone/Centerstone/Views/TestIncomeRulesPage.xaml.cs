using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Centerstone
{
    public partial class TestIncomeRulesPage : ContentPage
    {
        IncomeRulesModel viewModel;

        public TestIncomeRulesPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new IncomeRulesModel();
        }

    
    }
}
