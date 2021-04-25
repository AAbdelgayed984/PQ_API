using System.Text.Json.Serialization;

namespace PQ_API.Classes
{
    public class AccountDetails
    {
        public string MortgageAccountNumber {get;set;}
        public Enums.Status Status {get;set;}
        public string StatusReason {get;set;}
        public string BranchCode {get;set;}
        public Enums.Broker Broker {get;set;} 
        public Enums.Brand Brand {get;set;}
        public Enums.Investor Investor {get;set;}
        public Enums.Product Product {get;set;}

    }
}
