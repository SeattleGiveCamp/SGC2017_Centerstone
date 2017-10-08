using System;
using System.Collections.Generic;

namespace Centerstone.MobileAppService.Data
{
    public partial class IncomeRules
    {
        public long RowId { get; set; }
        public int HouseholdSize { get; set; }
        public decimal MaxIncome { get; set; }
        public decimal HouseholdAdjust { get; set; }
    }
}
