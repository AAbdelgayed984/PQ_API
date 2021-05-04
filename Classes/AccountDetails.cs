using System;
using System.Text.Json.Serialization;

namespace PQ_API.Classes
{
    public class AccountDetails
    {
        public string MortgageAccountNumber {get;set;}
        private Enums.Status _Status;
        public Enums.Status Status 
        {
            get
            {
                return _Status;
            }
            set
            {
                if (!Enum.IsDefined(typeof(Enums.Status), value))
                    throw new System.ArgumentException(string.Format("Invalid Enums.Status {0}.", value));
                _Status = value;
            }
        }
        public string StatusReason {get;set;}
        public string BranchCode {get;set;}
        public Enums.Broker Broker {get;set;} 
        public Enums.Brand Brand {get;set;}
        public Enums.Investor Investor {get;set;}
        public string Product {get;set;}

    }
}
