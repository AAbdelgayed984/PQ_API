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
        private Enums.LoanPurposes _LoanPurpose;
        public Enums.LoanPurposes LoanPurpose 
        {
            get
            {
                return _LoanPurpose;
            }
            set
            {
                if (!Enum.IsDefined(typeof(Enums.LoanPurposes), value))
                    throw new System.ArgumentException(string.Format("Invalid Enums.LoanPurposes {0}.", value));
                _LoanPurpose = value;
            }
        }
        public Decimal InterestAccrualBalance {get;set;}
        public int AmortizationOriginal_Years {get;set;}
        public int AmortizationOriginal_Months {get;set;}
        public int AmortizationContractual_Years {get;set;}
        public int AmortizationContractual_Months {get;set;}
        public int AmortizationRemaining_Years {get;set;}
        public int AmortizationRemaining_Months {get;set;}
        public Decimal OriginalLTV {get;set;}
        private Enums.LoanType _LoanType;
        public Enums.LoanType LoanType 
        {
            get
            {
                return _LoanType;
            }
            set
            {
                if (!Enum.IsDefined(typeof(Enums.LoanType), value))
                    throw new System.ArgumentException(string.Format("Invalid Enums.LoanType {0}.", value));
                _LoanType = value;
            }
        }
        public int LoanTerm {get;set;}
        public DateTime ClosingDate {get;set;}
        public DateTime ApplicationDate {get;set;}
        public DateTime DisbursementDate {get;set;}
        private Enums.PaymentFrequencies _PaymentFrequency;
        public Enums.PaymentFrequencies PaymentFrequency 
        {
            get
            {
                return _PaymentFrequency;
            }
            set
            {
                if (!Enum.IsDefined(typeof(Enums.PaymentFrequencies), value))
                    throw new System.ArgumentException(string.Format("Invalid Enums.PaymentFrequencies {0}.", value));
                _PaymentFrequency = value;
            }
        }
        public decimal InterestRate {get;set;}
        public Decimal Spread {get;set;}
        public Decimal CombinedGDS {get;set;}
        public Decimal CombinedTDS {get;set;}
        public DateTime MaturityDate {get;set;}
        public Decimal PaymentAmount {get;set;}
        public string Feature {get;set;}
    }
    
}
