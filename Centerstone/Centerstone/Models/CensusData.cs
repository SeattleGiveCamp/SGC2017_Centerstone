using System;
namespace Centerstone.Models
{
    public class CensusData
    {
        public GenderType Gender { get; set; }
        public EthnicityType Ethnicity { get; set; }
        public EducationType Education { get; set; }
        public bool SecondaryApplicant { get; set; }
        public bool Disabled { get; set; }
        public bool IsMilitaryVeteran { get; set; }
        public bool HealthInsurance { get; set; }

        public CensusData()
        {
        }
    }
}