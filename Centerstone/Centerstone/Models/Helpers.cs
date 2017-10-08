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
            "SelfEmployed",
            "ChildSupport",
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
            "American Indian Or Alaskan Native",
            "Asian",
            "Black Or African American",
            "Native Hawaiian Or Other Pacific Islander",
            "Native Hawaiian Or Other Pacific Islander",
            "White",
            "Multi Race",
            "Other",
            "ChildSupport",
            "Unemployment",
        };
    }

    public static class HeatSources
    {
        public static readonly string[] All = {
            "Electrical",
            "Natural Gas",
            "Propane",
            "Oil",
            "Wood",
            "Coal",
        };
    }
}
