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
            [Description("{1d235e92-e720-4a6c-8f2e-5be920c0726c}")]LoanLTV

        }
        public enum StreetTypes {
            [Description("{a5572a98-1eec-43c9-ab44-a18d5ab626b6}")]Street,
            [Description("{9932b46e-ee35-4ade-b0f6-18d087fc8a0b}")]Avenue,
            [Description("{b3a449b6-1f4a-4647-a25b-20f190d0c302}")]Road,
            [Description("{6a2b5561-fd05-49e1-ad30-b77932447054}")]Crescent,
            [Description("{b555850e-0366-4459-b531-a96330cf0154}")]Boulevard

        }
        public enum Keys {
            [Description("{67436ac7-d398-41d1-84bc-c471e5d8d1a6}")]CustomerAccountNumber,
            [Description("{ef3baea0-8d36-4c5a-8a2d-6ce9e119335b}")]MortgageAccountNumber,
            [Description("{55cddee5-a67b-465a-9ddd-2faf2967c6f0}")]CustomerBeaconScore
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
        public enum Product {
            [Description("{dce2b5e4-c3a2-4fdc-9fa3-da56dfeb15d9}")]Five_Year_Fixed_NBF8_NestoConversion,
            [Description("{b24b8415-c1e9-47cc-9480-1763e583c82f}")]Five_Year_Fixed_NBF8_LessFrillsNestoConversion
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
            [Description("{b7ce8dda-ac9d-465e-81e9-0eeaf77671bc}")]Miss
        };
        public enum Gender { 
            [Description("{194c7aac-d71d-4b55-a656-54730963d070}")]Male, 
            [Description("{a94e0e95-e380-4548-b35e-6798ad35ac4f}")]Female
        }
        public enum Province { 
            [Description("{c83d18a5-9e0e-45c8-8b6e-540f967568af}")]Alberta, 
            [Description("{67c901ea-3dd8-4a76-a484-4b87e58210b7}")]BritishColumbia, 
            [Description("{dc776021-dc28-4735-8097-68e791e53ad5}")]Manitoba, 
            [Description("{64688a2c-79e6-49a9-9727-1fbea6ace067}")]NewBrunsWick, 
            [Description("{975770fd-ca59-4968-a46d-d38068310e03}")]Newfoundland, 
            [Description("{e27c701d-302a-400d-85c9-1a7439e9634d}")]NorthWestTerritories, 
            [Description("{e7b7bb10-cb93-45b0-b35e-f7850ed5606a}")]NovaScotia, 
            [Description("{206fcaec-7b5b-4653-bd81-2e47293a99c9}")]Nunavut, 
            [Description("{3158056b-987a-44f3-9753-62830297d1ae}")]Ontario, 
            [Description("{c81bec84-ec29-45cd-88dd-0eef76855ff6}")]PrinceWdwardIsland, 
            [Description("{794e7e04-6b05-41ca-82e0-862817fc4876}")]Quebec, 
            [Description("{b2240751-a3ca-4300-9a1f-e156eb14a80c}")]Saskatchewan, 
            [Description("{861c4f9d-01be-467e-a9ac-797a7d9bf141}")]Yukon 
        };
        public enum Country { [Description("{0df084f1-797c-4ec1-b899-5e3f0df40060}")]Canada }
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