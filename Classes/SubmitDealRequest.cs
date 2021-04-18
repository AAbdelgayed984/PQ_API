namespace PQ_API.Classes
{
    public class SubmitDealRequest
    {
        public AccountDetails AccountDetails { get; set; }
        public Borrower Borrower { get; set; }
        public LoanDetails LoanDetails { get; set; }
        public PrePaymentPrivileges PrePaymentPrivileges { get; set; }
        public MortgageInsuranceDetails MortgageInsuranceDetails { get; set; }
        public FireInsurancePolicy FireInsurancePolicy { get; set; }
        public SecurityPropertyDetails SecurityPropertyDetails { get; set; }
        public PreauthorizedPaymentAccount PreauthorizedPaymentAccount { get; set; }
        public MortgageLifeInsurance MortgageLifeInsurance { get; set; }
        public PropertyTax PropertyTax { get; set; }
        public Securitization Securitization { get; set; }

    }
}