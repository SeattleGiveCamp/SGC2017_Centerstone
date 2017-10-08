using System;
namespace Centerstone.Helpers
{
    public static class Genders
    {
        public readonly static string[] All = {
            "Male",
            "Female",
            "Other"
        };
    }

    public static class Educations
    {
        public readonly static string[] All = {
             "0 - 8",
              "9-12 Non-Graduate",
               "High School Graduate/GED",
               "12+ Some Post-Secondary",
               "2 or 4 Year College Graduate"
        };
    }

    public static class Relations
    {
        public readonly static string[] All = {
            "Self",
            "Spouse",
            "Partner",
            "Child",
            "Other Relative",
            "Other Non Relative"
        };
    }


    public static class IncomeSources
    {
        public readonly static string[] All = {
            "SSI",
            "GA",
            "VA",
            "Soc Sec",
            "Military",
            "EarnedIncome",
            "Pension",
            "Self Employed",
            "Child Support",
            "Unemployment",
            "Other",
        };
    }

    public static class Ethnicities
    {
        public readonly static string[] All = {
            "Hispanic Or Latino",
            "Not Hispanic Or Latino"
        };
    }

    public static class Races
    {
        public readonly static string[] All = {
            "American Indian or Alaskan Native",
            "Asian",
            "Black or African American",
            "Native Hawaiian or Other Pacific Islander",
            "Native Hawaiian or Other Pacific Islander",
            "White",
            "Multi-race",
            "Other",
        };
    }

    public static class HeatSources
    {
        public static readonly string[] All = {
            "Electricity",
            "Natural Gas",
            "Propane",
            "Oil",
            "Wood",
            "Coal",
        };
    }
}
