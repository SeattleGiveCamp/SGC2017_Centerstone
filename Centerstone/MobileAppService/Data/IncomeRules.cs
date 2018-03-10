using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Centerstone.MobileAppService.Data
{
    public partial class IncomeRules
    {
        [Column(TypeName = "bigint")]
        public long RowId { get; set; }
        public int HouseholdSize { get; set; }
        public decimal MaxIncome { get; set; }
        public decimal HouseholdAdjust { get; set; }
    }
}
