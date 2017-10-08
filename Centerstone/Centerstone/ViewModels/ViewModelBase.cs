using Centerstone.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

namespace Centerstone
{
    public class ViewModelBase : MvvmHelpers.BaseViewModel
    {
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>() ?? new MockDataStore();
        public IHIFDataStore<IncomeRules> HIFDataStore => DependencyService.Get<IHIFDataStore<IncomeRules>>() ?? new HIFDataStore();

    }
}
