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
            string Product_XRP_ID = Enums.GetEnumDescription( request.AccountDetails.Product);
            string Product_XSU_ID = Enums.GetEnumDescription( request.AccountDetails.Status);
            string Brand_CMR_ID = Enums.GetEnumDescription( request.AccountDetails.Brand);
            string Investor_CMR_ID = Enums.GetEnumDescription( request.AccountDetails.Investor);
            string Broker_CMR_ID = Enums.GetEnumDescription( request.AccountDetails.Broker);
            string MI_CMR_ID = Enums.GetEnumDescription(request.MortgageInsuranceDetails.MortgageInsurer);

            // Deal Master Details
            string RMR_ID = _rubiDataConnect.PQ_ServicingAPI_Product_MasterReferenceFunc(Product_XRP_ID, Product_XSU_ID);
            
            // Deal Associations
            string Brand_LMR_ID = _rubiDataConnect.PQ_ServicingAPI_Link_MasterReferenceFunc(Brand_CMR_ID, RMR_ID, Enums.GetEnumDescription( Enums.Association.Brand)) ;
            string Investor_LMR_ID = _rubiDataConnect.PQ_ServicingAPI_Link_MasterReferenceFunc(Investor_CMR_ID, RMR_ID, Enums.GetEnumDescription( Enums.Association.Investor)) ;
            string Agent_LMR_ID = _rubiDataConnect.PQ_ServicingAPI_Link_MasterReferenceFunc(Broker_CMR_ID, RMR_ID, Enums.GetEnumDescription( Enums.Association.Agent)) ;
            string SubAgent_LMR_ID = _rubiDataConnect.PQ_ServicingAPI_Link_MasterReferenceFunc(Broker_CMR_ID, RMR_ID, Enums.GetEnumDescription( Enums.Association.SubAgent)) ;
            string SubmittingAgent_LMR_ID = _rubiDataConnect.PQ_ServicingAPI_Link_MasterReferenceFunc(Broker_CMR_ID, RMR_ID, Enums.GetEnumDescription( Enums.Association.SubmittingAgent)) ;
            string MortgageInsurer_LMR_ID = _rubiDataConnect.PQ_ServicingAPI_Link_MasterReferenceFunc(MI_CMR_ID, RMR_ID, Enums.GetEnumDescription( Enums.Association.SubmittingAgent));
                        
            // Deal Keys
            string MortgageAccountNumber_YMR_ID = _rubiDataConnect.PQ_ServicingAPI_Keys_MasterReferenceFunc(RMR_ID, request.AccountDetails.MortgageAccountNumber, Enums.GetEnumDescription(Enums.Keys.MortgageAccountNumber));

            // Details
            string LoanDetails_RLM_ID = _rubiDataConnect.PQ_ServicingAPI_Product_LoanMDTFunc(RMR_ID, Enums.GetEnumDescription(request.LoanDetails.LoanPurpose), null, null);

            // Balances
            string PrincipalBalance_RCB_ID = _rubiDataConnect.PQ_ServicingAPI_Product_ControlBalanceFunc(RMR_ID, Enums.GetEnumDescription(Enums.BalanceType.Principal), request.LoanDetails.OriginalLoanAmount); 
            string ApprovedBalance_RCB_ID = _rubiDataConnect.PQ_ServicingAPI_Product_ControlBalanceFunc(RMR_ID, Enums.GetEnumDescription(Enums.BalanceType.Approved), request.LoanDetails.ApprovedBalance);            
            string LoanLTV_RCB_ID = _rubiDataConnect.PQ_ServicingAPI_Product_ControlBalanceFunc(RMR_ID, Enums.GetEnumDescription(Enums.BalanceType.LoanLTV), request.SecurityPropertyDetails.LoanToValue);            
            // Product Term and Amortization
            string ProductTerm_RCTe_ID = _rubiDataConnect.PQ_ServicingAPI_Product_ControlTermFunc(RMR_ID, request.LoanDetails.ProductTerm_Years, request.LoanDetails.ProductTerm_Months, ( request.LoanDetails.ProductTerm_Years * 12 ) + request.LoanDetails.ProductTerm_Months, 1);
            string AmortizationOriginal_RCTe_ID = _rubiDataConnect.PQ_ServicingAPI_Product_ControlTermFunc(RMR_ID, request.LoanDetails.AmortizationOriginal_Years, request.LoanDetails.AmortizationOriginal_Months, ( request.LoanDetails.ProductTerm_Years * 12 ) + request.LoanDetails.ProductTerm_Months, 2);

            // Features

            // Dates
            string ClosingDate_RCD_ID = _rubiDataConnect.PQ_ServicingAPI_Product_ControlDateFunc(RMR_ID, 1001, request.LoanDetails.ClosingDate);
            string ApplicationDate_RCD_ID = _rubiDataConnect.PQ_ServicingAPI_Product_ControlDateFunc(RMR_ID, 1, request.LoanDetails.ApplicationDate);

            // Security
            string RSP_ID = _rubiDataConnect.PQ_ServicingAPI_Product_SecurityPTYFunc(
                RMR_ID,
                Enums.GetEnumDescription(request.SecurityPropertyDetails.StreetType),
                Enums.GetEnumDescription(Enums.Country.Canada),
                Enums.GetEnumDescription(request.SecurityPropertyDetails.PropertyType),
                Enums.GetEnumDescription(request.SecurityPropertyDetails.Occupancy),
                null,
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
                Enums.GetEnumDescription(request.SecurityPropertyDetails.WaterType)
            );

            // Borrowers
            foreach (Borrower borrower in request.Borrowers)
            {
                // Borrower Master Details
                string Borrower_CMR_ID = _rubiDataConnect.PQ_ServicingAPI_Client_MasterReferenceFunc(borrower.LastName + borrower.FirstName, Enums.GetEnumDescription(borrower.Language));
                string Borrower_CTI_ID = _rubiDataConnect.PQ_ServicingAPI_Client_TypeIndividualFunc(Borrower_CMR_ID, Enums.GetEnumDescription(borrower.MartialStatus), borrower.FirstName, borrower.MiddleName, borrower.LastName, borrower.DOB);

                // Address
                string MailingAddress_CAD_ID = _rubiDataConnect.PQ_ServicingAPI_Client_AddressDetailFunc(
                    Borrower_CMR_ID,
                    Enums.GetEnumDescription(Enums.AddressType.Mailing),
                    Enums.GetEnumDescription(borrower.StreetType),
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
                    Enums.GetEnumDescription(borrower.StreetType),
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
                string CustomerBeaconScore_YMR_ID = _rubiDataConnect.PQ_ServicingAPI_Keys_MasterReferenceFunc(Borrower_CMR_ID, borrower.CustomerAccountNumber, Enums.GetEnumDescription(Enums.Keys.CustomerBeaconScore));

                // Contact Info
                string HomePhone_CCD_ID = _rubiDataConnect.PQ_ServicingAPI_Client_ContactDetailFunc(Borrower_CMR_ID, Enums.GetEnumDescription(Enums.ContactType.HomePhone), borrower.HomePhone.Substring(6), borrower.HomePhone.Substring(3, 3));
                string MobilePhone_CCD_ID = _rubiDataConnect.PQ_ServicingAPI_Client_ContactDetailFunc(Borrower_CMR_ID, Enums.GetEnumDescription(Enums.ContactType.MobilePhone), borrower.MobilePhone.Substring(6), borrower.MobilePhone.Substring(3, 3));
                string Email_CCD_ID = _rubiDataConnect.PQ_ServicingAPI_Client_ContactDetailFunc(Borrower_CMR_ID, Enums.GetEnumDescription(Enums.ContactType.Email), borrower.Email, null);

                // Employment

                // Income

                
            }
            
            // Results
            Deal IngestedDeal = _dealService.GetById(RMR_ID, Brand_CMR_ID);
            List<Client> ClientsIngested = _clientService.GetAll(RMR_ID);
            SubmitDealResponse response = new SubmitDealResponse(IngestedDeal, ClientsIngested);
            return response;
        }

    }
}