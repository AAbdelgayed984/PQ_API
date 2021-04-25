using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text.Json.Serialization;

namespace PQ_API.Classes
{
    public class Enums
    {
        public enum AddressType {
            [Description("")]Mailing,
            [Description("")]Current,
            [Description("")]Previous,
        }
        public enum ContactType {
            [Description("")]HomePhone,
            [Description("")]MobilePhone,
            [Description("")]Email,
        }
        public enum BalanceType {
            [Description("{cf421ec7-af23-474c-9f8f-46e6b899075f}")]Principal,
            [Description("{57af2f0d-9ec7-46c7-9468-cf633f9b4930}")]Approved,
            [Description("{ab9ae444-3ec5-425c-be24-121b1618669e}")]AvailableCredit,
            [Description("{b0d3b9a3-a4e6-40c9-818f-e9e60df7643b}")]Unadvanced,
            [Description("{e5c24ad5-75f4-4cf6-8bc0-5b0e833d4cc4}")]Unapplied,

        }
        public enum StreetType {
            [Description("")]Street,
            [Description("")]Avenue,
            [Description("")]Road,
        }
        public enum Keys {
            [Description("")]CustomerAccountNumber,
            [Description("")]MortgageAccountNumber,
            [Description("")]CustomerBeaconScore
        }
        public enum Association {
            [Description("")]Brand,
            [Description("")]Investor,
            [Description("")]Agent,
            [Description("")]SubAgent,
            [Description("")]SubmittingAgent,
            [Description("")]MortgageInsurer,
            [Description("")]SourceOfBusiness,
            [Description("")]PrimaryBorrower,
            [Description("")]CoBorrower,
            [Description("")]Guarantor ,
        }
        public enum Status {
            [Description("")]Current,
        }
        public enum Broker {
            [Description("")]TestBroker1,
            [Description("")]TestBroker2,
            [Description("")]TestBroker3,
            [Description("")]TestBroker4,
            [Description("")]TestBroker5,
        }
        public enum Brand {
            [Description("")]Nesto
        }
        public enum Investor {
            [Description("")]NBF8,
            [Description("")]TDSI3,
        }
        public enum Product {
            [Description("")]TestProduct1,
            [Description("")]TestProduct2,
            [Description("")]TestProduct3,
            [Description("")]TestProduct4,
            [Description("")]TestProduct5,
        }
        public enum MartialStatus { 
            [Description("")]Widowed, 
            [Description("")]Single, 
            [Description("")]Divorced, 
            [Description("")]Separated, 
            [Description("")]Married, 
            [Description("")]CommonLaw
        };
        public enum Title { 
            [Description("")]Mr, 
            [Description("")]Ms, 
            [Description("")]Mrs, 
            [Description("")]Miss
        };
        public enum Gender { 
            [Description("")]Male, 
            [Description("")]Female
        }
        public enum Province { 
            [Description("")]Ontario, 
            [Description("")]Alberta, 
            [Description("")]BritishColumbia, 
            [Description("")]Manitoba, 
            [Description("")]NewBrunsWick, 
            [Description("")]Newfoundland, 
            [Description("")]NorthWestTerritories, 
            [Description("")]NovaScotia, 
            [Description("")]Nunavut, 
            [Description("")]PrinceWdwardIsland, 
            [Description("")]Quebec, 
            [Description("")]Saskatchewan, 
            [Description("")]Yukon 
        };
        public enum Country { [Description("")]Canada }
        public enum Language { 
            [Description("")]English, 
            [Description("")]French 
        }
        public enum ClientType { 
            [Description("")]CoBorrower, 
            [Description("")]PriBorrower, 
            [Description("")]Guarantor 
        }
        public enum PaymentFrequencies { 
            [Description("")]EndOfMonth, 
            [Description("")]Monthly, 
            [Description("")]Weekly, 
            [Description("")]BiWeekly, 
            [Description("")]SemiMonthly 
        }
        public enum LoanPurposes { 
            [Description("")]ETO, 
            [Description("")]TransferOrSwitch, 
            [Description("")]Purchase, 
            [Description("")]Port, 
            [Description("")]Refinance, 
            [Description("")]PurchasePlusImprovement 
        }
        
        public enum MortgageInsurers { 
            [Description("")]CMHC, 
            [Description("")]Genworth, 
            [Description("")]CandadGauranty 
        }

        public enum PropertyStyles {
            [Description("")]SplitLevel,
            [Description("")]ThreeStorey,
            [Description("")]TwoStorey,
            [Description("")]OneStorey,
            [Description("")]StoreyAndAHalf,
            [Description("")]BiLevel,Other
        } 
        public enum ValuationMethods {
            [Description("")]Appraised,
            [Description("")]Estimated,
            [Description("")]PurchasePrice
        }
        public enum PropertyTypes { 
            [Description("")]TriPlex, 
            [Description("")]Duplex, 
            [Description("")]TwoStorey, 
            [Description("")]ApartmentLowRise, 
            [Description("")]Detached, 
            [Description("")]Stacked, 
            [Description("")]ThreeStorey, 
            [Description("")]FourPlex, 
            [Description("")]RowHousing, 
            [Description("")]ModularHome, 
            [Description("")]DuplexSemiDetached, 
            [Description("")]SemiDetached, 
            [Description("")]Mobile, 
            [Description("")]StoreyAndAHalf, 
            [Description("")]ApartmenHighRise 
        }
        public enum DwellingTypes { 
            [Description("")]StrataTitle, 
            [Description("")]CompanyTitle, 
            [Description("")]CrownLease, 
            [Description("")]Freehold, 
            [Description("")]OtherTitle, 
            [Description("")]CommunityTitle, 
            [Description("")]TorrensTitle, 
            [Description("")]Leasehold, 
            [Description("")]MiningLease, 
            [Description("")]IndianReserve, 
            [Description("")]Condo 
        }
        public enum Occupancies { 
            [Description("")]OwnerOccupied, 
            [Description("")]OwnerOccupiedRental, 
            [Description("")]Rental, 
            [Description("")]SecondHome 
        }
        public enum PropertyZones { 
            [Description("")]Residential, 
            [Description("")]Commercial, 
            [Description("")]MixedBusiness, 
            [Description("")]Farm 
        }
        public enum SewageTypes {
            [Description("")]HoldingTank, 
            [Description("")]Septic, 
            [Description("")]SepticField, 
            [Description("")]Municipal
        }
        public enum WaterType {
            [Description("")]Well, 
            [Description("")]LakeIntake, 
            [Description("")]Municipal
        }
        public enum ConstructionTypes { 
            [Description("")]New, 
            [Description("")]Existing, 
            [Description("")]Construction 
        }
        public enum BorrowerFlag { 
            [Description("")]Borrower, 
            [Description("")]Lender 
        }

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

    }
}