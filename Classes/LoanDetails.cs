using System;
using System.Text.Json.Serialization;

namespace PQ_API.Classes
{
    public class LoanDetails
    {
        public Decimal CurrentLoanAmount {get;set;}
        public Decimal OriginalLoanAmount {get;set;}
        public Decimal ApprovedBalance {get;set;}
        public Decimal AvailableCreditBalance {get;set;}
        public Decimal UnadvancedBalance {get;set;}
        public Decimal UnappliedBalance {get;set;}
        public string ProductType {get;set;}
        public string ProductTerm {get;set;}
        public string ProductCode {get;set;}
        public Enums.LoanPurposes LoanPurpose {get;set;}
        public Decimal InterestAccrualBalance {get;set;}
        public int AmortizationOriginal {get;set;}
        public int AmortizationContractual {get;set;}
        public int AmortizationRemaining {get;set;}
        public int OriginalLTV {get;set;}
        public string LoanType {get;set;}
        public int LoanTerm {get;set;}
        public DateTime ClosingDate {get;set;}
        public DateTime ApplicationDate {get;set;}
        public DateTime DisbursementDate {get;set;}
        public Enums.PaymentFrequencies PaymentFrequcey {get;set;}
        public int InterestRate {get;set;}
        public int Spread {get;set;}
        public int CombinedGDS {get;set;}
        public int CombinedTDS {get;set;}
        public DateTime MaturityDate {get;set;}
        public Decimal PaymentAmount {get;set;}
        public string Feature {get;set;}
    }
    
}
