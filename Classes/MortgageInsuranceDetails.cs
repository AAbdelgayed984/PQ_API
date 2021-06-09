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
        private Enums.MIType _MIType;
        public Enums.MIType MIType 
        {
            get
            {
                return _MIType;
            }
            set
            {
                if (!Enum.IsDefined(typeof(Enums.MIType), value))
                    throw new System.ArgumentException(string.Format("Invalid Enums.MIType {0}.", value));
                _MIType = value;
            }
        }

        private Enums.MIStatus _MIStatus;
        public Enums.MIStatus MIStatus 
        {
            get
            {
                return _MIStatus;
            }
            set
            {
                if (!Enum.IsDefined(typeof(Enums.MIStatus), value))
                    throw new System.ArgumentException(string.Format("Invalid Enums.MIStatus {0}.", value));
                _MIStatus = value;
            }
        }
    }
}
