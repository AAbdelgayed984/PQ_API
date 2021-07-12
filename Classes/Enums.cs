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
        public enum LoanFeatures {
            [Description("{92eca3f0-4744-4396-ae04-032b577bffcf}")]LOB_A,
            [Description("{cc417448-be71-47ce-a517-d85b30f67749}")]LOB_B,
            [Description("{7d57b0b4-e802-4dbb-9030-e835d2dfbcd6}")]FirstMortgage,
            [Description("{6b91ca7a-583f-4efa-b2bb-f681ffb81f5b}")]SecondMortgage,
            [Description("{2234842e-3f58-46a2-869c-d7488d05b2eb}")]ThirdMortgage,
            [Description("{98c22b71-18a4-40f7-bd92-117135bfa775}")]Loan_LessFrills,
            [Description("{cbbaea2f-29b4-4470-bb4b-3b78acf9b75a}")]FirstHomeOwner,
            [Description("{7b574384-f72d-4263-98f8-820ea9417cf1}")]NewToCanada        
        }

        public enum BalanceType {
            [Description("{cf421ec7-af23-474c-9f8f-46e6b899075f}")]Principal,
            [Description("{57af2f0d-9ec7-46c7-9468-cf633f9b4930}")]Approved,
            [Description("{ab9ae444-3ec5-425c-be24-121b1618669e}")]AvailableCredit,
            [Description("{b0d3b9a3-a4e6-40c9-818f-e9e60df7643b}")]Unadvanced,
            [Description("{e5c24ad5-75f4-4cf6-8bc0-5b0e833d4cc4}")]Unapplied,
            [Description("{79965eeb-23ab-4dfa-ae5c-f2c6c65ad098}")]MortgageInsurancePremium,
            [Description("{5eafa5fc-7a12-4f7c-88dd-fa8a493a5ca2}")]MortgageInsuranceTax,
            [Description("{9aa4f4c2-dd44-4cc6-9b88-b0e57a22df05}")]CashBack,
            [Description("{f838aa0b-746e-435e-8630-ea6d10a3004d}")]CMHCLoanLTV,
            [Description("{1d235e92-e720-4a6c-8f2e-5be920c0726c}")]LoanApplicationLTV,
            [Description("{af123d17-e8cf-4c6d-8cf3-64b4c8adf334}")]CombinedLTV,
            [Description("{1fa7b943-bf68-425e-83ef-9e88bb4f7acd}")]LoanAmount,
            [Description("{f6e26460-bf66-40fd-9bb2-112ebc2f2b07}")]Application

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
        public enum MIIndicator {
            [Description("{388f8388-7a91-4ab8-940c-4631bba16d6a}")] GNW_RequiredStdGuidelines,
            [Description("{445246f9-a449-4958-b464-aaa1ac871ad4}")] GNW_NotRequired,
            [Description("{a0d2b1e3-9468-4e7b-94e0-8d4109da3f84}")] GNW_UWRequired,
            [Description("{c4194a4f-e86f-4787-aa1d-fcdf4cefbe8b}")] GNW_LoanAssessment,
            [Description("{e9c86378-b41f-4b99-9ffb-ad12b92bca29}")] CMHC_NotRequired,
            [Description("{6b406e32-63a3-463f-b222-ca39918a1f95}")] CMHC_RequiredStdGuidelines,
            [Description("{fc53eb72-4e5a-4d53-a83e-c17bb77be172}")] CMHC_LoanAssessment,
            [Description("{fad2565f-9bbb-43db-a4c9-b81185ea10f6}")] CMHC_UWRequired    
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
            [Description("{48228209-0b00-4716-870e-fcf48f53b34c}")]NestoBroker
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
        public enum UnitOfMeasure_StudioSize {
            [Description("{88e5429b-f99a-4bf2-a7b3-f2ca4dba99c7}")] MeasuringUnit_Sq_Ft,
            [Description("{1ada9211-5c3f-40c1-b57c-6646c7342120}")] MeasuringUnit_Sq_M
            
        }
        public enum UnitOfMeasure_LandSize {
            [Description("{b5c8e141-7d45-4a11-9f2b-3e70b6dd4b34}")] MeasuringUnit_Sq_Ft,
            [Description("{50d8955e-ba74-4a5f-b90c-9178e0451c53}")] MeasuringUnit_Sq_M,
            [Description("{2edda548-b312-43b0-abf0-0c0ac1632888}")] MeasuringUnit_Hectares,
            [Description("{dca3f39b-bf0b-419c-876a-0ff10c371dcf}")] MeasuringUnit_Acres            
        }
        public enum ContractualPaymentTask {
            [Description("{12b8909a-5401-422b-950a-8fa742d9893d}")] ContractualPayment_EndofMonth,
            [Description("{6333b957-1109-4751-a933-d8c7a2879a27}")] ContractualPayment_AcceleratedBiWeekly,
            [Description("{8064b42f-619a-4fdf-885c-ab63dfdeac2b}")] ContractualPayment_AcceleratedWeekly,
            [Description("{88a98817-c0f0-4206-8290-167bb524aa65}")] ContractualPayment_Monthly,
            [Description("{935dbb77-1602-4dbe-96aa-42f1a91e2abb}")] ContractualPayment_Weekly,
            [Description("{a2c31b0a-c34a-4431-a991-e090f05c9318}")] ContractualPayment_BiWeekly,
            [Description("{fcb0709a-5916-45e4-91d5-76ff5f2f81a3}")] ContractualPayment_SemiMonthly,
        }
        public enum ActualPaymentTask {
            [Description("{0af12292-fa2b-42de-9a82-5becc30cb242}")] ActualPayment_EndofMonth,
            [Description("{8c427a27-35be-45c2-aed0-07ba64d687fa}")] ActualPayment_AcceleratedBiWeekly,
            [Description("{bf50559c-f2b2-4c98-a83b-02df843f3801}")] ActualPayment_AcceleratedWeekly,
            [Description("{9b8ab712-ebf1-4205-a886-5d8bbe5b10ab}")] ActualPayment_Monthly,
            [Description("{06309665-f0d8-4277-97b9-2e43d6cc146a}")] ActualPayment_Weekly,
            [Description("{d3098c32-ae09-4976-a402-041fc0c639c2}")] ActualPayment_BiWeekly,
            [Description("{d2dd1a19-9411-4294-b844-a6fe06a53abe}")] ActualPayment_SemiMonthly,
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
        public enum IndustrySector {
            [Description("{80c8fa19-c35f-460a-84ee-21d1f34e38e5}")] Accomodation,
            [Description("{e6a58efb-f0d4-427b-9a99-8dec4546b511}")] Accounting,
            [Description("{51490aea-4e26-4578-8ebd-d63f35f0f3b6}")] Administration,
            [Description("{5d901307-e38b-4df9-9fc9-0fb1af1c303c}")] Agriculture,
            [Description("{039f8fff-5bb0-4fa8-9a9c-64ba432a91b6}")] ArtsAndEntertainment,
            [Description("{d06df872-f55e-4344-a3dc-71000752ea85}")] Banking_Finance,
            [Description("{49838f01-a644-4839-9e86-7a1299ce82cc}")] BusinessServices,
            [Description("{abf1b6c9-6211-4e4f-982a-2cbfcd972460}")] Construction,
            [Description("{05b0f72e-8e40-4c13-89c2-52f6d2364540}")] Consulting,
            [Description("{25462b7f-7ce0-4191-8f19-f54d647b57d0}")] ConsumerServices,
            [Description("{c22de49e-b16b-47dd-b7ec-b64f2d48b7d3}")] Design_DirectionAndCreativeManagement,
            [Description("{772bad3f-98c0-4d85-baa9-092ddb45ad04}")] Distributors_DispatchersAndProcessors,
            [Description("{43502e4f-c529-4fb6-b1f2-d5e9e78dd0ef}")] Education,
            [Description("{8dfadb2c-91ca-4b43-9bd8-b555c4a18bc9}")] Financial,
            [Description("{81b62e79-8382-492c-a9f2-ff63cef6923c}")] Forestry_FishingAndHunting,
            [Description("{8d75de5a-1444-4c69-8068-9d815b5401e3}")] Government,
            [Description("{92f6ce30-159f-4133-88ec-7c1f65e4a03a}")] HealthCare,
            [Description("{864eab88-2291-42bf-aa2c-7ada1195c485}")] Insurance,
            [Description("{7655cf81-d341-45ef-a697-927fd0ee573c}")] LegalServices,
            [Description("{533e45e4-bb86-46a8-8f20-20075e6d9d52}")] Manufacturing,
            [Description("{0c010cef-b57d-4d00-9cdf-dbc9a7b279a2}")] Mining_Quarrying_OilAndGasExtraction,
            [Description("{534d1f7c-4fbe-4a9c-826a-c83ba92a5053}")] RealEstate,
            [Description("{a404a887-c98d-4abc-82d1-e04619102906}")] RentalAndLeasing,
            [Description("{c4c15289-45d1-4e31-8a25-83edf53b2266}")] RestaurantAndFoodService,
            [Description("{5b8817ad-0519-4cda-a4ca-0d0af0c13e6b}")] Retail,
            [Description("{de70ee5d-0718-4d53-8b10-7c6d9be76529}")] Sciences,
            [Description("{df1767d5-a320-41b1-9ab3-907fb9b2244b}")] Services,
            [Description("{813feab6-7557-456a-a503-65d11d14facf}")] SocialServices,
            [Description("{41a3058c-a839-4e96-85b1-64b7f597e888}")] Technology,
            [Description("{30b30958-707e-42f0-a526-855459d43b43}")] TransportationAndWarehousing,
            [Description("{ab337280-d783-4e60-8b15-0fef7fe9e7b1}")] Utilities,
        }
        public enum LoanType {
            [Description("{19dba771-2e7b-4d3b-a0b9-3277e9fbad48}")] Mortgage,
            [Description("{b2644953-5045-4be4-8d57-afa0389ef8da}")] MultipleComponent,
            [Description("{dc504338-5022-447d-9767-46b35ca119a8}")] SecuredLoan,
            [Description("{a67464a8-f765-4968-8a4e-29dc07685da7}")] SecuredLOC,
        }
        public enum RatioType
        {
            [Description("{8508ed02-20a3-4d81-bc76-cc007cb360c4}")] Actual_GDS,
            [Description("{efd3c80b-ee94-467a-9490-7e0811c17db1}")] Actual_TDS,
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
            [Description("PrinceEdwardIsland")]PrinceEdwardIsland, 
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
            [Description("{12b8909a-5401-422b-950a-8fa742d9893d}")]EndOfMonth, 
            [Description("{88a98817-c0f0-4206-8290-167bb524aa65}")]Monthly, 
            [Description("{935dbb77-1602-4dbe-96aa-42f1a91e2abb}")]Weekly, 
            [Description("{a2c31b0a-c34a-4431-a991-e090f05c9318}")]BiWeekly, 
            [Description("{fcb0709a-5916-45e4-91d5-76ff5f2f81a3}")]SemiMonthly,
            [Description("{6333b957-1109-4751-a933-d8c7a2879a27}")] AcceleratedBiWeekly,
            [Description("{8064b42f-619a-4fdf-885c-ab63dfdeac2b}")] AcceleratedWeekly
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
            [Description("{2a43edda-fb7b-4e4f-b33c-e624a48c63e2}")]CMHC, 
            [Description("{b9d52524-7952-4da9-872e-7b5ae1da86d1}")]Genworth, 
            [Description("{797e876e-411f-47f4-b73a-d2d67c0a9798}")]CanadaGauranty 
        }

        public enum PropertyStyles {
            [Description("{1da8e0d7-8a73-468c-8d02-ed8bb44551d9}")]SplitLevel,
            [Description("{3b806ac7-9262-4420-bdd9-20e19d8f93aa}")]ThreeStorey,
            [Description("{622ea90c-bfb7-42ee-a607-e6ea76c0723b}")]TwoStorey,
            [Description("{7c8944f2-c510-484a-80ac-085b37f76dfc}")]OneStorey,
            [Description("{912c3e04-c2c4-4a2b-a7c9-9f6bd4f796de}")]StoreyAndAHalf,
            [Description("{c56b6919-ad07-49f0-813f-465789427e20}")]BiLevel,
            [Description("{dc703287-f0c8-4bba-9d0d-12cf1a59eab0}")]Other
        } 
        public enum PaymentType {
            [Description("{9a13ccc2-df13-46c0-99cf-ff165147792f}")] PrincipalAndInterest,
            [Description("{ef343d71-fc34-4c2d-9c4a-4ef09862fbc8}")] InterestOnly
        }
        public enum ValuationMethods {
            [Description("{2e0bc9fc-2ecf-4d9b-8065-36a1ea09c298}")]Appraised,
            [Description("{26037eb2-73be-4f5d-ba91-82d9b9a8e095}")]Estimated,
            [Description("{3ae5df92-cb42-44fb-afa8-0e33b6c230d8}")]PurchasePrice
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
            [Description("{04157226-e7a1-4c79-be52-83900c41b2ce}")]StrataTitle, 
            [Description("{04d9ea76-ad43-4860-befb-6081d382103e}")]CompanyTitle, 
            [Description("{71cd3202-a5ae-4764-8512-97666327e596}")]CrownLease, 
            [Description("{829c04f0-a5d6-4499-b415-9957f6801585}")]Freehold, 
            [Description("{8dad99e1-80ce-4da6-a61b-23bd4b60e6b9}")]OtherTitle, 
            [Description("{a176fef3-7a75-44ec-b9aa-af85eebcad7d}")]CommunityTitle, 
            [Description("{b7d44d0f-7182-44d3-9201-22a08708ce16}")]TorrensTitle, 
            [Description("{ccb6c947-1877-4476-a8fa-b1c3bf8f40ff}")]Leasehold, 
            [Description("{dda326cf-987f-4685-b8b7-10b2951e6878}")]MiningLease, 
            [Description("{eb5091cc-e192-4c61-817d-a9ba155375ec}")]IndianReserve, 
            [Description("{eea20a2d-6c95-4eb3-95fe-5816555ff37e}")]Condo,
            [Description("{201a9ee8-0755-48c6-ae19-73bedc27def8}")]CommonLaw

        }
        public enum Occupancies { 
            [Description("{cc43d708-e4f0-4a26-a6ec-d452d7824b83}")]OwnerOccupied, 
            [Description("{ba53ba79-3005-408d-8e37-c3ad27bb965e}")]OwnerOccupiedRental, 
            [Description("{50bb4e1b-d9e6-4a1b-96ca-fcfa53290b2c}")]Rental, 
            [Description("{203697e3-5967-4f17-9e56-a3d46325fc43}")]SecondHome 
        }
        public enum PropertyZones { 
            [Description("{80baf9da-932f-48d4-9bac-fc3feb3084ef}")]Residential, 
            [Description("{4b96b39b-1b2a-414a-8c5c-43ef40a09a6c}")]Commercial, 
            [Description("{0a332076-465e-416b-985a-bf30f09e93e2}")]MixedBusiness, 
            [Description("{04ae3049-4e29-461b-a2fe-56edf8292cc7}")]Farm 
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