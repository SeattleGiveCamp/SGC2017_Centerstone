using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Centerstone.MobileAppService.Data
{
    public partial class IncomeTypes
    {
        [Column(TypeName = "bigint")]
        public long RowId { get; set; }
        [Column(TypeName = "bigint")]
        public long ApplicationId { get; set; }
        [Column(TypeName = "bigint")]
        public long PersonId { get; set; }
        public bool Ssi { get; set; }
        public bool Tanf { get; set; }
        public bool Ga { get; set; }
        public bool Va { get; set; }
        public bool SocialSecurity { get; set; }
        public bool Military { get; set; }
        public bool EarnedIncome { get; set; }
        public bool Pension { get; set; }
        public bool SelfEmployed { get; set; }
        public bool ChildSupport { get; set; }
        public bool Unemployment { get; set; }
        public bool Other { get; set; }

        public HifApplication Application { get; set; }
        public HouseholdMembers Person { get; set; }
    }
}
