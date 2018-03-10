using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Centerstone.MobileAppService.Data
{
    public partial class HouseholdMembers
    {
        public HouseholdMembers()
        {
            IncomeTypes = new HashSet<IncomeTypes>();
        }
        [Key]
        public long PersonId { get; set; }
        public long ApplicationId { get; set; }
        public string FullName { get; set; }
        public string Ssn { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string RelationToPrimary { get; set; }
        public string Gender { get; set; }
        public string Ethnicity { get; set; }
        public string Race { get; set; }
        public string Education { get; set; }
        public bool Disability { get; set; }
        public bool MilitaryVeteran { get; set; }
        public bool HealthInsurance { get; set; }
        public bool IsPrimary { get; set; }
        public bool PaidAdult { get; set; }

        public HifApplication Application { get; set; }
        public ICollection<IncomeTypes> IncomeTypes { get; set; }
    }
}
