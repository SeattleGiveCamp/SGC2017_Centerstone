using System;
using System.Collections.Generic;
using System.Text;

namespace Centerstone.Models
{
    public class IncomeRules
    {
        public long RowId { get; set; }
        public int HouseholdSize { get; set; }
        public decimal MaxIncome { get; set; }
        public decimal HouseholdAdjust { get; set; }
    }
}
