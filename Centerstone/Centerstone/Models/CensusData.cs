using System;
namespace Centerstone.Models
{
    public class CensusData : BaseModel
    {
        string gender;
        public string Gender
        {
            get => gender;
            set => SetProperty(ref gender, value);
        }
        public string Race { get; set; } 
        public string Ethnicity { get; set; }
        public string Education { get; set; }
        public string Relation { get; set; }
        public bool SecondaryApplicant { get; set; }
        public bool Disabled { get; set; }
        public bool IsMilitaryVeteran { get; set; }
        public bool HealthInsurance { get; set; }

        public CensusData()
        {
        }
    }
}