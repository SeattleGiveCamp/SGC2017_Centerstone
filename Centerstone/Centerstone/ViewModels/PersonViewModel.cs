using Centerstone.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Centerstone
{
    public class PersonViewModel : ViewModelBase
    {
        public Person Person { get; set; }

        public PersonViewModel(Person person)
        {
			Person = person;
			person.PropertyChanged += (sender, e) => OnPropertyChanged ("Person");
        }
        
    }
}
