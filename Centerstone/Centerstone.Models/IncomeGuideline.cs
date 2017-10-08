using System;
using System.ComponentModel.DataAnnotations;

namespace Centerstone.Models
{
    public class IncomeGuideline
    {
        [Key]        
        public int myKey { get; set; }

        [Display(Name = "Household Size")]
        public int HouseholdSize { get; set; }

        [Display(Name ="Maximum Income")]
        public decimal MaxIncome { get; set; }
    }
}
