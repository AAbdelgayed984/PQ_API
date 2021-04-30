using System;
using System.Text.Json.Serialization;

namespace PQ_API.Classes
{
    public class MortgageInsuranceDetails
    {
        public Enums.MortgageInsurers MortgageInsurer {get;set;}
        public Decimal PremiumAmount {get;set;}
        public Decimal TaxAmount {get;set;}
        public string CertificateNumber {get;set;}      
        public string BulkFlag {get;set;}  
    }
}
