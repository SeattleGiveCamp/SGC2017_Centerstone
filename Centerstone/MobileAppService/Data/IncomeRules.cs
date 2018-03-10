using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Centerstone.MobileAppService.Data
{
    public partial class IncomeRules
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int RowId { get; set; }
        public int HouseholdSize { get; set; }
        public decimal MaxIncome { get; set; }
        public decimal HouseholdAdjust { get; set; }
    }
}
