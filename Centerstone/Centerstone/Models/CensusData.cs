using System;
namespace Centerstone.Models
{
    public class CensusData: BaseModel
    {
        public GenderType gender 
        public GenderType Gender {
            get => gender;
            set => SetPr

        }
        public RaceType Race { get; set; }
        public EthnicityType Ethnicity { get; set; }
        public EducationType Education { get; set; }
        public RelationType Relation { get; set; }
        public bool SecondaryApplicant { get; set; }
        public bool Disabled { get; set; }
        public bool IsMilitaryVeteran { get; set; }
        public bool HealthInsurance { get; set; }

        public CensusData()
        {
        }
    }
}