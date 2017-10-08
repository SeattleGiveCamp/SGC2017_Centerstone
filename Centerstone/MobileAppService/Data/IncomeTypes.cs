using System;
using System.Collections.Generic;

namespace Centerstone.MobileAppService.Data
{
    public partial class IncomeTypes
    {
        public long RowId { get; set; }
        public long ApplicationId { get; set; }
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
