using System;
using System.Collections.Generic;

namespace Centerstone.MobileAppService.Data
{
    public partial class HouseholdMembers
    {
        public HouseholdMembers()
        {
            IncomeTypes = new HashSet<IncomeTypes>();
        }

        public long PersonId { get; set; }
        public long ApplicationId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string Ssn { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string RelationToPrimary { get; set; }
        public string Gender { get; set; }
        public string Ethnicity { get; set; }
        public string Race { get; set; }
        public string Education { get; set; }
        public string Disability { get; set; }
        public string MilitaryVeteran { get; set; }
        public string HealthInsurance { get; set; }
        public string IsPrimary { get; set; }
        public string PaidAdult { get; set; }

        public HifApplication Application { get; set; }
        public ICollection<IncomeTypes> IncomeTypes { get; set; }
    }
}
