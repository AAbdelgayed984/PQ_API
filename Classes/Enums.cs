using System;
using System.ComponentModel;
using System.Reflection;

namespace PQ_API.Classes
{
    public class Enums
    {
        public enum AddressType {
            [Description("{0de1ec13-ed16-4f30-9004-1ad1c2c3325f}")]Mailing,
            [Description("{07f2753b-0ace-4d69-b8ed-0137f68a3f9a}")]Current
        }
        public enum ContactType {
            [Description("{e97a2f58-e322-421d-afe6-7c175adfbace}")]HomePhone,
            [Description("{29411831-e939-4357-940a-44f55b4a5c9b}")]MobilePhone,
            [Description("{fde55d9b-a337-41e9-a08f-1cc2f013ee3a}")]WorkPhone,
            [Description("{e55bf678-498b-4d57-89d7-20e933a7cf37}")]Email,
        }
        public enum BalanceType {
            [Description("{cf421ec7-af23-474c-9f8f-46e6b899075f}")]Principal,
            [Description("{57af2f0d-9ec7-46c7-9468-cf633f9b4930}")]Approved,
            [Description("{ab9ae444-3ec5-425c-be24-121b1618669e}")]AvailableCredit,
            [Description("{b0d3b9a3-a4e6-40c9-818f-e9e60df7643b}")]Unadvanced,
            [Description("{e5c24ad5-75f4-4cf6-8bc0-5b0e833d4cc4}")]Unapplied,
            [Description("{1d235e92-e720-4a6c-8f2e-5be920c0726c}")]LoanLTV,
            [Description("{79965eeb-23ab-4dfa-ae5c-f2c6c65ad098}")]MortgageInsurancePremium,
            [Description("{5eafa5fc-7a12-4f7c-88dd-fa8a493a5ca2}")]MortgageInsuranceTax,
            [Description("{9aa4f4c2-dd44-4cc6-9b88-b0e57a22df05}")]CashBack,
            [Description("{f838aa0b-746e-435e-8630-ea6d10a3004d}")]CMHCLoanLTV,
            [Description("{1d235e92-e720-4a6c-8f2e-5be920c0726c}")]LoanApplicationLTV,
            [Description("{af123d17-e8cf-4c6d-8cf3-64b4c8adf334}")]CombinedLTV,
            [Description("{1fa7b943-bf68-425e-83ef-9e88bb4f7acd}")]LoanAmount

        }
        public enum Keys {
            [Description("{67436ac7-d398-41d1-84bc-c471e5d8d1a6}")]CustomerAccountNumber,
            [Description("{6985ea0a-9c9b-42d7-8b7d-1392f6f38c03}")]NestoAccountID,
            [Description("{ae772b76-e943-4627-a295-16fd754596a3}")]NestoSubmissionID,
            [Description("{ef3baea0-8d36-4c5a-8a2d-6ce9e119335b}")]ARMnetControlID,
            [Description("{55cddee5-a67b-465a-9ddd-2faf2967c6f0}")]CustomerBeaconScore
        }
        public enum MIStatus {
            [Description("Approved")]Approved,
            [Description("Approved_Insurable")]Approved_Insurable,
            [Description("Cancel_Confirmation")]Cancel_Confirmation,
            [Description("Error")]Error,
            [Description("INSURABLE")]INSURABLE
        }
        public enum MIType {
            [Description("{79e873bc-433b-44a0-b19e-dc6c88c524b9}")]CMHC_Full_Service,
            [Description("{58a8e638-bcab-443c-aabf-56837988b141}")]CMHC_Self_Employed_Simplified,
            [Description("{296ef5df-ace1-49b9-9343-8e43ec59f34f}")]GNW_CG_Heloc_Partial_5yr,
            [Description("{2e5be5b2-d94f-40ff-8ddb-0829917c26c0}")]GNW_CG_Family_Plan,
            [Description("{45ce96ac-65b6-4296-9469-999978eac347}")]GNW_CG_Spousal_Buyout,
            [Description("{71cb7285-6e3a-4ca7-9145-84c75d866bee}")]GNW_CG_Borrowed_Downpayment,
            [Description("{ba619467-88ae-4227-a05b-b672dc6b3c1b}")]GNW_CG_Staff_Loan,
            [Description("{bbeb5f05-7a52-49e9-b454-6ae9dd51601a}")]GNW_CG_Cash_Back,
            [Description("{c62a38c7-be99-427f-a821-465b688a6eb2}")]GNW_CG_Full_Service,
            [Description("{cb20eda2-eb29-4e88-a6bc-46349dfc07d9}")]GNW_CG_New_To_Canada,
            [Description("{ece4b7e6-2ff8-4f40-927f-ae395c3fc20f}")]GNW_CG_Vacation_Property,
            [Description("{fc41020b-2e1f-4743-b380-172c834c053d}")]GNW_CG_Alt_A ,
        }
        public enum PropertyListingType {
            [Description("1")]MLSListing,
            [Description("2")]FISBO,
        }
        public enum Association {
            [Description("{9060212e-b888-4c3a-b9e9-6715f509b9a7}")]Brand,
            [Description("{b71597db-b0e9-47ad-82c9-9d591227ad28}")]Investor,
            [Description("{8da24f0c-eb90-484a-b03c-fdd823c1c1b8}")]Agent,
            [Description("{69783579-9e83-4e82-bb25-7b3d52b0f99d}")]SubAgent,
            [Description("{221467ab-1ae4-41a8-880e-b41ac49730c5}")]SubmittingAgent,
            [Description("{e19af065-c1b1-42fa-b923-7e288c869a8c}")]MortgageInsurer,
            [Description("{5b150cd7-7539-41ad-9485-1966d701bba0}")]SourceOfBusiness,
            [Description("{146afcaa-059b-469e-a000-0103e84144dc}")]PrimaryBorrower,
            [Description("{627cb28d-8393-4878-b06f-38747946b792}")]CoBorrower,
            [Description("{f3fdab19-241b-4243-861b-4d0a4509f127}")]Guarantor ,
        }
        public enum Status {
            [Description("{a5f629d3-ac8a-4a4b-afb8-e99dca3de68f}")]Current,
        }
        public enum Broker {
            [Description("{71998d81-bf1a-4ccf-a14c-500d28133378}")]OliverioVittorio
        }
        public enum Brand {
            [Description("{48228209-0b00-4716-870e-fcf48f53b34c}")]Nesto
        }
        public enum Investor {
            [Description("{798b53e1-5b9d-490a-8001-5005d97d4ba5}")]NBF8,
            [Description("{5f1b0058-130f-461f-aa53-5b685e60d185}")]TDSI3,
        }
        public enum MartialStatus { 
            [Description("{1c28faaa-3f5e-48c0-8023-2ac2a8bf3816}")]Widowed, 
            [Description("{70ff199a-78ab-478a-9024-9e75ed4420fd}")]Single, 
            [Description("{a8cc41fb-7888-4e44-91d8-615b75d93828}")]Divorced, 
            [Description("{d498de07-6440-4743-9c41-470cae71b8dc}")]Separated, 
            [Description("{e1b912d6-9468-41d5-adac-6dfc3d2cb7e7}")]Married, 
            [Description("{ebc14aee-45fd-40cb-bbf0-7367ebaaae7e}")]CommonLaw
        };
        public enum Title { 
            [Description("{bdd8ab1a-cae4-4ff5-b856-a547229f711d}")]Mr, 
            [Description("{19f2dc66-3760-4579-802b-9fbb2e86dfad}")]Ms, 
            [Description("{36affe6b-2f82-4129-a562-8fead2eb890f}")]Mrs, 
            [Description("{b7ce8dda-ac9d-465e-81e9-0eeaf77671bc}")]Miss,
            [Description("{6d1f48b5-2f7b-4caf-9247-894e1da21dce}")]Dr, 
            [Description("{b77a0038-83a9-49e7-8cfa-e61963323e85}")]Rev, 
            [Description("{3fbcd2ca-757c-4ac4-8559-358444be74de}")]Judge
            
        };
        public enum Gender { 
            [Description("{194c7aac-d71d-4b55-a656-54730963d070}")]Male, 
            [Description("{a94e0e95-e380-4548-b35e-6798ad35ac4f}")]Female
        }
        public enum BasisOfEmployment { 
            [Description("{580BF359-6991-488e-9DBB-ED65CF92BF41}")]PartTime, 
            [Description("{32B24966-AF08-4d18-86D8-1BEC4D6C3FE2}")]FullTime,
            [Description("{399c41dd-92ed-454a-bfd9-b72161084d68}")]Seasonal
        }

        public enum IncomeFrequency { 
            [Description("{2B6B0933-34B8-4004-9788-ACE33BAC581B}")]	Six_Monthly,
            [Description("{b5dd2e27-2ac1-4921-9caf-f1cf4e8a4ca8}")]	Accelerated_Biweekly,
            [Description("{caf97048-abd2-4bf6-b3d0-b04ff78195eb}")]	Accelerated_Weekly,
            [Description("{EC2E0FC0-7025-4b95-A89F-DE7275E67CFB}")]	Annual,
            [Description("{529F0DF2-3394-4e32-B336-895699D75488}")]	Biweekly,
            [Description("{52A3A7A8-AF07-4327-B5AA-B66FB4288206}")]	Monthly,
            [Description("{3EC333B0-7CC8-484f-A06E-D077A1C60208}")]	Quarterly,
            [Description("{0c0c1d15-02d7-4efa-8390-426166c1d034}")]	Semi_Monthly,
            [Description("{FC99A346-78A0-44fd-9E4F-A4DC9E926EFB}")]	Weekly
        }
        public enum Province { 
            [Description("Alberta")]Alberta, 
            [Description("BritishColumbia")]BritishColumbia, 
            [Description("Manitoba")]Manitoba, 
            [Description("NewBrunsWick")]NewBrunsWick, 
            [Description("Newfoundland")]Newfoundland, 
            [Description("NorthWestTerritories")]NorthWestTerritories, 
            [Description("NovaScotia")]NovaScotia, 
            [Description("Nunavut")]Nunavut, 
            [Description("Ontario")]Ontario, 
            [Description("PrinceWdwardIsland")]PrinceWdwardIsland, 
            [Description("Quebec")]Quebec, 
            [Description("Saskatchewan")]Saskatchewan, 
            [Description("Yukon")]Yukon 
        };
        public enum Country { 
            [Description("{0df084f1-797c-4ec1-b899-5e3f0df40060}")]Canada, 
            [Description("{FBBCC9C5-3D35-40c8-A093-90BC18720514}")]US    
        }

        public enum Language { 
            [Description("English")]English, 
            [Description("French")]French 
        }
        public enum ClientType { 
            [Description("{627cb28d-8393-4878-b06f-38747946b792}")]CoBorrower, 
            [Description("{146afcaa-059b-469e-a000-0103e84144dc}")]PriBorrower, 
            [Description("{f3fdab19-241b-4243-861b-4d0a4509f127}")]Guarantor 
        }
        public enum PaymentFrequencies { 
            [Description("")]EndOfMonth, 
            [Description("")]Monthly, 
            [Description("")]Weekly, 
            [Description("")]BiWeekly, 
            [Description("")]SemiMonthly 
        }
        public enum LoanPurposes { 
            [Description("{42657ef3-305c-4598-83b1-dd0f86bdd601}")]ETO, 
            [Description("{6514fb1e-bf8c-4175-904b-462e6507e40f}")]TransferOrSwitch, 
            [Description("{882b042d-e8af-448d-a9fd-90406cbc9a73}")]Purchase, 
            [Description("{b944e5e5-cf0d-4b0c-8595-b154e430aadf}")]Port, 
            [Description("{e3916dfb-d742-4668-97e0-adbc674f65b5}")]Refinance, 
            [Description("{e97ecec7-78ec-495a-97b9-bce97a67300d}")]PurchasePlusImprovement 
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
            [Description("{fe50b0db-e29a-44c9-ae25-429cb2ba8bd4}")]ApartmentHighRise,
            [Description("{801fbf67-9a05-44dd-9e6a-6e874d27c202}")]ApartmentLowRise,
            [Description("{887acbe8-674b-44fb-93b7-5224d755fd54}")]Detached,
            [Description("{632061fa-8e66-4054-823b-bf4b7626933c}")]Duplex,
            [Description("{4c41905e-8ea3-4e97-9a72-f6fe0947ec42}")]Duplex_Detached,
            [Description("{c05ead17-4d35-4371-ad8f-9d3b31e27b85}")]Duplex_Semi_Detached,
            [Description("{235c8135-0eac-42f6-8252-8b2ebca6f759}")]Filogix_Bi_Level,
            [Description("{3c92f619-3832-4bcc-a985-d6764bd35fd3}")]Filogix_OneStorey,
            [Description("{31cb4a5a-dab3-4033-a408-4d2cab385d3f}")]Filogix_Other,
            [Description("{3b7c4746-305f-441a-92b0-b4509bc7c7ea}")]Filogix_SplitLevel,
            [Description("{e036b51f-eb46-486a-8da6-21350f1b8682}")]Filogix_StoreyandaHalf,
            [Description("{93e2e3d2-be18-4f39-8f4d-1f1d17739111}")]Filogix_ThreeStorey,
            [Description("{57b65db1-04c7-4e4b-af85-0fabd616452e}")]Filogix_TwoStorey,
            [Description("{9e40bcc0-65f1-4694-ac30-e7cadbf7d4e2}")]FourPlex_Detached,
            [Description("{ec09acc6-73bc-4f3f-8d0b-146053770797}")]FourPlex_Semi_Detached,
            [Description("{d95ec699-ab6c-44c1-a4e2-a4da4161b25a}")]Mobile,
            [Description("{fd959ea7-1827-476d-9cdf-efd2be354e22}")]ModularHome_Detached,
            [Description("{c05c36ac-b35a-44ed-b509-b9a5234d0c00}")]ModularHome_Semi_Detached,
            [Description("{69905f8b-c78b-42cb-b751-14509d90be77}")]Other,
            [Description("{a4375fec-faff-478b-b3bc-ebd063d38f34}")]RowHousing,
            [Description("{c295ff07-6c4d-4011-9154-88cd83e9dc61}")]Semi_Detached,
            [Description("{935afeae-a9ee-4273-92c6-22aa0db35e03}")]Stacked,
            [Description("{6b64d131-d1cb-41fe-84ef-78e3b60ab134}")]TriPlex_Detached,
            [Description("{3cebdbbc-6462-4e04-8882-4a1d9439eeeb}")]TriPlex_Semi_Detached,
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
            [Description("{cc43d708-e4f0-4a26-a6ec-d452d7824b83}")]OwnerOccupied, 
            [Description("{ba53ba79-3005-408d-8e37-c3ad27bb965e}")]OwnerOccupiedRental, 
            [Description("{50bb4e1b-d9e6-4a1b-96ca-fcfa53290b2c}")]Rental, 
            [Description("{203697e3-5967-4f17-9e56-a3d46325fc43}")]SecondHome 
        }
        public enum PropertyZones { 
            [Description("")]Residential, 
            [Description("")]Commercial, 
            [Description("")]MixedBusiness, 
            [Description("")]Farm 
        }
        public enum SewageTypes {
            [Description("{caeef52d-b807-4f4a-8e4d-7c6a4a40ae92}")]HoldingTank, 
            [Description("{a4f9f7e2-e414-403f-9396-ccf84735d8f4}")]Septic, 
            [Description("{c4e5203e-3d16-4aa6-af11-aacd060b5e7a}")]SepticField, 
            [Description("{3823a3cf-0e5e-4443-8a2a-644bff4b986a}")]Municipal
        }
        public enum WaterType {
            [Description("{9ff4a8f7-38ba-463a-bd13-a9b5f98c82eb}")]Well, 
            [Description("{87ea126c-ff0f-4a7b-a3c8-328fd00e2407}")]LakeIntake, 
            [Description("{a85d4ef6-0d46-4c79-9b5f-4a4c070ce830}")]Municipal,
            [Description("{721203d0-d197-4bc1-b0cc-0793a2c3582c}")]Cistern
        }
        public enum ValueIndex {
            [Description("{26037eb2-73be-4f5d-ba91-82d9b9a8e095}")]Estimated, 
            [Description("{2e0bc9fc-2ecf-4d9b-8065-36a1ea09c298}")]Appraised, 
            [Description("{3ae5df92-cb42-44fb-afa8-0e33b6c230d8}")]PurchasePrice
        }
        public enum ConstructionTypes { 
            [Description("{eb4abc9f-08dc-491d-98c3-854222b93363}")]New, 
            [Description("{cca98738-9842-4993-83b7-446e7afe650e}")]Existing, 
            [Description("{72e38b5c-8c9b-46d4-b912-b771edd49695}")]Construction 
        }
        public enum BorrowerFlag { 
            [Description("Borrower")]Borrower, 
            [Description("Lender")]Lender 
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