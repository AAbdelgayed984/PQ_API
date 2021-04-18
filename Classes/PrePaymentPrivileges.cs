using System;

namespace PQ_API.Classes
{
    public class PrePaymentPrivileges
    {
        public Decimal PaymentIncreasePrivileges {get;set;}
        public Decimal OriginalPaymentAmount {get;set;}
        public Decimal CurrentPaymentAmount {get;set;}
        public DateTime NextPaymentDate {get;set;}
        public DateTime EffectiveNextPaymentDate {get;set;}
        public Decimal CashBack{get;set;}
        public Decimal CashBackPaidAmount{get;set;}
        public string ChargePosition {get;set;}
        public string IndicatorForNearPrime{get;set;}
    }
}
