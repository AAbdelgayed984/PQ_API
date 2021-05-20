using System;
using System.Text.Json.Serialization;

namespace PQ_API.Classes
{
    public class Income
    {
        public int TimeInServiceYear {get;set;}
        public int TimeInServiceMonth{get;set;}
        public DateTime EmploymentStart {get;set;}
        public string JobTitle {get;set;}
        public string EmploymentName {get;set;}
        public EmploymentAddress EmploymentAddress {get;set;}
        public Decimal IncomeAmount {get;set;}
        public string IncomeType {get;set;}
        public string Occupation {get; set;}
        private Enums.BasisOfEmployment _BasisOfEmployment;
        public Enums.BasisOfEmployment BasisOfEmployment 
        {
            get
            {
                return _BasisOfEmployment;
            }
            set
            {
                if (!Enum.IsDefined(typeof(Enums.BasisOfEmployment), value))
                    throw new System.ArgumentException(string.Format("Invalid Enums.BasisOfEmployment {0}.", value));
                _BasisOfEmployment = value;
            }
        }
        public string IndustrySector {get; set;}
        private Enums.IncomeFrequency _IncomeFrequency;
        public Enums.IncomeFrequency IncomeFrequency 
        {
            get
            {
                return _IncomeFrequency;
            }
            set
            {
                if (!Enum.IsDefined(typeof(Enums.IncomeFrequency), value))
                    throw new System.ArgumentException(string.Format("Invalid Enums.IncomeFrequency {0}.", value));
                _IncomeFrequency = value;
            }
        }
    }
}