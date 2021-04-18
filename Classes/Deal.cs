using System;
using System.Globalization;
using System.Text.Json.Serialization;

namespace PQ_API.Classes
{
    public class Deal
    {
        public string RMR_ID { get; set; } 
        public Int32 RMR_SeqNumber { get; set; }
        public string ComponentType { get; set; }
        public double? LoanAmount { get; set; }
        public string MortgageType { get; set; }
        public string PropertyAddress { get; set; }
        public double? InterestPaidPriorYear { get; set; }
        public double? InterestPaidYearToDate { get; set; }
        public double? PrincipalPaidPriorYear { get; set; }
        public double? PrincipalPaidYearToDate { get; set; }
        public double? CurrentMortgageBalance { get; set; }
        public string ProductDescription { get; set; }
        public string RateType { get; set; }
        public string InterestRate { get; set; }
        public string PaymentType { get; set; }
        public double? PaymentAmount { get; set; }
        public string PaymentFrequency { get; set; }
        public string LastPaymentDate { get; set; }
        public string NextPaymentDate { get; set; }
        public string MaturityDate { get; set; }
        public Int32? RemainingAmortization_Months { get; set; }		
        public Int32? RemainingAmortization_Years { get; set; }

        public Deal
            (
                string _RMR_ID, 
                Int32 _RMR_SeqNumber,
                string _ComponentType,
                double? _LoanAmount,
                string _MortgageType,
                string _PropertyAddress,
                double? _InterestPaidPriorYear,
                double? _InterestPaidYearToDate,
                double? _PrincipalPaidPriorYear,
                double? _PrincipalPaidYearToDate,
                double? _CurrentMortgageBalance,
                string _ProductDescription,
                string _RateType,
                string _InterestRate,
                string _PaymentType,
                double? _PaymentAmount,
                string _PaymentFrequency,
                string _LastPaymentDate,
                string _NextPaymentDate,
                string _MaturityDate,
                Int32? _RemainingAmortization_Months,		
                Int32? _RemainingAmortization_Years 
            )
        {
            this.RMR_ID = _RMR_ID; 
            this.RMR_SeqNumber = _RMR_SeqNumber;
            this.ComponentType = _ComponentType;
            this.LoanAmount = _LoanAmount;
            this.MortgageType = _MortgageType;
            this.PropertyAddress = _PropertyAddress;
            this.InterestPaidPriorYear = _InterestPaidPriorYear;
            this.InterestPaidYearToDate = _InterestPaidYearToDate;
            this.PrincipalPaidPriorYear = _PrincipalPaidPriorYear;
            this.PrincipalPaidYearToDate = _PrincipalPaidYearToDate;
            this.CurrentMortgageBalance = _CurrentMortgageBalance;
            this.ProductDescription = _ProductDescription;
            this.RateType = _RateType;
            this.InterestRate = _InterestRate;
            this.PaymentType = _PaymentType;
            this.PaymentAmount = _PaymentAmount;
            this.PaymentFrequency = _PaymentFrequency;
            this.LastPaymentDate = _LastPaymentDate;
            this.NextPaymentDate = _NextPaymentDate;
            this.MaturityDate = _MaturityDate;
            this.RemainingAmortization_Months = _RemainingAmortization_Months;
            this.RemainingAmortization_Years = _RemainingAmortization_Years;

        }
    }
}