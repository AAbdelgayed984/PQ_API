using System.Text.Json.Serialization;

namespace PQ_API.Classes
{
    public class Enums
    {
        public enum MartialStatus { Widowed, Single, Divorced, Separated, Married, CommonLaw};
        public enum Title { Mr, Ms, Mrs, Miss};
        public enum Gender { Male, Female};
        public enum Province { Ontario, Alberta, BritishColumbia, Manitoba, NewBrunsWick, Newfoundland, NorthWestTerritories, NovaScotia, Nunavut, PrinceWdwardIsland, Quebec, Saskatchewan, Yukon };
        public enum Country { Canada }
        public enum Language { English, French }
        public enum ClientType { CoBorrower, PriBorrower, Guarantor }
        public enum PaymentFrequencies { EndOfMonth, Monthly, Weekly, BiWeekly, SemiMonthly }
        public enum LoanPurposes { ETO, TransferOrSwitch, Purchase, Port, Refinance, PurchasePlusImprovement }
        public enum MortgageInsurers { CMHC, Genworth, CandadGauranty }
        public enum PropertyStyles {SplitLevel,ThreeStorey,TwoStorey,OneStorey,StoreyAndAHalf,BiLevel,Other} 
        public enum ValuationMethods {Appraised,Estimated,PurchasePrice}
        public enum PropertyTypes { TriPlex, Duplex, TwoStorey, ApartmentLowRise, Detached, Stacked, ThreeStorey, FourPlex, RowHousing, ModularHome, DuplexSemiDetached, SemiDetached, Mobile, StoreyAndAHalf, ApartmenHighRise };
        public enum DwellingTypes { StrataTitle, CompanyTitle, CrownLease, Freehold, OtherTitle, CommunityTitle, TorrensTitle, Leasehold, MiningLease, IndianReserve, Condo };
        public enum Occupancies { OwnerOccupied, OwnerOccupiedRental, Rental, SecondHome }
        public enum PropertyZones { Residential, Commercial, MixedBusiness, Farm }
        public enum SewageTypes {HoldingTank, Septic, SepticField, Municipal}
        public enum WaterType {Well, LakeIntake, Municipal}
        public enum ConstructionTypes { New, Existing, Construction }
        public enum BorrowerFlag { Borrower,Lender }

    }
}