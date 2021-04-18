using System;
using System.Text.Json.Serialization;

namespace PQ_API.Classes
{
    public class FireInsurancePolicy
    {
        public string Policy {get;set;}
        public string Company {get;set;}
        public DateTime Expiry {get;set;}
        public Decimal CoverageValue {get;set;}
    

        public FireInsurancePolicy(string policy, string company,DateTime expiry, Decimal coverageValue) 
        {
            Policy = policy;
            Company = company;
            Expiry = expiry;
            CoverageValue = coverageValue;
        }

    }
}
