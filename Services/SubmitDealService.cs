using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using PQ_API.Classes;
using PQ_API.DataConnect;
using PQ_API.Interfaces;

namespace PQ_API.Services
{
    public class SubmitDealService : ISubmitDealService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private User _user;
        private readonly RubiDBSettings _rubiDBSettings;
        private IUserService _userService;
        private IDealService _dealService;
        private IClientService _clientService;
        private RUBIDataConnect _rubiDataConnect;
        public SubmitDealService(RubiDBSettings rubiDBSettings, IUserService userService, IDealService dealService, IClientService clientService, IHttpContextAccessor httpContextAccessor)
        {
             _rubiDBSettings = rubiDBSettings;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
            _dealService = dealService;
            _clientService = clientService;
            _user = _userService.GetById(_httpContextAccessor.HttpContext.User.Claims.First(i => i.Type == "id").Value);
            _rubiDataConnect = new RUBIDataConnect(rubiDBSettings.ConnectionString);
        }

        public SubmitDealResponse SubmitDeal(SubmitDealRequest request)
        {
            // Declarations
            string Product_XSU_ID = Enums.GetEnumDescription( request.AccountDetails.Status);
            string Brand_CMR_ID = Enums.GetEnumDescription( request.AccountDetails.Brand);
            string Investor_CMR_ID = Enums.GetEnumDescription( request.AccountDetails.Investor);
            string Broker_CMR_ID = Enums.GetEnumDescription( request.AccountDetails.Broker);
            string MI_CMR_ID = Enums.GetEnumDescription(request.MortgageInsuranceDetails.MortgageInsurer);

            // Deal Master Details
            string RMR_ID = _rubiDataConnect.PQ_ServicingAPI_Product_MasterReferenceFunc(request.AccountDetails.Product, Product_XSU_ID);
            
            // Deal Associations
            string Brand_LMR_ID = _rubiDataConnect.PQ_ServicingAPI_Link_MasterReferenceFunc(Brand_CMR_ID, RMR_ID, Enums.GetEnumDescription( Enums.Association.Brand)) ;
            string Investor_LMR_ID = _rubiDataConnect.PQ_ServicingAPI_Link_MasterReferenceFunc(Investor_CMR_ID, RMR_ID, Enums.GetEnumDescription( Enums.Association.Investor)) ;
            string MortgageInsurer_LMR_ID = _rubiDataConnect.PQ_ServicingAPI_Link_MasterReferenceFunc(MI_CMR_ID, RMR_ID, Enums.GetEnumDescription( Enums.Association.MortgageInsurer));
            if (!(request.AccountDetails.Brand == Enums.Brand.Nesto))
            {
                string Agent_LMR_ID = _rubiDataConnect.PQ_ServicingAPI_Link_MasterReferenceFunc(Broker_CMR_ID, RMR_ID, Enums.GetEnumDescription( Enums.Association.Agent)) ;
                string SubAgent_LMR_ID = _rubiDataConnect.PQ_ServicingAPI_Link_MasterReferenceFunc(Broker_CMR_ID, RMR_ID, Enums.GetEnumDescription( Enums.Association.SubAgent)) ;
                string SubmittingAgent_LMR_ID = _rubiDataConnect.PQ_ServicingAPI_Link_MasterReferenceFunc(Broker_CMR_ID, RMR_ID, Enums.GetEnumDescription( Enums.Association.SubmittingAgent)) ;
            }
            
            // Deal Keys
            string NestoSubmissionID_YMR_ID = _rubiDataConnect.PQ_ServicingAPI_Keys_MasterReferenceFunc(RMR_ID, request.RequestID, Enums.GetEnumDescription(Enums.Keys.NestoSubmissionID));
            string MortgageAccountNumber_YMR_ID = _rubiDataConnect.PQ_ServicingAPI_Keys_MasterReferenceFunc(RMR_ID, request.AccountDetails.MortgageAccountNumber, Enums.GetEnumDescription(Enums.Keys.NestoAccountID));

            // Details
            string LoanDetails_RLM_ID = _rubiDataConnect.PQ_ServicingAPI_Product_LoanMDTFunc(RMR_ID, Enums.GetEnumDescription(request.LoanDetails.LoanPurpose), null, null);
            string LoanDetails_RCTk_ID = _rubiDataConnect.PQ_ServicingAPI_Product_ControlTaskFunc(RMR_ID,Enums.GetEnumDescription(request.LoanDetails.PaymentFrequency),0,0);

            string GDS_RCTi_ID = _rubiDataConnect.PQ_ServicingAPI_Product_ControlRatioFunc(RMR_ID,null,request.LoanDetails.CombinedGDS);
            string TDS_RCTi_ID = _rubiDataConnect.PQ_ServicingAPI_Product_ControlRatioFunc(RMR_ID,null,request.LoanDetails.CombinedTDS);
    
            string MaturityDate_RCD_ID = _rubiDataConnect.PQ_ServicingAPI_Product_ControlDateFunc(RMR_ID,0,request.LoanDetails.MaturityDate);

            // Balances
            string PrincipalBalance_RCB_ID = _rubiDataConnect.PQ_ServicingAPI_Product_ControlBalanceFunc(RMR_ID, Enums.GetEnumDescription(Enums.BalanceType.Principal), request.LoanDetails.OriginalLoanAmount); 
            string CurrentLoanAmountBalance_RCB_ID = _rubiDataConnect.PQ_ServicingAPI_Product_ControlBalanceFunc(RMR_ID, Enums.GetEnumDescription(Enums.BalanceType.LoanAmount), request.LoanDetails.OriginalLoanAmount); 
            string ApprovedBalance_RCB_ID = _rubiDataConnect.PQ_ServicingAPI_Product_ControlBalanceFunc(RMR_ID, Enums.GetEnumDescription(Enums.BalanceType.Approved), request.LoanDetails.ApprovedBalance);            
            string LoanLTV_RCB_ID = _rubiDataConnect.PQ_ServicingAPI_Product_ControlBalanceFunc(RMR_ID, Enums.GetEnumDescription(Enums.BalanceType.LoanLTV), request.LoanDetails.OriginalLTV);            
            string LoanDetails_OriginalLTV_RCB_ID = _rubiDataConnect.PQ_ServicingAPI_Product_ControlBalanceFunc(RMR_ID,Enums.GetEnumDescription(Enums.BalanceType.LoanApplicationLTV),request.LoanDetails.OriginalLTV);
            string LoanDetails_CombinedLTV_RCB_ID = _rubiDataConnect.PQ_ServicingAPI_Product_ControlBalanceFunc(RMR_ID,Enums.GetEnumDescription(Enums.BalanceType.CombinedLTV),request.LoanDetails.OriginalLTV);
            string MortgageInsurer_PremiumAmount_RCB_ID = _rubiDataConnect.PQ_ServicingAPI_Product_ControlBalanceFunc(RMR_ID,Enums.GetEnumDescription(Enums.BalanceType.MortgageInsurancePremium),request.MortgageInsuranceDetails.PremiumAmount); 
            string MortgageInsurer_TaxAmount_RCB_ID = _rubiDataConnect.PQ_ServicingAPI_Product_ControlBalanceFunc(RMR_ID,Enums.GetEnumDescription(Enums.BalanceType.MortgageInsuranceTax),request.MortgageInsuranceDetails.TaxAmount); 
            
            string CertificateNumber_RLMI_ID = _rubiDataConnect.PQ_ServicingAPI_Product_LoanInsuranceFunc(RMR_ID, request.MortgageInsuranceDetails.BulkFlag, null, 0, 0, 0, null, null, false, false, null, null, false, false, request.MortgageInsuranceDetails.CertificateNumber);
 
            // Product Term and Amortization
            string ProductTerm_RCTe_ID = _rubiDataConnect.PQ_ServicingAPI_Product_ControlTermFunc(RMR_ID, request.LoanDetails.ProductTerm_Years, request.LoanDetails.ProductTerm_Months, ( request.LoanDetails.ProductTerm_Years * 12 ) + request.LoanDetails.ProductTerm_Months, 1);
            string AmortizationOriginal_RCTe_ID = _rubiDataConnect.PQ_ServicingAPI_Product_ControlTermFunc(RMR_ID, request.LoanDetails.AmortizationOriginal_Years, request.LoanDetails.AmortizationOriginal_Months, ( request.LoanDetails.ProductTerm_Years * 12 ) + request.LoanDetails.ProductTerm_Months, 2);

            // Features

            // Dates
            string ClosingDate_RCD_ID = _rubiDataConnect.PQ_ServicingAPI_Product_ControlDateFunc(RMR_ID, 1001, request.LoanDetails.ClosingDate);
            string ApplicationDate_RCD_ID = _rubiDataConnect.PQ_ServicingAPI_Product_ControlDateFunc(RMR_ID, 1, request.LoanDetails.ApplicationDate);
            string FirstPaymentDate_RCD_ID = _rubiDataConnect.PQ_ServicingAPI_Product_ControlDateFunc(RMR_ID, 99000, request.PrePaymentPrivileges.NextPaymentDate);
            //Tasks
            string PaymentFrequency_RCTK_ID = _rubiDataConnect.PQ_ServicingAPI_Product_ControlTaskFunc(RMR_ID, Enums.GetEnumDescription(request.LoanDetails.PaymentFrequency), 0, 3);
            // Security
            int RSP_UnitCount;
            switch (request.SecurityPropertyDetails.PropertyType)
                {
                    case Enums.PropertyTypes.Filogix_TwoStorey:
                    case Enums.PropertyTypes.ApartmentLowRise:
                    case Enums.PropertyTypes.Detached:
                    case Enums.PropertyTypes.Stacked:
                    case Enums.PropertyTypes.Filogix_ThreeStorey:
                    case Enums.PropertyTypes.RowHousing:
                    case Enums.PropertyTypes.ModularHome_Semi_Detached:
                    case Enums.PropertyTypes.Semi_Detached:
                    case Enums.PropertyTypes.Mobile:
                    case Enums.PropertyTypes.Filogix_StoreyandaHalf:
                    case Enums.PropertyTypes.ApartmentHighRise:
                    case Enums.PropertyTypes.ModularHome_Detached:
                        RSP_UnitCount = 1;
                        break;
                    case Enums.PropertyTypes.Duplex_Detached:
                    case Enums.PropertyTypes.Duplex:
                    case Enums.PropertyTypes.Duplex_Semi_Detached:
                        RSP_UnitCount = 2;
                        break;
                    case Enums.PropertyTypes.TriPlex_Detached:
                    case Enums.PropertyTypes.TriPlex_Semi_Detached:
                        RSP_UnitCount = 3;
                        break;
                    case Enums.PropertyTypes.FourPlex_Detached:
                    case Enums.PropertyTypes.FourPlex_Semi_Detached:
                        RSP_UnitCount = 4;
                        break;
                    default:
                        RSP_UnitCount = 0;
                        break;
                }

            string RSP_ID = _rubiDataConnect.PQ_ServicingAPI_Product_SecurityPTYFunc(
                RMR_ID,
                request.SecurityPropertyDetails.StreetType,
                Enums.GetEnumDescription(Enums.Country.Canada),
                Enums.GetEnumDescription(request.SecurityPropertyDetails.PropertyType),
                Enums.GetEnumDescription(request.SecurityPropertyDetails.Occupancy),
                Enums.GetEnumDescription(request.SecurityPropertyDetails.DwellingType),
                request.SecurityPropertyDetails.PropertyValue,
                request.SecurityPropertyDetails.PropertyValue,
                request.SecurityPropertyDetails.UnitNumber,
                request.SecurityPropertyDetails.StreetNumber,
                request.SecurityPropertyDetails.StreetName,
                request.SecurityPropertyDetails.City,
                Enums.GetEnumDescription(request.SecurityPropertyDetails.Province),
                request.SecurityPropertyDetails.PostalCode,
                request.SecurityPropertyDetails.Direction,
                Enums.GetEnumDescription(request.SecurityPropertyDetails.ConstructionType),
                0,
                Enums.GetEnumDescription(request.SecurityPropertyDetails.SewageType),
                Enums.GetEnumDescription(request.SecurityPropertyDetails.WaterType),
                RSP_UnitCount,
                Enums.GetEnumDescription(request.SecurityPropertyDetails.PropertyZone),
                Enums.GetEnumDescription(request.SecurityPropertyDetails.ValuationMethod),
                Enums.GetEnumDescription(request.SecurityPropertyDetails.PropertyStyle)
            );

            // Borrowers
            foreach (Borrower borrower in request.Borrowers)
            {
                // Borrower Master Details
                string Borrower_CMR_ID = _rubiDataConnect.PQ_ServicingAPI_Client_MasterReferenceFunc(borrower.LastName + borrower.FirstName, Enums.GetEnumDescription(borrower.Language));
                string Borrower_CTI_ID = _rubiDataConnect.PQ_ServicingAPI_Client_TypeIndividualFunc(Borrower_CMR_ID, Enums.GetEnumDescription(borrower.MartialStatus), borrower.FirstName, borrower.MiddleName, borrower.LastName, borrower.DOB, Enums.GetEnumDescription(borrower.Title));

                // Address
                string MailingAddress_CAD_ID = _rubiDataConnect.PQ_ServicingAPI_Client_AddressDetailFunc(
                    Borrower_CMR_ID,
                    Enums.GetEnumDescription(Enums.AddressType.Mailing),
                    borrower.StreetType,
                    Enums.GetEnumDescription(borrower.Country),
                    borrower.Unit,
                    borrower.Number,
                    borrower.StreetName,
                    borrower.City,
                    Enums.GetEnumDescription(borrower.Province),
                    borrower.PostalCode
                );
                string CurrentAddress_CAD_ID = _rubiDataConnect.PQ_ServicingAPI_Client_AddressDetailFunc(
                    Borrower_CMR_ID,
                    Enums.GetEnumDescription(Enums.AddressType.Current),
                    borrower.StreetType,
                    Enums.GetEnumDescription(borrower.Country),
                    borrower.Unit,
                    borrower.Number,
                    borrower.StreetName,
                    borrower.City,
                    Enums.GetEnumDescription(borrower.Province),
                    borrower.PostalCode
                );

                // Association
                switch (borrower.ClientType)
                {
                    case Enums.ClientType.PriBorrower:
                        string PriBorrower_LMR_ID = _rubiDataConnect.PQ_ServicingAPI_Link_MasterReferenceFunc(Borrower_CMR_ID, RMR_ID, Enums.GetEnumDescription( Enums.Association.PrimaryBorrower)) ;
                        break;
                    case Enums.ClientType.CoBorrower:
                        string CoBorrower_LMR_ID = _rubiDataConnect.PQ_ServicingAPI_Link_MasterReferenceFunc(Borrower_CMR_ID, RMR_ID, Enums.GetEnumDescription( Enums.Association.CoBorrower)) ;
                        break;
                    case Enums.ClientType.Guarantor:
                        string Guarantor_LMR_ID = _rubiDataConnect.PQ_ServicingAPI_Link_MasterReferenceFunc(Borrower_CMR_ID, RMR_ID, Enums.GetEnumDescription( Enums.Association.Guarantor)) ;
                        break;
                    default:
                        break;
                }

                // Keys
                string CustomerAccountNumber_YMR_ID = _rubiDataConnect.PQ_ServicingAPI_Keys_MasterReferenceFunc(Borrower_CMR_ID, borrower.CustomerAccountNumber, Enums.GetEnumDescription(Enums.Keys.CustomerAccountNumber));
                string CustomerBeaconScore_YMR_ID = _rubiDataConnect.PQ_ServicingAPI_Keys_MasterReferenceFunc(Borrower_CMR_ID, borrower.BeaconScore.ToString(), Enums.GetEnumDescription(Enums.Keys.CustomerBeaconScore));

                // Contact Info
                string HomePhone_CCD_ID = _rubiDataConnect.PQ_ServicingAPI_Client_ContactDetailFunc(Borrower_CMR_ID, Enums.GetEnumDescription(Enums.ContactType.HomePhone), borrower.HomePhone, null);
                string MobilePhone_CCD_ID = _rubiDataConnect.PQ_ServicingAPI_Client_ContactDetailFunc(Borrower_CMR_ID, Enums.GetEnumDescription(Enums.ContactType.MobilePhone), borrower.MobilePhone, null);
                string Email_CCD_ID = _rubiDataConnect.PQ_ServicingAPI_Client_ContactDetailFunc(Borrower_CMR_ID, Enums.GetEnumDescription(Enums.ContactType.Email), borrower.Email, null);

                
                if (borrower.Income != null)
                {
                    // Employment
                    string Employment_CED_ID = _rubiDataConnect.PQ_ServicingAPI_Client_IndividualEmploymentFunc(
                        Borrower_CMR_ID,
                        null,
                        null,
                        borrower.Income.EmploymentName,
                        borrower.Income.EmploymentAddress.UnitNumber,
                        borrower.Income.EmploymentAddress.StreetNumber,
                        borrower.Income.EmploymentAddress.StreetName,
                        borrower.Income.EmploymentAddress.City,
                        borrower.Income.EmploymentAddress.Province.ToString(),
                        borrower.Income.EmploymentAddress.PostalCode,
                        borrower.Income.TimeInServiceYear,
                        borrower.Income.TimeInServiceMonth
                    );

                    // Income
                    string Income_CINc_ID = _rubiDataConnect.PQ_ServicingAPI_client_individualincomeFunc( Borrower_CMR_ID, borrower.Income.IncomeType, null, borrower.Income.IncomeAmount, null );
                }    
                
                //Client Bank detail
                string BankDetail_CBD_ID = _rubiDataConnect.PQ_ServicingAPI_Client_BankDetailFunc(Borrower_CMR_ID,  null, request.PreauthorizedPaymentAccount.CustomerAccountNumber.ToString(),null,null,false, request.PreauthorizedPaymentAccount.Transit.ToString(),request.PreauthorizedPaymentAccount.BankID.ToString());

            }

            string OriginalPaymentAmount_RLP_ID = _rubiDataConnect.PQ_ServicingAPI_Product_LoanPaymentFunc(RMR_ID,7700,(float)request.PrePaymentPrivileges.OriginalPaymentAmount,0,0,0,0,null);
            string CurrentPaymentAmount_RLP_ID = _rubiDataConnect.PQ_ServicingAPI_Product_LoanPaymentFunc(RMR_ID,1,(float)request.PrePaymentPrivileges.CurrentPaymentAmount,0,0,0,0,null);
            
            string CashBack_RCB_ID = _rubiDataConnect.PQ_ServicingAPI_Product_ControlBalanceFunc(RMR_ID,Enums.GetEnumDescription(Enums.BalanceType.CashBack),request.PrePaymentPrivileges.CashBack);

            // Results
            Deal IngestedDeal = _dealService.GetById(RMR_ID, Brand_CMR_ID);
            List<Client> ClientsIngested = _clientService.GetAll(RMR_ID);
            SubmitDealResponse response = new SubmitDealResponse(IngestedDeal, ClientsIngested);
            return response;
        }

    }
}