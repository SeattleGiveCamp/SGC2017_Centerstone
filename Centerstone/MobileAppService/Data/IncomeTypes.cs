using System;
using System.Collections.Generic;

namespace Centerstone.MobileAppService.Data
{
    public partial class IncomeTypes
    {
        public long RowId { get; set; }
        public long ApplicationId { get; set; }
        public long PersonId { get; set; }
        public byte[] Ssi { get; set; }
        public byte[] Tanf { get; set; }
        public byte[] Ga { get; set; }
        public byte[] Va { get; set; }
        public byte[] SocialSecurity { get; set; }
        public byte[] Military { get; set; }
        public byte[] EarnedIncome { get; set; }
        public byte[] Pension { get; set; }
        public byte[] SelfEmployed { get; set; }
        public byte[] ChildSupport { get; set; }
        public byte[] Unemployment { get; set; }
        public byte[] Other { get; set; }

        public HifApplication Application { get; set; }
        public HouseholdMembers Person { get; set; }
    }
}
