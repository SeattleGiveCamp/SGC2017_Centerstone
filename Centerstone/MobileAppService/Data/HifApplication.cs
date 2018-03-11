using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Centerstone.MobileAppService.Data
{
    public partial class HifApplication
    {
        public HifApplication()
        {
            HouseholdMembers = new HashSet<HouseholdMembers>();
            Images = new HashSet<Images>();
            IncomeTypes = new HashSet<IncomeTypes>();
            CreateDate = DateTime.Now;
        }
        [Key]
        public long ApplicationId { get; set; }
        public DateTime CreateDate { get; set; }
        public string UniqueAppId { get; set; }
        public string LiveStreetAddress { get; set; }
        public string LiveCity { get; set; }
        public string LiveState { get; set; }
        public string LiveZipCode { get; set; }
        public string MailingAddress { get; set; }
        public string MailingCity { get; set; }
        public string MailingState { get; set; }
        public string MailingZipCode { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string MessagePhone { get; set; }
        public int? DurationYears { get; set; }
        public int? DurationMonth { get; set; }
        public string HousingStatus { get; set; }
        public decimal? CostMonthly { get; set; }
        public string HousingType { get; set; }
        public int? NumberBedrooms { get; set; }
        public int TotalPeople { get; set; }
        public decimal HouseholdIncome { get; set; }
        public bool TargetGroup1 { get; set; }
        public bool TargetGroup2 { get; set; }
        public string HeatSources { get; set; }
        public decimal AnnualHeatCost { get; set; }
        public bool BackupHeatCost { get; set; }
        public bool UsedSurrogate { get; set; }
        public decimal? TotalEnergyCost { get; set; }
        public decimal TotalAnnualElectricCosts { get; set; }
        public string HifJsonData { get; set; }

        public ICollection<HouseholdMembers> HouseholdMembers { get; set; }
        public ICollection<Images> Images { get; set; }
        public ICollection<IncomeTypes> IncomeTypes { get; set; }
    }
}
