using System;
using System.Text.Json.Serialization;

namespace PQ_API.Classes
{
    public class Income
    {
        public int TimeInServiceYear {get;set;}
        public int TimeInServiceMonth{get;set;}

        public DateTime EmploymentStart {get;set;}
        public string EmploymentName {get;set;}
        public Address EmploymentAddress {get;set;}

        public Decimal IncomeAmount {get;set;}
        public string IncomeType {get;set;}
    }
}