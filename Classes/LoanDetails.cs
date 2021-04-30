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
        public int ProductTerm_Years {get;set;}
        public int ProductTerm_Months {get;set;}
        public string ProductCode {get;set;}
        public Enums.LoanPurposes LoanPurpose {get;set;}
        public Decimal InterestAccrualBalance {get;set;}
        public int AmortizationOriginal_Years {get;set;}
        public int AmortizationOriginal_Months {get;set;}
        public int AmortizationContractual_Years {get;set;}
        public int AmortizationContractual_Months {get;set;}
        public int AmortizationRemaining_Years {get;set;}
        public int AmortizationRemaining_Months {get;set;}
        public int OriginalLTV {get;set;}
        public string LoanType {get;set;}
        public int LoanTerm {get;set;}
        public DateTime ClosingDate {get;set;}
        public DateTime ApplicationDate {get;set;}
        public DateTime DisbursementDate {get;set;}
        public Enums.PaymentFrequencies PaymentFrequency {get;set;}
        public decimal InterestRate {get;set;}
        public int Spread {get;set;}
        public int CombinedGDS {get;set;}
        public int CombinedTDS {get;set;}
        public DateTime MaturityDate {get;set;}
        public Decimal PaymentAmount {get;set;}
        public string Feature {get;set;}
    }
    
}
