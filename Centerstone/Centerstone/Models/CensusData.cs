using System;
using System.ComponentModel.DataAnnotations;

namespace Centerstone.Models
{
    public class CensusData : BaseModel
    {
        string gender;
        [Required]
        public string Gender
        {
            get => gender;
            set => SetProperty(ref gender, value);
        }
        string race;
        public string Race
        {
            get => race;
            set => SetProperty(ref race, value);
        }
        string ethnicity;
        public string Ethnicity
        {
            get => ethnicity;
            set => SetProperty(ref ethnicity, value);
        }

        string education;
        public string Education
        {
            get => education;
            set => SetProperty(ref education, value);
        }

        string relation;
        public string Relation
        {
            get => relation;
            set => SetProperty(ref relation, value);
        }
        public bool SecondaryApplicant { get; set; }
        public bool Disabled { get; set; }
        public bool IsMilitaryVeteran { get; set; }
        public bool HealthInsurance { get; set; }

        public CensusData()
        {
        }
    }
}