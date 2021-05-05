using System;
using System.Text.Json.Serialization;

namespace PQ_API.Classes
{
    public class MortgageInsuranceDetails
    {
        private Enums.MortgageInsurers _MortgageInsurer;
        public Enums.MortgageInsurers MortgageInsurer 
        {
            get
            {
                return _MortgageInsurer;
            }
            set
            {
                if (!Enum.IsDefined(typeof(Enums.MortgageInsurers), value))
                    throw new System.ArgumentException(string.Format("Invalid Enums.MortgageInsurers {0}.", value));
                _MortgageInsurer = value;
            }
        }
        public Decimal PremiumAmount {get;set;}
        public Decimal TaxAmount {get;set;}
        public string CertificateNumber {get;set;}      
        public string BulkFlag {get;set;}  
    }
}
