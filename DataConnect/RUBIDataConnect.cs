using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PQ_API.Classes;

namespace PQ_API.DataConnect
{
    public class RUBIDataConnect : IDisposable
    {
        public const string PQ_CutomerAPI_GetAPIUsersList = "EXEC dbo.PQ_CutomerAPI_GetAPIUsersList"; 
        public const string PQ_CutomerAPI_GetUserBrandsList = "EXEC dbo.PQ_CutomerAPI_GetUserBrandsList @UserId";
        public const string PQ_CutomerAPI_GetStreetTypeList = "EXEC dbo.PQ_CutomerAPI_GetStreetTypeList";
        public const string PQ_CutomerAPI_GetBrandDealsList = "EXEC dbo.PQ_CutomerAPI_GetBrandDealsList @Brand_CMR_ID";
        public const string PQ_CutomerAPI_GetRequestTypeList = "EXEC dbo.PQ_CutomerAPI_GetRequestTypeList @Brand_CMR_ID";
        public const string PQ_CustomerAPI_AskQuestion = "EXEC dbo.PQ_CustomerAPI_AskQuestion @CMR_ID, @RMR_ID, @RequestType, @Comments, @ContactInformation, @ContactTime";
        public const string PQ_CutomerAPI_GetDealClientsList = "EXEC dbo.PQ_CutomerAPI_GetDealClientsList @RMR_ID";
        public const string PQ_CutomerAPI_GetMailAddress = "EXEC dbo.PQ_CutomerAPI_GetMailAddress @CMR_ID";
        public const string PQ_CutomerAPI_GetContactInfo = "EXEC dbo.PQ_CutomerAPI_GetContactInfo @CMR_ID";
        public const string PQ_CutomerAPI_SetContactInfo = "EXEC dbo.PQ_CutomerAPI_SetContactInfo @ContactId, @ContactType, @ContactDetails";
        public const string PQ_CutomerAPI_SetMailAddress = "EXEC PQ_CutomerAPI_SetMailAddress @AddressId, @AddressType, @UnitNumber, @StreetNumber, @StreetName, @StreetType, @Direction, @City, @Province, @PostalCode";
        public const string PQ_ServicingAPI_Product_MasterReference = "EXEC dbo.PQ_ServicingAPI_Product_MasterReference @RMR_IDLink_XRP, @RMR_IDLink_XSU";
        public const string PQ_ServicingAPI_Keys_MasterReference = "EXEC dbo.PQ_ServicingAPI_Keys_MasterReference @YMR_IDLink_ARMNet, @YMR_IDLink_Foreign, @YMR_IDLink_XFK";
        public const string PQ_ServicingAPI_Product_LoanAssetProperty = "EXEC dbo.PQ_ServicingAPI_Product_LoanAssetProperty @RLAp_IDLink_RMR, @RLAp_UnitNumber, @RLAp_StreetNumber, @RLAp_StreetName, @RLAp_Direction, @RLAp_City, @RLAp_State, @RLAp_PostCode, @RLAP_IDLink_StreetType,	 @RLAp_IDLink_Country";
        public const string PQ_ServicingAPI_Product_LoanAssetMaster = "EXEC dbo.PQ_ServicingAPI_Product_LoanAssetMaster @RLAm_IDLink_RMR,  @RLAm_Value";
        public const string PQ_ServicingAPI_Product_ControlBalance = "EXEC dbo.PQ_ServicingAPI_Product_ControlBalance @RCB_IDLink_RMR, @RCB_IDLink_XRBl, @RCB_CurrentValue";
        public const string PQ_ServicingAPI_Product_ControlTerm = "EXEC dbo.PQ_ServicingAPI_Product_ControlTerm @RCTe_IDLink_RMR, @RCTe_Years, @RCTe_Months, @RCTe_TotalMonths, @RCTe_Type";
        public const string PQ_ServicingAPI_Product_LoanMDT = "EXEC dbo.PQ_ServicingAPI_Product_LoanMDT @RLM_IDLink_RMR, @RLM_IDLink_XRPu, @RLM_IDLink_XRPy, @MortgageType";
        public const string PQ_ServicingAPI_Product_ControlFeature = "EXEC dbo.PQ_ServicingAPI_Product_ControlFeature @RCFf_IDLink_RMR, @RCFf_IDLink_XRFf";
        public const string PQ_ServicingAPI_Product_ControlDate = "EXEC dbo.PQ_ServicingAPI_Product_ControlDate @RCD_IDLink_RMR, @RCD_Type, @RCD_CurrentStart";
        public const string PQ_ServicingAPI_Product_SecurityPTY = "EXEC dbo.PQ_ServicingAPI_Product_SecurityPTY @RSP_IDLink_RMR, @RSP_IDLink_StreetType, @RSP_IDLink_Country, @RSP_IDLink_XRTy, @RSP_IDLink_XRTu, @RSP_IDLink_XRTt, @RSP_PurchasePrice, @RSP_EstimatedValue, @RSP_UnitNumber, @RSP_StreetNumber, @RSP_StreetName, @RSP_City, @RSP_State, @RSP_PostCode, @RSP_Direction, @RSP_IDLink_XRTc, @RSP_HeatingValue, @RSP_IDLink_XRTs, @RSP_IDLink_XRTw";        
        public const string PQ_ServicingAPI_Product_LoanLiabilityMaster = "EXEC dbo.PQ_ServicingAPI_Product_LoanLiabilityMaster @RLLm_IDLink_RMR, @RLLm_IDLink_XLBo, @RLLm_IDLink_XFR, @RLLm_Value, @RLLm_ValuePerYear, @RLLm_IDLink_RSP";
        public const string PQ_ServicingAPI_Link_MasterReference = "EXEC dbo.PQ_ServicingAPI_Link_MasterReference @LMR_IDLink_CMR, @LMR_IDLink_Code_ID,	@LMR_IDLink_Association";
        public const string PQ_ServicingAPI_Client_MasterReference = "EXEC dbo.PQ_ServicingAPI_Client_MasterReference @CMR_Name, @CMR_LanguagePreference";
        public const string PQ_ServicingAPI_Client_ContactDetail = "EXEC dbo.PQ_ServicingAPI_Client_ContactDetail @CCD_IDLink_CMR, @CCD_IDLink_XCT, @CCD_Details, @CCD_AreaCode";
        public const string PQ_ServicingAPI_Client_AddressDetail = "EXEC dbo.PQ_ServicingAPI_Client_AddressDetail @CAD_IDLink_CMR, @CAD_IDLink_XAT, @CAD_IDLink_StreetType, @CAD_IDLink_Country, @CAD_UnitNumber, @CAD_StreetNumber, @CAD_StreetName, @CAD_City, @CAD_State, @CAD_PostCode";
        public const string PQ_ServicingAPI_Client_TypeIndividual = "EXEC dbo.PQ_ServicingAPI_Client_TypeIndividual @CTI_IDLink_CMR, @CTI_IDLink_XCM, @CTI_FirstName, @CTI_MiddleName, @CTI_Surname, @CTI_DOB";
        public const string PQ_ServicingAPI_Client_UniqueIdentifier = "EXEC dbo.PQ_ServicingAPI_Client_UniqueIdentifier @CUI_IDLink_CMR, @CUI_IDLink_XDI, @CUI_IDLink_XSYSct, @CUI_DocumentNumber";
        public const string PQ_ServicingAPI_Client_IndividualEmployment = "EXEC dbo.PQ_ServicingAPI_Client_IndividualEmployment @CED_IDLink_CMR, @CED_IDLink_XCEt, @CED_IDLink_Country_C, @CED_EmployerName_C, @CED_UnitNumber_C, @CED_StreetNumber_C, @CED_StreetName_C, @CED_City_C, @CED_State_C, @CED_PostCode_C, @CED_TimeInServiceY_C, @CED_TimeInServiceM_C, @CED_IDLink_Occupation_C , @CED_StartDate DATE, @CED_JobTitl";
        public const string PQ_ServicingAPI_client_individualincome = "EXEC dbo.PQ_ServicingAPI_client_individualincome @CINc_IDLink_CMR, @CINc_IDLink_XIN, @CINc_IDLink_XFR, @CINc_Value, @CINc_IDLink_CED";
        public const string PQ_ServicingAPI_Product_LoanLiabilityCredit = "EXEC dbo.PQ_ServicingAPI_Product_LoanLiabilityCredit @RLLc_IDLink_RMR, @RLLc_IDLink_XLBc, @RLLc_CreditProvider, @RLLc_MonthlyRepayment, @RLLc_BalanceOwing";

        private SqlCommand _PQ_CutomerAPI_GetDealClientsList;
        private SqlCommand _PQ_CutomerAPI_GetMailAddress;
        private SqlCommand _PQ_CutomerAPI_GetContactInfo;
        private SqlCommand _PQ_CutomerAPI_GetAPIUsersList;
        private SqlCommand _PQ_CutomerAPI_GetUserBrandsList;
        private SqlCommand _PQ_CutomerAPI_GetStreetTypeList;
        private SqlCommand _PQ_CutomerAPI_GetRequestTypeList;
        private SqlCommand _PQ_CutomerAPI_GetBrandDealsList;
        private SqlCommand _PQ_CustomerAPI_AskQuestion;
        private SqlCommand _PQ_CutomerAPI_SetContactInfo;
        private SqlCommand _PQ_CutomerAPI_SetMailAddress;

        private SqlCommand _PQ_ServicingAPI_Product_MasterReference;
        private SqlCommand _PQ_ServicingAPI_Keys_MasterReference;
        private SqlCommand _PQ_ServicingAPI_Product_LoanAssetProperty;
        private SqlCommand _PQ_ServicingAPI_Product_LoanAssetMaster;
        private SqlCommand _PQ_ServicingAPI_Product_ControlBalance;
        private SqlCommand _PQ_ServicingAPI_Product_ControlTerm;
        private SqlCommand _PQ_ServicingAPI_Product_LoanMDT;
        private SqlCommand _PQ_ServicingAPI_Product_ControlFeature;
        private SqlCommand _PQ_ServicingAPI_Product_ControlDate;
        private SqlCommand _PQ_ServicingAPI_Product_SecurityPTY;
        private SqlCommand _PQ_ServicingAPI_Product_LoanLiabilityMaster;
        private SqlCommand _PQ_ServicingAPI_Link_MasterReference;
        private SqlCommand _PQ_ServicingAPI_Client_MasterReference;
        private SqlCommand _PQ_ServicingAPI_Client_ContactDetail;
        private SqlCommand _PQ_ServicingAPI_Client_AddressDetail;
        private SqlCommand _PQ_ServicingAPI_Client_TypeIndividual;
        private SqlCommand _PQ_ServicingAPI_Client_UniqueIdentifier;
        private SqlCommand _PQ_ServicingAPI_Client_IndividualEmployment;
        private SqlCommand _PQ_ServicingAPI_client_individualincome;
        private SqlCommand _PQ_ServicingAPI_Product_LoanLiabilityCredit;

        private SqlConnection _Connection;
        private SqlDataReader _rs;
        private string _ConnectionString;

        public RUBIDataConnect(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
            _Connection = new SqlConnection(ConnectionString);
            _Connection.Open();
            
            _PQ_CutomerAPI_GetAPIUsersList = new SqlCommand(PQ_CutomerAPI_GetAPIUsersList, _Connection);

            _PQ_CutomerAPI_GetUserBrandsList = new SqlCommand(PQ_CutomerAPI_GetUserBrandsList, _Connection);
            _PQ_CutomerAPI_GetUserBrandsList.Parameters.Add("@UserId", SqlDbType.VarChar);

            _PQ_CutomerAPI_GetDealClientsList = new SqlCommand(PQ_CutomerAPI_GetDealClientsList, _Connection);
            _PQ_CutomerAPI_GetDealClientsList.Parameters.Add("@RMR_ID", SqlDbType.VarChar);

            _PQ_CutomerAPI_GetMailAddress = new SqlCommand(PQ_CutomerAPI_GetMailAddress, _Connection);
            _PQ_CutomerAPI_GetMailAddress.Parameters.Add("@CMR_ID", SqlDbType.VarChar);

            _PQ_CutomerAPI_GetContactInfo = new SqlCommand(PQ_CutomerAPI_GetContactInfo, _Connection);
            _PQ_CutomerAPI_GetContactInfo.Parameters.Add("@CMR_ID", SqlDbType.VarChar);

            _PQ_CutomerAPI_GetBrandDealsList = new SqlCommand(PQ_CutomerAPI_GetBrandDealsList, _Connection);
            _PQ_CutomerAPI_GetBrandDealsList.Parameters.Add("@Brand_CMR_ID", SqlDbType.VarChar);

            _PQ_CutomerAPI_GetRequestTypeList = new SqlCommand(PQ_CutomerAPI_GetRequestTypeList, _Connection);
            _PQ_CutomerAPI_GetRequestTypeList.Parameters.Add("@Brand_CMR_ID", SqlDbType.VarChar);

            _PQ_CutomerAPI_GetStreetTypeList = new SqlCommand(PQ_CutomerAPI_GetStreetTypeList, _Connection);

            _PQ_CustomerAPI_AskQuestion = new SqlCommand(PQ_CustomerAPI_AskQuestion, _Connection);
            _PQ_CustomerAPI_AskQuestion.Parameters.Add("@CMR_ID", SqlDbType.VarChar);
            _PQ_CustomerAPI_AskQuestion.Parameters.Add("@RMR_ID", SqlDbType.VarChar);
            _PQ_CustomerAPI_AskQuestion.Parameters.Add("@RequestType", SqlDbType.VarChar);
            _PQ_CustomerAPI_AskQuestion.Parameters.Add("@Comments", SqlDbType.VarChar);
            _PQ_CustomerAPI_AskQuestion.Parameters.Add("@ContactInformation", SqlDbType.VarChar);
            _PQ_CustomerAPI_AskQuestion.Parameters.Add("@ContactTime", SqlDbType.VarChar);

            _PQ_CutomerAPI_SetMailAddress = new SqlCommand(PQ_CutomerAPI_SetMailAddress, _Connection);
            _PQ_CutomerAPI_SetMailAddress.Parameters.Add("@AddressID", SqlDbType.VarChar);
            _PQ_CutomerAPI_SetMailAddress.Parameters.Add("@AddressType", SqlDbType.VarChar);
            _PQ_CutomerAPI_SetMailAddress.Parameters.Add("@UnitNumber", SqlDbType.VarChar);
            _PQ_CutomerAPI_SetMailAddress.Parameters.Add("@StreetNumber", SqlDbType.VarChar);
            _PQ_CutomerAPI_SetMailAddress.Parameters.Add("@StreetName", SqlDbType.VarChar);
            _PQ_CutomerAPI_SetMailAddress.Parameters.Add("@StreetType", SqlDbType.VarChar);
            _PQ_CutomerAPI_SetMailAddress.Parameters.Add("@Direction", SqlDbType.VarChar);
            _PQ_CutomerAPI_SetMailAddress.Parameters.Add("@City", SqlDbType.VarChar);
            _PQ_CutomerAPI_SetMailAddress.Parameters.Add("@Province", SqlDbType.VarChar);
            _PQ_CutomerAPI_SetMailAddress.Parameters.Add("@PostalCode", SqlDbType.VarChar);

            _PQ_CutomerAPI_SetContactInfo = new SqlCommand(PQ_CutomerAPI_SetContactInfo, _Connection);
            _PQ_CutomerAPI_SetContactInfo.Parameters.Add("@ContactId", SqlDbType.VarChar);
            _PQ_CutomerAPI_SetContactInfo.Parameters.Add("@ContactType", SqlDbType.VarChar);
            _PQ_CutomerAPI_SetContactInfo.Parameters.Add("@ContactDetails", SqlDbType.VarChar);

            _PQ_ServicingAPI_Product_MasterReference = new SqlCommand(PQ_ServicingAPI_Product_MasterReference, _Connection);
            _PQ_ServicingAPI_Product_MasterReference.Parameters.Add("@RMR_IDLink_XRP", SqlDbType.VarChar);
            _PQ_ServicingAPI_Product_MasterReference.Parameters.Add("@RMR_IDLink_XSU", SqlDbType.VarChar);

            _PQ_ServicingAPI_Keys_MasterReference = new SqlCommand(PQ_ServicingAPI_Keys_MasterReference, _Connection);
            _PQ_ServicingAPI_Keys_MasterReference.Parameters.Add("@YMR_IDLink_ARMNet", SqlDbType.VarChar);
            _PQ_ServicingAPI_Keys_MasterReference.Parameters.Add("@YMR_IDLink_Foreign", SqlDbType.VarChar);
            _PQ_ServicingAPI_Keys_MasterReference.Parameters.Add("@YMR_IDLink_XFK", SqlDbType.VarChar);

            _PQ_ServicingAPI_Product_LoanAssetProperty = new SqlCommand(PQ_ServicingAPI_Product_LoanAssetProperty, _Connection);
            _PQ_ServicingAPI_Product_LoanAssetProperty.Parameters.Add("@RLAp_IDLink_RMR", SqlDbType.VarChar); 
            _PQ_ServicingAPI_Product_LoanAssetProperty.Parameters.Add("@RLAp_UnitNumber", SqlDbType.VarChar);
            _PQ_ServicingAPI_Product_LoanAssetProperty.Parameters.Add("@RLAp_StreetNumber", SqlDbType.VarChar);
            _PQ_ServicingAPI_Product_LoanAssetProperty.Parameters.Add("@RLAp_StreetName", SqlDbType.VarChar);
            _PQ_ServicingAPI_Product_LoanAssetProperty.Parameters.Add("@RLAp_Direction", SqlDbType.VarChar);
            _PQ_ServicingAPI_Product_LoanAssetProperty.Parameters.Add("@RLAp_City", SqlDbType.VarChar);
            _PQ_ServicingAPI_Product_LoanAssetProperty.Parameters.Add("@RLAp_State", SqlDbType.VarChar);
            _PQ_ServicingAPI_Product_LoanAssetProperty.Parameters.Add("@RLAp_PostCode", SqlDbType.VarChar);
            _PQ_ServicingAPI_Product_LoanAssetProperty.Parameters.Add("@RLAP_IDLink_StreetType", SqlDbType.VarChar);	
            _PQ_ServicingAPI_Product_LoanAssetProperty.Parameters.Add("@RLAp_IDLink_Country", SqlDbType.VarChar);

            _PQ_ServicingAPI_Product_LoanAssetMaster = new SqlCommand(PQ_ServicingAPI_Product_LoanAssetMaster, _Connection);
            _PQ_ServicingAPI_Product_LoanAssetMaster.Parameters.Add("@RLAm_IDLink_RMR", SqlDbType.VarChar);  
            _PQ_ServicingAPI_Product_LoanAssetMaster.Parameters.Add("@RLAm_Value", SqlDbType.Decimal);

            _PQ_ServicingAPI_Product_ControlBalance = new SqlCommand(PQ_ServicingAPI_Product_ControlBalance, _Connection);
            _PQ_ServicingAPI_Product_ControlBalance.Parameters.Add("@RCB_IDLink_RMR", SqlDbType.VarChar);
            _PQ_ServicingAPI_Product_ControlBalance.Parameters.Add("@RCB_IDLink_XRBl", SqlDbType.VarChar);
            _PQ_ServicingAPI_Product_ControlBalance.Parameters.Add("@RCB_CurrentValue", SqlDbType.Decimal);

            _PQ_ServicingAPI_Product_ControlTerm = new SqlCommand(PQ_ServicingAPI_Product_ControlTerm, _Connection);
            _PQ_ServicingAPI_Product_ControlTerm.Parameters.Add("@RCTe_IDLink_RMR", SqlDbType.VarChar);
            _PQ_ServicingAPI_Product_ControlTerm.Parameters.Add("@RCTe_Years", SqlDbType.Int); 
            _PQ_ServicingAPI_Product_ControlTerm.Parameters.Add("@RCTe_Months", SqlDbType.Int); 
            _PQ_ServicingAPI_Product_ControlTerm.Parameters.Add("@RCTe_TotalMonths", SqlDbType.Int);
            _PQ_ServicingAPI_Product_ControlTerm.Parameters.Add("@RCTe_Type", SqlDbType.Int);

            _PQ_ServicingAPI_Product_LoanMDT = new SqlCommand(PQ_ServicingAPI_Product_LoanMDT, _Connection);
            _PQ_ServicingAPI_Product_LoanMDT.Parameters.Add("@RLM_IDLink_RMR", SqlDbType.VarChar);
            _PQ_ServicingAPI_Product_LoanMDT.Parameters.Add("@RLM_IDLink_XRPu", SqlDbType.VarChar); 
            _PQ_ServicingAPI_Product_LoanMDT.Parameters.Add("@RLM_IDLink_XRPy", SqlDbType.VarChar); 
            _PQ_ServicingAPI_Product_LoanMDT.Parameters.Add("@MortgageType", SqlDbType.VarChar);

            _PQ_ServicingAPI_Product_ControlFeature = new SqlCommand(PQ_ServicingAPI_Product_ControlFeature, _Connection);
            _PQ_ServicingAPI_Product_ControlFeature.Parameters.Add("@RCFf_IDLink_RMR", SqlDbType.VarChar);
            _PQ_ServicingAPI_Product_ControlFeature.Parameters.Add("@RCFf_IDLink_XRFf", SqlDbType.VarChar);

            _PQ_ServicingAPI_Product_ControlDate = new SqlCommand(PQ_ServicingAPI_Product_ControlDate, _Connection);
            _PQ_ServicingAPI_Product_ControlDate.Parameters.Add("@RCD_IDLink_RMR", SqlDbType.VarChar);
            _PQ_ServicingAPI_Product_ControlDate.Parameters.Add("@RCD_Type", SqlDbType.VarChar);
            _PQ_ServicingAPI_Product_ControlDate.Parameters.Add("@RCD_CurrentStart", SqlDbType.DateTime);

            _PQ_ServicingAPI_Product_SecurityPTY = new SqlCommand(PQ_ServicingAPI_Product_SecurityPTY, _Connection);
            _PQ_ServicingAPI_Product_SecurityPTY.Parameters.Add("@RSP_IDLink_RMR", SqlDbType.VarChar);
            _PQ_ServicingAPI_Product_SecurityPTY.Parameters.Add("@RSP_IDLink_StreetType", SqlDbType.VarChar);
            _PQ_ServicingAPI_Product_SecurityPTY.Parameters.Add("@RSP_IDLink_Country", SqlDbType.VarChar);
            _PQ_ServicingAPI_Product_SecurityPTY.Parameters.Add("@RSP_IDLink_XRTy", SqlDbType.VarChar);
            _PQ_ServicingAPI_Product_SecurityPTY.Parameters.Add("@RSP_IDLink_XRTu", SqlDbType.VarChar);
            _PQ_ServicingAPI_Product_SecurityPTY.Parameters.Add("@RSP_IDLink_XRTt", SqlDbType.VarChar);
            _PQ_ServicingAPI_Product_SecurityPTY.Parameters.Add("@RSP_PurchasePrice", SqlDbType.Decimal);
            _PQ_ServicingAPI_Product_SecurityPTY.Parameters.Add("@RSP_EstimatedValue", SqlDbType.Decimal);
            _PQ_ServicingAPI_Product_SecurityPTY.Parameters.Add("@RSP_UnitNumber", SqlDbType.VarChar);
            _PQ_ServicingAPI_Product_SecurityPTY.Parameters.Add("@RSP_StreetNumber", SqlDbType.VarChar);
            _PQ_ServicingAPI_Product_SecurityPTY.Parameters.Add("@RSP_StreetName", SqlDbType.VarChar);
            _PQ_ServicingAPI_Product_SecurityPTY.Parameters.Add("@RSP_City", SqlDbType.VarChar);
            _PQ_ServicingAPI_Product_SecurityPTY.Parameters.Add("@RSP_State", SqlDbType.VarChar);
            _PQ_ServicingAPI_Product_SecurityPTY.Parameters.Add("@RSP_PostCode", SqlDbType.VarChar);
            _PQ_ServicingAPI_Product_SecurityPTY.Parameters.Add("@RSP_Direction", SqlDbType.VarChar);		
            _PQ_ServicingAPI_Product_SecurityPTY.Parameters.Add("@RSP_IDLink_XRTc", SqlDbType.VarChar);
            _PQ_ServicingAPI_Product_SecurityPTY.Parameters.Add("@RSP_HeatingValue", SqlDbType.Decimal); 
            _PQ_ServicingAPI_Product_SecurityPTY.Parameters.Add("@RSP_IDLink_XRTs", SqlDbType.VarChar);
            _PQ_ServicingAPI_Product_SecurityPTY.Parameters.Add("@RSP_IDLink_XRTw", SqlDbType.VarChar);

            _PQ_ServicingAPI_Product_LoanLiabilityMaster = new SqlCommand(PQ_ServicingAPI_Product_LoanLiabilityMaster, _Connection);
            _PQ_ServicingAPI_Product_LoanLiabilityMaster.Parameters.Add("@RLLm_IDLink_RMR", SqlDbType.VarChar);
            _PQ_ServicingAPI_Product_LoanLiabilityMaster.Parameters.Add("@RLLm_IDLink_XLBo", SqlDbType.VarChar); 
            _PQ_ServicingAPI_Product_LoanLiabilityMaster.Parameters.Add("@RLLm_IDLink_XFR", SqlDbType.VarChar); 
            _PQ_ServicingAPI_Product_LoanLiabilityMaster.Parameters.Add("@RLLm_Value", SqlDbType.Decimal);
            _PQ_ServicingAPI_Product_LoanLiabilityMaster.Parameters.Add("@RLLm_ValuePerYear", SqlDbType.Decimal);	
            _PQ_ServicingAPI_Product_LoanLiabilityMaster.Parameters.Add("@RLLm_IDLink_RSP", SqlDbType.VarChar);

            _PQ_ServicingAPI_Link_MasterReference = new SqlCommand(PQ_ServicingAPI_Link_MasterReference, _Connection);
            _PQ_ServicingAPI_Link_MasterReference.Parameters.Add("@LMR_IDLink_CMR", SqlDbType.VarChar); 	
            _PQ_ServicingAPI_Link_MasterReference.Parameters.Add("@LMR_IDLink_Code_ID", SqlDbType.VarChar);	
            _PQ_ServicingAPI_Link_MasterReference.Parameters.Add("@LMR_IDLink_Association", SqlDbType.VarChar);

            _PQ_ServicingAPI_Client_MasterReference = new SqlCommand(PQ_ServicingAPI_Client_MasterReference, _Connection);
            _PQ_ServicingAPI_Client_MasterReference.Parameters.Add("@CMR_Name", SqlDbType.VarChar);
            _PQ_ServicingAPI_Client_MasterReference.Parameters.Add("@CMR_LanguagePreference", SqlDbType.VarChar);

            _PQ_ServicingAPI_Client_ContactDetail =  new SqlCommand(PQ_ServicingAPI_Client_ContactDetail, _Connection);
            _PQ_ServicingAPI_Client_ContactDetail.Parameters.Add("@CCD_IDLink_CMR", SqlDbType.VarChar);
            _PQ_ServicingAPI_Client_ContactDetail.Parameters.Add("@CCD_IDLink_XCT", SqlDbType.VarChar);
            _PQ_ServicingAPI_Client_ContactDetail.Parameters.Add("@CCD_Details", SqlDbType.VarChar);
            _PQ_ServicingAPI_Client_ContactDetail.Parameters.Add("@CCD_AreaCode", SqlDbType.VarChar);

            _PQ_ServicingAPI_Client_AddressDetail = new SqlCommand(PQ_ServicingAPI_Client_AddressDetail, _Connection);
            _PQ_ServicingAPI_Client_AddressDetail.Parameters.Add("@CAD_IDLink_CMR", SqlDbType.VarChar); 
            _PQ_ServicingAPI_Client_AddressDetail.Parameters.Add("@CAD_IDLink_XAT", SqlDbType.VarChar); 
            _PQ_ServicingAPI_Client_AddressDetail.Parameters.Add("@CAD_IDLink_StreetType", SqlDbType.VarChar); 
            _PQ_ServicingAPI_Client_AddressDetail.Parameters.Add("@CAD_IDLink_Country", SqlDbType.VarChar);
            _PQ_ServicingAPI_Client_AddressDetail.Parameters.Add("@CAD_UnitNumber", SqlDbType.VarChar);
            _PQ_ServicingAPI_Client_AddressDetail.Parameters.Add("@CAD_StreetNumber", SqlDbType.VarChar);
            _PQ_ServicingAPI_Client_AddressDetail.Parameters.Add("@CAD_StreetName", SqlDbType.VarChar);
            _PQ_ServicingAPI_Client_AddressDetail.Parameters.Add("@CAD_City", SqlDbType.VarChar);
            _PQ_ServicingAPI_Client_AddressDetail.Parameters.Add("@CAD_State", SqlDbType.VarChar);
            _PQ_ServicingAPI_Client_AddressDetail.Parameters.Add("@CAD_PostCode", SqlDbType.VarChar);

            _PQ_ServicingAPI_Client_TypeIndividual = new SqlCommand(PQ_ServicingAPI_Client_TypeIndividual, _Connection);
            _PQ_ServicingAPI_Client_TypeIndividual.Parameters.Add("@CTI_IDLink_CMR", SqlDbType.VarChar); 
            _PQ_ServicingAPI_Client_TypeIndividual.Parameters.Add("@CTI_IDLink_XCM", SqlDbType.VarChar); 
            _PQ_ServicingAPI_Client_TypeIndividual.Parameters.Add("@CTI_FirstName", SqlDbType.VarChar); 
            _PQ_ServicingAPI_Client_TypeIndividual.Parameters.Add("@CTI_MiddleName", SqlDbType.VarChar);
            _PQ_ServicingAPI_Client_TypeIndividual.Parameters.Add("@CTI_Surname", SqlDbType.VarChar); 
            _PQ_ServicingAPI_Client_TypeIndividual.Parameters.Add("@CTI_DOB", SqlDbType.DateTime);

            _PQ_ServicingAPI_Client_UniqueIdentifier = new SqlCommand(PQ_ServicingAPI_Client_UniqueIdentifier, _Connection);
            _PQ_ServicingAPI_Client_UniqueIdentifier.Parameters.Add("@CUI_IDLink_CMR", SqlDbType.VarChar);	
            _PQ_ServicingAPI_Client_UniqueIdentifier.Parameters.Add("@CUI_IDLink_XDI", SqlDbType.VarChar);	
            _PQ_ServicingAPI_Client_UniqueIdentifier.Parameters.Add("@CUI_IDLink_XSYSct", SqlDbType.VarChar);
            _PQ_ServicingAPI_Client_UniqueIdentifier.Parameters.Add("@CUI_DocumentNumber", SqlDbType.VarChar);

            _PQ_ServicingAPI_Client_IndividualEmployment = new SqlCommand(PQ_ServicingAPI_Client_IndividualEmployment, _Connection);
            _PQ_ServicingAPI_Client_IndividualEmployment.Parameters.Add("@CED_IDLink_CMR", SqlDbType.VarChar); 
            _PQ_ServicingAPI_Client_IndividualEmployment.Parameters.Add("@CED_IDLink_XCEt", SqlDbType.VarChar);
            _PQ_ServicingAPI_Client_IndividualEmployment.Parameters.Add("@CED_IDLink_Country_C", SqlDbType.VarChar);	 
            _PQ_ServicingAPI_Client_IndividualEmployment.Parameters.Add("@CED_EmployerName_C", SqlDbType.VarChar);
            _PQ_ServicingAPI_Client_IndividualEmployment.Parameters.Add("@CED_UnitNumber_C", SqlDbType.VarChar);
            _PQ_ServicingAPI_Client_IndividualEmployment.Parameters.Add("@CED_StreetNumber_C", SqlDbType.VarChar); 
            _PQ_ServicingAPI_Client_IndividualEmployment.Parameters.Add("@CED_StreetName_C", SqlDbType.VarChar);
            _PQ_ServicingAPI_Client_IndividualEmployment.Parameters.Add("@CED_City_C", SqlDbType.VarChar);
            _PQ_ServicingAPI_Client_IndividualEmployment.Parameters.Add("@CED_State_C", SqlDbType.VarChar);
            _PQ_ServicingAPI_Client_IndividualEmployment.Parameters.Add("@CED_PostCode_C", SqlDbType.VarChar);	
            _PQ_ServicingAPI_Client_IndividualEmployment.Parameters.Add("@CED_TimeInServiceY_C", SqlDbType.Int); 
            _PQ_ServicingAPI_Client_IndividualEmployment.Parameters.Add("@CED_TimeInServiceM_C", SqlDbType.Int);	
            _PQ_ServicingAPI_Client_IndividualEmployment.Parameters.Add("@CED_IDLink_Occupation_C", SqlDbType.VarChar);
            _PQ_ServicingAPI_Client_IndividualEmployment.Parameters.Add("@CED_StartDate", SqlDbType.Date);
            _PQ_ServicingAPI_Client_IndividualEmployment.Parameters.Add("@CED_JobTitle", SqlDbType.VarChar);

            _PQ_ServicingAPI_client_individualincome = new SqlCommand(PQ_ServicingAPI_client_individualincome, _Connection);
            _PQ_ServicingAPI_client_individualincome.Parameters.Add("@CINc_IDLink_CMR", SqlDbType.VarChar); 
            _PQ_ServicingAPI_client_individualincome.Parameters.Add("@CINc_IDLink_XIN", SqlDbType.VarChar);
            _PQ_ServicingAPI_client_individualincome.Parameters.Add("@CINc_IDLink_XFR", SqlDbType.VarChar); 
            _PQ_ServicingAPI_client_individualincome.Parameters.Add("@CINc_Value", SqlDbType.Decimal);
            _PQ_ServicingAPI_client_individualincome.Parameters.Add("@CINc_IDLink_CED", SqlDbType.VarChar);

            _PQ_ServicingAPI_Product_LoanLiabilityCredit = new SqlCommand(PQ_ServicingAPI_Product_LoanLiabilityCredit, _Connection);
            _PQ_ServicingAPI_Product_LoanLiabilityCredit.Parameters.Add("@RLLc_IDLink_RMR", SqlDbType.VarChar); 
            _PQ_ServicingAPI_Product_LoanLiabilityCredit.Parameters.Add("@RLLc_IDLink_XLBc", SqlDbType.VarChar); 
            _PQ_ServicingAPI_Product_LoanLiabilityCredit.Parameters.Add("@RLLc_CreditProvider", SqlDbType.VarChar); 
            _PQ_ServicingAPI_Product_LoanLiabilityCredit.Parameters.Add("@RLLc_MonthlyRepayment", SqlDbType.Decimal);
            _PQ_ServicingAPI_Product_LoanLiabilityCredit.Parameters.Add("@RLLc_BalanceOwing", SqlDbType.Decimal);
        }

        public List<User> PQ_CutomerAPI_GetAPIUsersListFunc()
        {
            List<User> result = new List<User>();
            string API_User_ID = null;
            string API_User_FirstName = null;
            string API_User_LastName = null;
            string API_User_UserName = null;
            string API_User_Password = null;

            _rs = _PQ_CutomerAPI_GetAPIUsersList.ExecuteReader();

            if (_rs.HasRows)
            {
                while (_rs.Read())
                {
                    API_User_ID = _rs["API_User_ID"].ToString();
                    API_User_FirstName = _rs["API_User_FirstName"].ToString();
                    API_User_LastName = _rs["API_User_LastName"].ToString();
                    API_User_UserName = _rs["API_User_UserName"].ToString();
                    API_User_Password = _rs["API_User_Password"].ToString();
                    User user = new User(API_User_ID, API_User_FirstName, API_User_LastName, API_User_UserName, API_User_Password);
                    result.Add(user);
                }
                _rs.Close();
                return result;
            }
            _rs.Close();
            return result;
        }

        public List<BrandInfo> GetUsersBrandsListFunc(string UserId)
        {
            _PQ_CutomerAPI_GetUserBrandsList.Parameters["@UserId"].Value = (object)UserId ?? DBNull.Value; ;
            List<BrandInfo> result = new List<BrandInfo>();
            string Brand_CMR_ID = null;
            string Brand_Name = null;
            string Brand_EmailAddress = null;

            _rs = _PQ_CutomerAPI_GetUserBrandsList.ExecuteReader();

            if (_rs.HasRows)
            {
                while (_rs.Read())
                {
                    Brand_CMR_ID = _rs["Brand_CMR_ID"].ToString();
                    Brand_Name = _rs["Brand_Name"].ToString();
                    Brand_EmailAddress = _rs["Brand_EmailAddress"].ToString();
                    BrandInfo brandInfo = new BrandInfo(Brand_CMR_ID, Brand_Name, Brand_EmailAddress);
                    result.Add(brandInfo);
                }
                _rs.Close();
                return result;
            }
            _rs.Close();
            return result;
        }

        public List<Deal> GetBrandDealsListFunc(string Brand_CMR_ID)
        {
            _PQ_CutomerAPI_GetBrandDealsList.Parameters["@Brand_CMR_ID"].Value = (object)Brand_CMR_ID ?? DBNull.Value; ;
            List<Deal> result = new List<Deal>();
            string RMR_ID = null;
            Int32 RMR_SeqNumber;
            string ComponentType = null;
            double? LoanAmount = null;
            string MortgageType = null;
            string PropertyAddress = null;
            double? InterestPaidPriorYear = null;
            double? InterestPaidYearToDate = null;
            double? PrincipalPaidPriorYear = null;
            double? PrincipalPaidYearToDate = null;
            double? CurrentMortgageBalance = null;
            string ProductDescription = null;
            string RateType = null;
            string InterestRate = null;
            string PaymentType = null;
            double? PaymentAmount = null;
            string PaymentFrequency = null;
            string LastPaymentDate = null;
            string NextPaymentDate = null;
            string MaturityDate = null;
            Int32? RemainingAmortization_Months = null;		
            Int32? RemainingAmortization_Years = null;

            _rs = _PQ_CutomerAPI_GetBrandDealsList.ExecuteReader();

            if (_rs.HasRows)
            {
                while (_rs.Read())
                {
                    RMR_ID = _rs["RMR_ID"].ToString();
                    RMR_SeqNumber = Convert.ToInt32(_rs["RMR_SeqNumber"]);
                    ComponentType = _rs["ComponentType"].ToString();
                    if (_rs["LoanAmount"] != DBNull.Value) LoanAmount = Convert.ToDouble(_rs["LoanAmount"]);
                    MortgageType = _rs["MortgageType"].ToString();
                    PropertyAddress = _rs["PropertyAddress"].ToString();
                    if (_rs["InterestPaidPriorYear"] != DBNull.Value) InterestPaidPriorYear = Convert.ToDouble(_rs["InterestPaidPriorYear"]); 
                    if (_rs["InterestPaidYearToDate"] != DBNull.Value) InterestPaidYearToDate = Convert.ToDouble(_rs["InterestPaidYearToDate"]);
                    if (_rs["PrincipalPaidPriorYear"] != DBNull.Value) PrincipalPaidPriorYear = Convert.ToDouble(_rs["PrincipalPaidPriorYear"]);
                    if (_rs["PrincipalPaidYearToDate"] != DBNull.Value) PrincipalPaidYearToDate = Convert.ToDouble(_rs["PrincipalPaidYearToDate"]);
                    if (_rs["CurrentMortgageBalance"] != DBNull.Value) CurrentMortgageBalance = Convert.ToDouble(_rs["CurrentMortgageBalance"]);
                    ProductDescription = _rs["ProductDescription"].ToString();
                    RateType = _rs["RateType"].ToString();
                    InterestRate = _rs["InterestRate"].ToString();
                    PaymentType = _rs["PaymentType"].ToString();
                    if (_rs["PaymentAmount"] != DBNull.Value) PaymentAmount = Convert.ToDouble(_rs["PaymentAmount"]);
                    PaymentFrequency = _rs["PaymentFrequency"].ToString();
                    LastPaymentDate = _rs["LastPaymentDate"].ToString();
                    NextPaymentDate = _rs["NextPaymentDate"].ToString();
                    MaturityDate = _rs["MaturityDate"].ToString();
                    if (_rs["RemainingAmortization_Months"] != DBNull.Value) RemainingAmortization_Months = Convert.ToInt32(_rs["RemainingAmortization_Months"]);		
                    if (_rs["RemainingAmortization_Years"] != DBNull.Value) RemainingAmortization_Years = Convert.ToInt32(_rs["RemainingAmortization_Years"]);

                    
                    Deal deal = new Deal(
                        RMR_ID,
                        RMR_SeqNumber,
                        ComponentType,
                        LoanAmount,
                        MortgageType,
                        PropertyAddress,
                        InterestPaidPriorYear,
                        InterestPaidYearToDate,
                        PrincipalPaidPriorYear,
                        PrincipalPaidYearToDate,
                        CurrentMortgageBalance,
                        ProductDescription,
                        RateType,
                        InterestRate,
                        PaymentType,
                        PaymentAmount,
                        PaymentFrequency,
                        LastPaymentDate,
                        NextPaymentDate,
                        MaturityDate,
                        RemainingAmortization_Months,
                        RemainingAmortization_Years
                    );
                    result.Add(deal);
                }
                _rs.Close();
                return result;
            }
            _rs.Close();
            return result;
        }

        public List<RequestType> GetRequestTypeListFunc(string Brand_CMR_ID)
        {
            _PQ_CutomerAPI_GetRequestTypeList.Parameters["@Brand_CMR_ID"].Value = (object)Brand_CMR_ID ?? DBNull.Value; ;
            List<RequestType> result = new List<RequestType>();
            string TypeOfRequest_En = null;
            string TypeOfRequest_Fq = null;
            string TypeOfRequest_lbl_En = null;
            string TypeOfRequest_lbl_Fq = null;

            _rs = _PQ_CutomerAPI_GetRequestTypeList.ExecuteReader();

            if (_rs.HasRows)
            {
                while (_rs.Read())
                {
                    TypeOfRequest_En = _rs["TypeOfRequest_En"].ToString();
                    TypeOfRequest_Fq = _rs["TypeOfRequest_Fq"].ToString();
                    TypeOfRequest_lbl_En = _rs["TypeOfRequest_lbl_En"].ToString();
                    TypeOfRequest_lbl_Fq = _rs["TypeOfRequest_lbl_Fq"].ToString();
                    RequestType customerRequestType = new RequestType(TypeOfRequest_En, TypeOfRequest_Fq, TypeOfRequest_lbl_En, TypeOfRequest_lbl_Fq);
                    result.Add(customerRequestType);
                }
                _rs.Close();
                return result;
            }
            _rs.Close();
            return result;
        }

        public List<Client> GetDealClientsListFunc(string RMR_ID)
        {
            _PQ_CutomerAPI_GetDealClientsList.Parameters["@RMR_ID"].Value = (object)RMR_ID ?? DBNull.Value;
            List<Client> clientsList = new List<Client>();
            List<Address> addressList = new List<Address>();
            List<ContactInfo> contactInfoList = new List<ContactInfo>();

            _rs = _PQ_CutomerAPI_GetDealClientsList.ExecuteReader();
            if (_rs.HasRows)
            {
                while (_rs.Read())
                {
                    Client client = new Client();
                    client.CMR_ID = _rs["CMR_ID"].ToString();
                    client.FirstName = _rs["FirstName"].ToString();
                    client.MiddleName = _rs["MiddleName"].ToString();
                    client.LastName = _rs["LastName"].ToString();  
                    clientsList.Add(client);
                }
                
                _rs.Close();
                
                foreach (Client clientFromList in clientsList)
                {
                    _PQ_CutomerAPI_GetMailAddress.Parameters["@CMR_ID"].Value = (object)clientFromList.CMR_ID ?? DBNull.Value;
                    _rs = _PQ_CutomerAPI_GetMailAddress.ExecuteReader();
                    if (_rs.HasRows)
                    {
                        while (_rs.Read())
                        {
                            Address address = new Address();
                            address.AddressId = _rs["AddressId"].ToString();
                            address.AddressType = _rs["AddressType"].ToString();
                            address.UnitNumber = _rs["UnitNumber"].ToString();
                            address.StreetNumber = _rs["StreetNumber"].ToString();
                            address.StreetName = _rs["StreetName"].ToString();
                            address.StreetType = _rs["StreetType"].ToString();
                            address.Direction = _rs["Direction"].ToString();
                            address.City = _rs["City"].ToString();
                            address.Province = _rs["Province"].ToString();
                            address.PostalCode = _rs["PostalCode"].ToString(); 
                            
                            addressList.Add(address);
                        }
                        clientFromList.Addresses = addressList;
                    }
                    _rs.Close();
                    _PQ_CutomerAPI_GetContactInfo.Parameters["@CMR_ID"].Value = (object)clientFromList.CMR_ID ?? DBNull.Value;
                    _rs = _PQ_CutomerAPI_GetContactInfo.ExecuteReader();
                    if (_rs.HasRows)
                    {
                        ContactInfo contactInfo = new ContactInfo();
                        while (_rs.Read())
                        {  
                            contactInfo.ContactId = _rs["ContactId"].ToString();                          
                            contactInfo.ContactType = _rs["ContactType"].ToString();
                            contactInfo.ContactDetails = _rs["ContactDetails"].ToString();

                            contactInfoList.Add(contactInfo);
                        }
                        clientFromList.ContactInfo = contactInfoList;
                    }
                    _rs.Close();
                    addressList = new List<Address>();;
                }

                _rs.Close();
                return clientsList;
            }
            _rs.Close();
            return clientsList;
        }

        public List<StreetType> GetStreetTypeListFunc()
        {
            List<StreetType> result = new List<StreetType>();
            string XSYSst_ID = null;
            string XSYSst_Code = null;
            string XSYSst_Description = null;

            _rs = _PQ_CutomerAPI_GetStreetTypeList.ExecuteReader();

            if (_rs.HasRows)
            {
                while (_rs.Read())
                {
                    XSYSst_ID = _rs["XSYSst_ID"].ToString();
                    XSYSst_Code = _rs["XSYSst_Code"].ToString();
                    XSYSst_Description = _rs["XSYSst_Description"].ToString();
                    StreetType streetType = new StreetType(XSYSst_ID, XSYSst_Code, XSYSst_Description);
                    result.Add(streetType);
                }
                _rs.Close();
                return result;
            }
            _rs.Close();
            return result;
        }

        public AskQuestion AskQuestionFunc(AskQuestion question)
        {
            _PQ_CustomerAPI_AskQuestion.Parameters["@CMR_ID"].Value = (object)question.CMR_ID ?? DBNull.Value; ;
            _PQ_CustomerAPI_AskQuestion.Parameters["@RMR_ID"].Value = (object)question.RMR_ID ?? DBNull.Value; ;
            _PQ_CustomerAPI_AskQuestion.Parameters["@RequestType"].Value = (object)question.RequestType ?? DBNull.Value; ;
            _PQ_CustomerAPI_AskQuestion.Parameters["@Comments"].Value = (object)question.Comments ?? DBNull.Value; ;
            _PQ_CustomerAPI_AskQuestion.Parameters["@ContactInformation"].Value = (object)question.ContactInformation ?? DBNull.Value; ;
            _PQ_CustomerAPI_AskQuestion.Parameters["@ContactTime"].Value = (object)question.ContactTime ?? DBNull.Value; ;
            
            AskQuestion result = null;
            string CMR_ID_Selected = null;
            string RMR_ID_Selected = null;
            string RequestType = null;
            string Comments = null;
            string ContactInformation = null;
            string ContactTime = null;

            _rs = _PQ_CustomerAPI_AskQuestion.ExecuteReader();

            if (_rs.HasRows)
            {
                while (_rs.Read())
                {
                    CMR_ID_Selected = _rs["CMR_ID"].ToString();
                    RMR_ID_Selected = _rs["RMR_ID"].ToString();
                    RequestType = _rs["RequestType"].ToString();
                    Comments = _rs["Comments"].ToString();
                    ContactInformation = _rs["ContactInformation"].ToString();
                    ContactTime = _rs["ContactTime"].ToString();
                    
                    result = new AskQuestion(CMR_ID_Selected, RMR_ID_Selected, RequestType, Comments, ContactInformation, ContactTime);
                }
                _rs.Close();
                return result;
            }
            _rs.Close();
            return result;
        }

        public ContactInfo UpdateContactInfoFunc(ContactInfo contactInfo)
        {
            _PQ_CutomerAPI_SetContactInfo.Parameters["@ContactId"].Value = (object)contactInfo.ContactId ?? DBNull.Value;
            _PQ_CutomerAPI_SetContactInfo.Parameters["@ContactType"].Value = (object)contactInfo.ContactType ?? DBNull.Value;
            _PQ_CutomerAPI_SetContactInfo.Parameters["@ContactDetails"].Value = (object)contactInfo.ContactDetails ?? DBNull.Value;
            
            ContactInfo result = null;
            string ContactId = null;
            string ContactType = null;
            string ContactDetails = null;

            _rs = _PQ_CutomerAPI_SetContactInfo.ExecuteReader();

            if (_rs.HasRows)
            {
                while (_rs.Read())
                {
                    ContactId = _rs["ContactId"].ToString();
                    ContactType = _rs["ContactType"].ToString();
                    ContactDetails = _rs["ContactDetails"].ToString();
                    
                    result = new ContactInfo(ContactId, ContactType, ContactDetails);
                }
                _rs.Close();
                return result;
            }
            _rs.Close();
            return result;
        }

        public Address UpdateClientAddressFunc(Address address)
        {
            _PQ_CutomerAPI_SetMailAddress.Parameters["@AddressId"].Value = (object)address.AddressId ?? DBNull.Value;
            _PQ_CutomerAPI_SetMailAddress.Parameters["@AddressType"].Value = (object)address.AddressType ?? DBNull.Value;
            _PQ_CutomerAPI_SetMailAddress.Parameters["@UnitNumber"].Value = (object)address.UnitNumber ?? DBNull.Value;
            _PQ_CutomerAPI_SetMailAddress.Parameters["@StreetNumber"].Value = (object)address.StreetNumber ?? DBNull.Value;
            _PQ_CutomerAPI_SetMailAddress.Parameters["@StreetName"].Value = (object)address.StreetName ?? DBNull.Value;
            _PQ_CutomerAPI_SetMailAddress.Parameters["@StreetType"].Value = (object)address.StreetType ?? DBNull.Value;
            _PQ_CutomerAPI_SetMailAddress.Parameters["@Direction"].Value = (object)address.Direction ?? DBNull.Value;
            _PQ_CutomerAPI_SetMailAddress.Parameters["@City"].Value = (object)address.City ?? DBNull.Value;
            _PQ_CutomerAPI_SetMailAddress.Parameters["@Province"].Value = (object)address.Province ?? DBNull.Value;
            _PQ_CutomerAPI_SetMailAddress.Parameters["@PostalCode"].Value = (object)address.PostalCode ?? DBNull.Value;
            
            Address result = null;
            string AddressId = null;
            string AddressType = null;
            string UnitNumber = null;
            string StreetNumber = null;
            string StreetName= null;
            string StreetType = null;
            string Direction = null;
            string City = null;
            string Province = null;
            string PostalCode = null;

            _rs = _PQ_CutomerAPI_SetMailAddress.ExecuteReader();

            if (_rs.HasRows)
            {
                while (_rs.Read())
                {
                    AddressId = _rs["AddressId"].ToString();
                    AddressType = _rs["AddressType"].ToString();
                    UnitNumber = _rs["UnitNumber"].ToString();
                    StreetNumber = _rs["StreetNumber"].ToString();
                    StreetName = _rs["StreetName"].ToString();
                    StreetType = _rs["StreetType"].ToString();
                    Direction = _rs["Direction"].ToString();
                    City = _rs["City"].ToString();
                    Province = _rs["Province"].ToString();
                    PostalCode  = _rs["PostalCode"].ToString();
                    
                    result = new Address(AddressId, AddressType, UnitNumber, StreetNumber, StreetName, StreetType, Direction, City, Province, PostalCode);
                }
                _rs.Close();
                return result;
            }
            _rs.Close();
            return result;
        }

        public string PQ_ServicingAPI_Product_MasterReferenceFunc ( string RMR_IDLink_XRP, string RMR_IDLink_XSU )
        {
            _PQ_ServicingAPI_Product_MasterReference.Parameters["@RMR_IDLink_XRP"].Value = (object)RMR_IDLink_XRP ?? DBNull.Value;
            _PQ_ServicingAPI_Product_MasterReference.Parameters["@RMR_IDLink_XSU"].Value = (object)RMR_IDLink_XSU ?? DBNull.Value;
            
            string result = null;

            _rs = _PQ_ServicingAPI_Product_MasterReference.ExecuteReader();

            if (_rs.HasRows)
            {
                while (_rs.Read())
                {
                    result = _rs["Result"].ToString();
                }
                _rs.Close();
                return result;
            }
            _rs.Close();
            return result;
        }

        public string PQ_ServicingAPI_Keys_MasterReferenceFunc ( string YMR_IDLink_ARMNet, string YMR_IDLink_Foreign, string YMR_IDLink_XFK )
        {
            _PQ_ServicingAPI_Keys_MasterReference.Parameters["@YMR_IDLink_ARMNet"].Value = (object)YMR_IDLink_ARMNet ?? DBNull.Value;
            _PQ_ServicingAPI_Keys_MasterReference.Parameters["@YMR_IDLink_Foreign"].Value = (object)YMR_IDLink_Foreign ?? DBNull.Value;
            _PQ_ServicingAPI_Keys_MasterReference.Parameters["@YMR_IDLink_XFK"].Value = (object)YMR_IDLink_XFK ?? DBNull.Value;
            
            string result = null;

            _rs = _PQ_ServicingAPI_Keys_MasterReference.ExecuteReader();

            if (_rs.HasRows)
            {
                while (_rs.Read())
                {
                    result = _rs["Result"].ToString();
                }
                _rs.Close();
                return result;
            }
            _rs.Close();
            return result;
        }

        public string PQ_ServicingAPI_Product_LoanAssetPropertyFunc ( 
            string RLAp_IDLink_RMR, 
            string RLAp_UnitNumber, 
            string RLAp_StreetNumber, 
            string RLAp_StreetName, 
            string RLAp_Direction, 
            string RLAp_City, 
            string RLAp_State, 
            string RLAp_PostCode, 
            string RLAP_IDLink_StreetType, 
            string RLAp_IDLink_Country )
        {
            _PQ_ServicingAPI_Product_LoanAssetProperty.Parameters["@RLAp_IDLink_RMR"].Value = (object)RLAp_IDLink_RMR ?? DBNull.Value;
            _PQ_ServicingAPI_Product_LoanAssetProperty.Parameters["@RLAp_UnitNumber"].Value = (object)RLAp_UnitNumber ?? DBNull.Value;
            _PQ_ServicingAPI_Product_LoanAssetProperty.Parameters["@RLAp_StreetNumber"].Value = (object)RLAp_StreetNumber ?? DBNull.Value;
            _PQ_ServicingAPI_Product_LoanAssetProperty.Parameters["@RLAp_StreetName"].Value = (object)RLAp_StreetName ?? DBNull.Value;
            _PQ_ServicingAPI_Product_LoanAssetProperty.Parameters["@RLAp_Direction"].Value = (object)RLAp_Direction ?? DBNull.Value;
            _PQ_ServicingAPI_Product_LoanAssetProperty.Parameters["@RLAp_City"].Value = (object)RLAp_City ?? DBNull.Value;
            _PQ_ServicingAPI_Product_LoanAssetProperty.Parameters["@RLAp_State"].Value = (object)RLAp_State ?? DBNull.Value;
            _PQ_ServicingAPI_Product_LoanAssetProperty.Parameters["@RLAp_PostCode"].Value = (object)RLAp_PostCode ?? DBNull.Value;
            _PQ_ServicingAPI_Product_LoanAssetProperty.Parameters["@RLAP_IDLink_StreetType"].Value = (object)RLAP_IDLink_StreetType ?? DBNull.Value;
            _PQ_ServicingAPI_Product_LoanAssetProperty.Parameters["@RLAp_IDLink_Country"].Value = (object)RLAp_IDLink_Country ?? DBNull.Value;
            
            string result = null;

            _rs = _PQ_ServicingAPI_Product_LoanAssetProperty.ExecuteReader();

            if (_rs.HasRows)
            {
                while (_rs.Read())
                {
                    result = _rs["Result"].ToString();
                }
                _rs.Close();
                return result;
            }
            _rs.Close();
            return result;
        }

        public string PQ_ServicingAPI_Product_LoanAssetMasterFunc ( string RLAm_IDLink_RMR, decimal RLAm_Value )
        {
            _PQ_ServicingAPI_Product_LoanAssetMaster.Parameters["@RLAm_IDLink_RMR"].Value = (object)RLAm_IDLink_RMR ?? DBNull.Value;
            _PQ_ServicingAPI_Product_LoanAssetMaster.Parameters["@RLAm_Value"].Value = (object)RLAm_Value ?? DBNull.Value;
            
            string result = null;

            _rs = _PQ_ServicingAPI_Product_LoanAssetMaster.ExecuteReader();

            if (_rs.HasRows)
            {
                while (_rs.Read())
                {
                    result = _rs["Result"].ToString();
                }
                _rs.Close();
                return result;
            }
            _rs.Close();
            return result;
        }

        public string PQ_ServicingAPI_Product_ControlBalanceFunc ( string RCB_IDLink_RMR, string RCB_IDLink_XRBl, decimal RCB_CurrentValue )
        {
            _PQ_ServicingAPI_Product_ControlBalance.Parameters["@RCB_IDLink_RMR"].Value = (object)RCB_IDLink_RMR ?? DBNull.Value;
            _PQ_ServicingAPI_Product_ControlBalance.Parameters["@RCB_IDLink_XRBl"].Value = (object)RCB_IDLink_XRBl ?? DBNull.Value;
            _PQ_ServicingAPI_Product_ControlBalance.Parameters["@RCB_CurrentValue"].Value = (object)RCB_CurrentValue ?? DBNull.Value;
            
            string result = null;

            _rs = _PQ_ServicingAPI_Product_ControlBalance.ExecuteReader();

            if (_rs.HasRows)
            {
                while (_rs.Read())
                {
                    result = _rs["Result"].ToString();
                }
                _rs.Close();
                return result;
            }
            _rs.Close();
            return result;
        }

        public string PQ_ServicingAPI_Product_ControlTermFunc ( string RCTe_IDLink_RMR, Int32 RCTe_Years, Int32 RCTe_Months, Int32 RCTe_TotalMonths, Int32 RCTe_Type )
        {
            _PQ_ServicingAPI_Product_ControlTerm.Parameters["@RCTe_IDLink_RMR"].Value = (object)RCTe_IDLink_RMR ?? DBNull.Value;
            _PQ_ServicingAPI_Product_ControlTerm.Parameters["@RCTe_Years"].Value = (object)RCTe_Years ?? DBNull.Value;
            _PQ_ServicingAPI_Product_ControlTerm.Parameters["@RCTe_Months"].Value = (object)RCTe_Months ?? DBNull.Value;
            _PQ_ServicingAPI_Product_ControlTerm.Parameters["@RCTe_TotalMonths"].Value = (object)RCTe_TotalMonths ?? DBNull.Value;
            _PQ_ServicingAPI_Product_ControlTerm.Parameters["@RCTe_Type"].Value = (object)RCTe_Type ?? DBNull.Value;
            
            string result = null;

            _rs = _PQ_ServicingAPI_Product_ControlTerm.ExecuteReader();

            if (_rs.HasRows)
            {
                while (_rs.Read())
                {
                    result = _rs["Result"].ToString();
                }
                _rs.Close();
                return result;
            }
            _rs.Close();
            return result;
        }

        public string PQ_ServicingAPI_Product_LoanMDTFunc ( string RLM_IDLink_RMR, string RLM_IDLink_XRPu, string RLM_IDLink_XRPy, string MortgageType )
        {
            _PQ_ServicingAPI_Product_LoanMDT.Parameters["@RLM_IDLink_RMR"].Value = (object)RLM_IDLink_RMR ?? DBNull.Value;
            _PQ_ServicingAPI_Product_LoanMDT.Parameters["@RLM_IDLink_XRPu"].Value = (object)RLM_IDLink_XRPu ?? DBNull.Value;
            _PQ_ServicingAPI_Product_LoanMDT.Parameters["@RLM_IDLink_XRPy"].Value = (object)RLM_IDLink_XRPy ?? DBNull.Value;
            _PQ_ServicingAPI_Product_LoanMDT.Parameters["@MortgageType"].Value = (object)MortgageType ?? DBNull.Value;
            
            string result = null;

            _rs = _PQ_ServicingAPI_Product_LoanMDT.ExecuteReader();

            if (_rs.HasRows)
            {
                while (_rs.Read())
                {
                    result = _rs["Result"].ToString();
                }
                _rs.Close();
                return result;
            }
            _rs.Close();
            return result;
        }

        public string PQ_ServicingAPI_Product_ControlFeatureFunc ( string RCFf_IDLink_RMR, string RCFf_IDLink_XRFf )
        {
            _PQ_ServicingAPI_Product_ControlFeature.Parameters["@RCFf_IDLink_RMR"].Value = (object)RCFf_IDLink_RMR ?? DBNull.Value;
            _PQ_ServicingAPI_Product_ControlFeature.Parameters["@RCFf_IDLink_XRFf"].Value = (object)RCFf_IDLink_XRFf ?? DBNull.Value;
            
            string result = null;

            _rs = _PQ_ServicingAPI_Product_ControlFeature.ExecuteReader();

            if (_rs.HasRows)
            {
                while (_rs.Read())
                {
                    result = _rs["Result"].ToString();
                }
                _rs.Close();
                return result;
            }
            _rs.Close();
            return result;
        }

        public string PQ_ServicingAPI_Product_ControlDateFunc ( string RCD_IDLink_RMR, int RCD_Type, DateTime RCD_CurrentStart )
        {
            _PQ_ServicingAPI_Product_ControlDate.Parameters["@RCD_IDLink_RMR"].Value = (object)RCD_IDLink_RMR ?? DBNull.Value;
            _PQ_ServicingAPI_Product_ControlDate.Parameters["@RCD_Type"].Value = (object)RCD_Type ?? DBNull.Value;
            _PQ_ServicingAPI_Product_ControlDate.Parameters["@RCD_CurrentStart"].Value = (object)RCD_CurrentStart ?? DBNull.Value;
            
            string result = null;

            _rs = _PQ_ServicingAPI_Product_ControlDate.ExecuteReader();

            if (_rs.HasRows)
            {
                while (_rs.Read())
                {
                    result = _rs["Result"].ToString();
                }
                _rs.Close();
                return result;
            }
            _rs.Close();
            return result;
        }

        public string PQ_ServicingAPI_Client_ContactDetailFunc ( string CCD_IDLink_CMR, string CCD_IDLink_XCT, string CCD_Details, string CCD_AreaCode )
        {
            _PQ_ServicingAPI_Client_ContactDetail.Parameters["@CCD_IDLink_CMR"].Value = (object)CCD_IDLink_CMR ?? DBNull.Value;
            _PQ_ServicingAPI_Client_ContactDetail.Parameters["@CCD_IDLink_XCT"].Value = (object)CCD_IDLink_XCT ?? DBNull.Value;
            _PQ_ServicingAPI_Client_ContactDetail.Parameters["@CCD_Details"].Value = (object)CCD_Details ?? DBNull.Value;
            _PQ_ServicingAPI_Client_ContactDetail.Parameters["@CCD_AreaCode"].Value = (object)CCD_AreaCode ?? DBNull.Value;
            
            string result = null;

            _rs = _PQ_ServicingAPI_Client_ContactDetail.ExecuteReader();

            if (_rs.HasRows)
            {
                while (_rs.Read())
                {
                    result = _rs["Result"].ToString();
                }
                _rs.Close();
                return result;
            }
            _rs.Close();
            return result;
        }

        public string PQ_ServicingAPI_Client_AddressDetailFunc (
            string CAD_IDLink_CMR,
            string CAD_IDLink_XAT,
            string CAD_IDLink_StreetType,
            string CAD_IDLink_Country,
            string CAD_UnitNumber,
            string CAD_StreetNumber,
            string CAD_StreetName,
            string CAD_City,
            string CAD_State,
            string CAD_PostCode
        )
        {
            _PQ_ServicingAPI_Client_AddressDetail.Parameters["@CAD_IDLink_CMR"].Value = (object)CAD_IDLink_CMR ?? DBNull.Value;
            _PQ_ServicingAPI_Client_AddressDetail.Parameters["@CAD_IDLink_XAT"].Value = (object)CAD_IDLink_XAT ?? DBNull.Value;
            _PQ_ServicingAPI_Client_AddressDetail.Parameters["@CAD_IDLink_StreetType"].Value = (object)CAD_IDLink_StreetType ?? DBNull.Value;
            _PQ_ServicingAPI_Client_AddressDetail.Parameters["@CAD_IDLink_Country"].Value = (object)CAD_IDLink_Country ?? DBNull.Value;
            _PQ_ServicingAPI_Client_AddressDetail.Parameters["@CAD_UnitNumber"].Value = (object)CAD_UnitNumber ?? DBNull.Value;
            _PQ_ServicingAPI_Client_AddressDetail.Parameters["@CAD_StreetName"].Value = (object)CAD_StreetName ?? DBNull.Value;
            _PQ_ServicingAPI_Client_AddressDetail.Parameters["@CAD_StreetNumber"].Value = (object)CAD_StreetNumber ?? DBNull.Value;
            _PQ_ServicingAPI_Client_AddressDetail.Parameters["@CAD_City"].Value = (object)CAD_City ?? DBNull.Value;
            _PQ_ServicingAPI_Client_AddressDetail.Parameters["@CAD_State"].Value = (object)CAD_State ?? DBNull.Value;
            _PQ_ServicingAPI_Client_AddressDetail.Parameters["@CAD_PostCode"].Value = (object)CAD_PostCode ?? DBNull.Value;

            string result = null;

            _rs = _PQ_ServicingAPI_Client_AddressDetail.ExecuteReader();

            if (_rs.HasRows)
            {
                while (_rs.Read())
                {
                    result = _rs["Result"].ToString();
                }
                _rs.Close();
                return result;
            }
            _rs.Close();
            return result;
        }

        public string PQ_ServicingAPI_Client_TypeIndividualFunc (
            string CTI_IDLink_CMR, 
            string CTI_IDLink_XCM,
            string CTI_FirstName,
            string CTI_MiddleName,
            string CTI_Surname,
            DateTime CTI_DOB
        )
        {
            _PQ_ServicingAPI_Client_TypeIndividual.Parameters["@CTI_IDLink_CMR"].Value = (object)CTI_IDLink_CMR ?? DBNull.Value;
            _PQ_ServicingAPI_Client_TypeIndividual.Parameters["@CTI_IDLink_XCM"].Value = (object)CTI_IDLink_XCM ?? DBNull.Value;
            _PQ_ServicingAPI_Client_TypeIndividual.Parameters["@CTI_FirstName"].Value = (object)CTI_FirstName ?? DBNull.Value;
            _PQ_ServicingAPI_Client_TypeIndividual.Parameters["@CTI_MiddleName"].Value = (object)CTI_MiddleName ?? DBNull.Value;
            _PQ_ServicingAPI_Client_TypeIndividual.Parameters["@CTI_Surname"].Value = (object)CTI_Surname ?? DBNull.Value;
            _PQ_ServicingAPI_Client_TypeIndividual.Parameters["@CTI_DOB"].Value = (object)CTI_DOB ?? DBNull.Value;

            string result = null;

            _rs = _PQ_ServicingAPI_Client_TypeIndividual.ExecuteReader();

            if (_rs.HasRows)
            {
                while (_rs.Read())
                {
                    result = _rs["Result"].ToString();
                }
                _rs.Close();
                return result;
            }
            _rs.Close();
            return result;
        }

        public string PQ_ServicingAPI_Client_UniqueIdentifierFunc (string CUI_IDLink_CMR, string CUI_IDLink_XDI, string CUI_IDLink_XSYSct, string CUI_DocumentNumber )
        {
            _PQ_ServicingAPI_Client_UniqueIdentifier.Parameters["@CUI_IDLink_CMR"].Value = (object)CUI_IDLink_CMR ?? DBNull.Value;
            _PQ_ServicingAPI_Client_UniqueIdentifier.Parameters["@CUI_IDLink_XDI"].Value = (object)CUI_IDLink_XDI ?? DBNull.Value;
            _PQ_ServicingAPI_Client_UniqueIdentifier.Parameters["@CUI_IDLink_XSYSct"].Value = (object)CUI_IDLink_XSYSct ?? DBNull.Value;
            _PQ_ServicingAPI_Client_UniqueIdentifier.Parameters["@CUI_DocumentNumber"].Value = (object)CUI_DocumentNumber ?? DBNull.Value;

            string result = null;

            _rs = _PQ_ServicingAPI_Client_UniqueIdentifier.ExecuteReader();

            if (_rs.HasRows)
            {
                while (_rs.Read())
                {
                    result = _rs["Result"].ToString();
                }
                _rs.Close();
                return result;
            }
            _rs.Close();
            return result;
        }

        public string PQ_ServicingAPI_Client_IndividualEmploymentFunc (
            string CED_IDLink_CMR, 
            string CED_IDLink_XCEt,
            string CED_IDLink_Country_C,	 
            string CED_EmployerName_C,
            string CED_UnitNumber_C,
            string CED_StreetNumber_C,
            string CED_StreetName_C,
            string CED_City_C,
            string CED_State_C,
            string CED_PostCode_C,
            Int32 CED_TimeInServiceY_C, 
            Int32 CED_TimeInServiceM_C,	
            string CED_IDLink_Occupation_C,
            DateTime CED_StartDate,
            string CED_JobTitle
        )
        {
            _PQ_ServicingAPI_Client_IndividualEmployment.Parameters["@CED_IDLink_CMR"].Value = (object)CED_IDLink_CMR ?? DBNull.Value;
            _PQ_ServicingAPI_Client_IndividualEmployment.Parameters["@CED_IDLink_XCEt"].Value = (object)CED_IDLink_XCEt ?? DBNull.Value;
            _PQ_ServicingAPI_Client_IndividualEmployment.Parameters["@CED_IDLink_Country_C"].Value = (object)CED_IDLink_Country_C ?? DBNull.Value;
            _PQ_ServicingAPI_Client_IndividualEmployment.Parameters["@CED_EmployerName_C"].Value = (object)CED_EmployerName_C ?? DBNull.Value;
            _PQ_ServicingAPI_Client_IndividualEmployment.Parameters["@CED_UnitNumber_C"].Value = (object)CED_UnitNumber_C ?? DBNull.Value;
            _PQ_ServicingAPI_Client_IndividualEmployment.Parameters["@CED_StreetNumber_C"].Value = (object)CED_StreetNumber_C ?? DBNull.Value;
            _PQ_ServicingAPI_Client_IndividualEmployment.Parameters["@CED_StreetName_C"].Value = (object)CED_StreetName_C ?? DBNull.Value;
            _PQ_ServicingAPI_Client_IndividualEmployment.Parameters["@CED_City_C"].Value = (object)CED_City_C ?? DBNull.Value;
            _PQ_ServicingAPI_Client_IndividualEmployment.Parameters["@CED_State_C"].Value = (object)CED_State_C ?? DBNull.Value;
            _PQ_ServicingAPI_Client_IndividualEmployment.Parameters["@CED_PostCode_C"].Value = (object)CED_PostCode_C ?? DBNull.Value;
            _PQ_ServicingAPI_Client_IndividualEmployment.Parameters["@CED_TimeInServiceY_C"].Value = (object)CED_TimeInServiceY_C ?? DBNull.Value;
            _PQ_ServicingAPI_Client_IndividualEmployment.Parameters["@CED_TimeInServiceM_C"].Value = (object)CED_TimeInServiceM_C ?? DBNull.Value;
            _PQ_ServicingAPI_Client_IndividualEmployment.Parameters["@CED_IDLink_Occupation_C"].Value = (object)CED_IDLink_Occupation_C ?? DBNull.Value;
            _PQ_ServicingAPI_Client_IndividualEmployment.Parameters["@CED_StartDate"].Value = (object)CED_StartDate ?? DBNull.Value;
            _PQ_ServicingAPI_Client_IndividualEmployment.Parameters["@CED_JobTitle"].Value = (object)CED_JobTitle ?? DBNull.Value;

            string result = null;

            _rs = _PQ_ServicingAPI_Client_IndividualEmployment.ExecuteReader();

            if (_rs.HasRows)
            {
                while (_rs.Read())
                {
                    result = _rs["Result"].ToString();
                }
                _rs.Close();
                return result;
            }
            _rs.Close();
            return result;
        }

        public string PQ_ServicingAPI_Product_LoanLiabilityCreditFunc ( 
            string RLLc_IDLink_RMR, 
            string RLLc_IDLink_XLBc, 
            string RLLc_CreditProvider, 
            decimal RLLc_MonthlyRepayment, 
            decimal RLLc_BalanceOwing )
        {
            _PQ_ServicingAPI_Product_LoanLiabilityCredit.Parameters["@RLLc_IDLink_RMR"].Value = (object)RLLc_IDLink_RMR ?? DBNull.Value;
            _PQ_ServicingAPI_Product_LoanLiabilityCredit.Parameters["@RLLc_IDLink_XLBc"].Value = (object)RLLc_IDLink_XLBc ?? DBNull.Value;
            _PQ_ServicingAPI_Product_LoanLiabilityCredit.Parameters["@RLLc_CreditProvider"].Value = (object)RLLc_CreditProvider ?? DBNull.Value;
            _PQ_ServicingAPI_Product_LoanLiabilityCredit.Parameters["@RLLc_MonthlyRepayment"].Value = (object)RLLc_MonthlyRepayment ?? DBNull.Value;
            _PQ_ServicingAPI_Product_LoanLiabilityCredit.Parameters["@RLLc_BalanceOwing"].Value = (object)RLLc_BalanceOwing ?? DBNull.Value;

            string result = null;

            _rs = _PQ_ServicingAPI_Product_LoanLiabilityCredit.ExecuteReader();

            if (_rs.HasRows)
            {
                while (_rs.Read())
                {
                    result = _rs["Result"].ToString();
                }
                _rs.Close();
                return result;
            }
            _rs.Close();
            return result;
        }

        public string PQ_ServicingAPI_client_individualincomeFunc ( string CINc_IDLink_CMR, string CINc_IDLink_XIN, string CINc_IDLink_XFR, decimal CINc_Value, string CINc_IDLink_CED )
        {
            _PQ_ServicingAPI_client_individualincome.Parameters["@CINc_IDLink_CMR"].Value = (object)CINc_IDLink_CMR ?? DBNull.Value;
            _PQ_ServicingAPI_client_individualincome.Parameters["@CINc_IDLink_XIN"].Value = (object)CINc_IDLink_XIN ?? DBNull.Value;
            _PQ_ServicingAPI_client_individualincome.Parameters["@CINc_IDLink_XFR"].Value = (object)CINc_IDLink_XFR ?? DBNull.Value;
            _PQ_ServicingAPI_client_individualincome.Parameters["@CINc_Value"].Value = (object)CINc_Value ?? DBNull.Value;
            _PQ_ServicingAPI_client_individualincome.Parameters["@CINc_IDLink_CED"].Value = (object)CINc_IDLink_CED ?? DBNull.Value;

            string result = null;

            _rs = _PQ_ServicingAPI_client_individualincome.ExecuteReader();

            if (_rs.HasRows)
            {
                while (_rs.Read())
                {
                    result = _rs["Result"].ToString();
                }
                _rs.Close();
                return result;
            }
            _rs.Close();
            return result;
        }      

        public string PQ_ServicingAPI_Product_SecurityPTYFunc ( 
            string RSP_IDLink_RMR, 
            string RSP_IDLink_StreetType, 
            string RSP_IDLink_Country, 
            string RSP_IDLink_XRTy, 
            string RSP_IDLink_XRTu, 
            string RSP_IDLink_XRTt, 
            decimal RSP_PurchasePrice,
            decimal RSP_EstimatedValue,
            string RSP_UnitNumber,
            string RSP_StreetNumber,
            string RSP_StreetName,
            string RSP_City,
            string RSP_State,
            string RSP_PostCode,
            string RSP_Direction,		
            string RSP_IDLink_XRTc,
            decimal RSP_HeatingValue,
            string RSP_IDLink_XRTs,
            string RSP_IDLink_XRTw
        )
        {
            _PQ_ServicingAPI_Product_SecurityPTY.Parameters["@RSP_IDLink_RMR"].Value = (object)RSP_IDLink_RMR ?? DBNull.Value;
            _PQ_ServicingAPI_Product_SecurityPTY.Parameters["@RSP_IDLink_StreetType"].Value = (object)RSP_IDLink_StreetType ?? DBNull.Value;
            _PQ_ServicingAPI_Product_SecurityPTY.Parameters["@RSP_IDLink_Country"].Value = (object)RSP_IDLink_Country ?? DBNull.Value;
            _PQ_ServicingAPI_Product_SecurityPTY.Parameters["@RSP_IDLink_XRTy"].Value = (object)RSP_IDLink_XRTy ?? DBNull.Value;
            _PQ_ServicingAPI_Product_SecurityPTY.Parameters["@RSP_IDLink_XRTu"].Value = (object)RSP_IDLink_XRTu ?? DBNull.Value;
            _PQ_ServicingAPI_Product_SecurityPTY.Parameters["@RSP_IDLink_XRTt"].Value = (object)RSP_IDLink_XRTt ?? DBNull.Value;
            _PQ_ServicingAPI_Product_SecurityPTY.Parameters["@RSP_PurchasePrice"].Value = (object)RSP_PurchasePrice ?? DBNull.Value;
            _PQ_ServicingAPI_Product_SecurityPTY.Parameters["@RSP_EstimatedValue"].Value = (object)RSP_EstimatedValue ?? DBNull.Value;
            _PQ_ServicingAPI_Product_SecurityPTY.Parameters["@RSP_UnitNumber"].Value = (object)RSP_UnitNumber ?? DBNull.Value;
            _PQ_ServicingAPI_Product_SecurityPTY.Parameters["@RSP_StreetNumber"].Value = (object)RSP_StreetNumber ?? DBNull.Value;
            _PQ_ServicingAPI_Product_SecurityPTY.Parameters["@RSP_StreetName"].Value = (object)RSP_StreetName ?? DBNull.Value;
            _PQ_ServicingAPI_Product_SecurityPTY.Parameters["@RSP_City"].Value = (object)RSP_City ?? DBNull.Value;
            _PQ_ServicingAPI_Product_SecurityPTY.Parameters["@RSP_State"].Value = (object)RSP_State ?? DBNull.Value;
            _PQ_ServicingAPI_Product_SecurityPTY.Parameters["@RSP_PostCode"].Value = (object)RSP_PostCode ?? DBNull.Value;
            _PQ_ServicingAPI_Product_SecurityPTY.Parameters["@RSP_Direction"].Value = (object)RSP_Direction ?? DBNull.Value;
            _PQ_ServicingAPI_Product_SecurityPTY.Parameters["@RSP_IDLink_XRTc"].Value = (object)RSP_IDLink_XRTc ?? DBNull.Value;
            _PQ_ServicingAPI_Product_SecurityPTY.Parameters["@RSP_HeatingValue"].Value = (object)RSP_HeatingValue ?? DBNull.Value;
            _PQ_ServicingAPI_Product_SecurityPTY.Parameters["@RSP_IDLink_XRTs"].Value = (object)RSP_IDLink_XRTs ?? DBNull.Value;
            _PQ_ServicingAPI_Product_SecurityPTY.Parameters["@RSP_IDLink_XRTw"].Value = (object)RSP_IDLink_XRTw ?? DBNull.Value;

            string result = null;

            _rs = _PQ_ServicingAPI_Product_SecurityPTY.ExecuteReader();

            if (_rs.HasRows)
            {
                while (_rs.Read())
                {
                    result = _rs["Result"].ToString();
                }
                _rs.Close();
                return result;
            }
            _rs.Close();
            return result;
        }

        public string PQ_ServicingAPI_Product_LoanLiabilityMasterFunc (
            string RLLm_IDLink_RMR,
            string RLLm_IDLink_XLBo,
            string RLLm_IDLink_XFR,
            decimal RLLm_Value,
            decimal RLLm_ValuePerYear,	
            string RLLm_IDLink_RSP
        )
        {
            _PQ_ServicingAPI_Product_LoanLiabilityMaster.Parameters["@RLLm_IDLink_RMR"].Value = (object)RLLm_IDLink_RMR ?? DBNull.Value;
            _PQ_ServicingAPI_Product_LoanLiabilityMaster.Parameters["@RLLm_IDLink_XLBo"].Value = (object)RLLm_IDLink_XLBo ?? DBNull.Value;
            _PQ_ServicingAPI_Product_LoanLiabilityMaster.Parameters["@RLLm_IDLink_XFR"].Value = (object)RLLm_IDLink_XFR ?? DBNull.Value;
            _PQ_ServicingAPI_Product_LoanLiabilityMaster.Parameters["@RLLm_Value"].Value = (object)RLLm_Value ?? DBNull.Value;
            _PQ_ServicingAPI_Product_LoanLiabilityMaster.Parameters["@RLLm_ValuePerYear"].Value = (object)RLLm_ValuePerYear ?? DBNull.Value;
            _PQ_ServicingAPI_Product_LoanLiabilityMaster.Parameters["@RLLm_IDLink_RSP"].Value = (object)RLLm_IDLink_RSP ?? DBNull.Value;

            string result = null;

            _rs = _PQ_ServicingAPI_Product_LoanLiabilityMaster.ExecuteReader();

            if (_rs.HasRows)
            {
                while (_rs.Read())
                {
                    result = _rs["Result"].ToString();
                }
                _rs.Close();
                return result;
            }
            _rs.Close();
            return result;
        }

        public string PQ_ServicingAPI_Link_MasterReferenceFunc (  string LMR_IDLink_CMR, string LMR_IDLink_Code_ID, string LMR_IDLink_Association )
        {
            _PQ_ServicingAPI_Link_MasterReference.Parameters["@LMR_IDLink_CMR"].Value = (object)LMR_IDLink_CMR ?? DBNull.Value;
            _PQ_ServicingAPI_Link_MasterReference.Parameters["@LMR_IDLink_Code_ID"].Value = (object)LMR_IDLink_Code_ID ?? DBNull.Value;
            _PQ_ServicingAPI_Link_MasterReference.Parameters["@LMR_IDLink_Association"].Value = (object)LMR_IDLink_Association ?? DBNull.Value;

            string result = null;

            _rs = _PQ_ServicingAPI_Link_MasterReference.ExecuteReader();

            if (_rs.HasRows)
            {
                while (_rs.Read())
                {
                    result = _rs["Result"].ToString();
                }
                _rs.Close();
                return result;
            }
            _rs.Close();
            return result;
        }

        public string PQ_ServicingAPI_Client_MasterReferenceFunc ( string CMR_Name, string CMR_LanguagePreference )
        {
            _PQ_ServicingAPI_Client_MasterReference.Parameters["@CMR_Name"].Value = (object)CMR_Name ?? DBNull.Value;
            _PQ_ServicingAPI_Client_MasterReference.Parameters["@CMR_LanguagePreference"].Value = (object)CMR_LanguagePreference ?? DBNull.Value;

            string result = null;

            _rs = _PQ_ServicingAPI_Client_MasterReference.ExecuteReader();

            if (_rs.HasRows)
            {
                while (_rs.Read())
                {
                    result = _rs["Result"].ToString();
                }
                _rs.Close();
                return result;
            }
            _rs.Close();
            return result;
        }


        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _PQ_CutomerAPI_GetAPIUsersList.Dispose();
                _PQ_CutomerAPI_GetStreetTypeList.Dispose();
                _PQ_CutomerAPI_GetUserBrandsList.Dispose();
                _PQ_CutomerAPI_GetBrandDealsList.Dispose();
                _PQ_CutomerAPI_GetRequestTypeList.Dispose();
                _PQ_CustomerAPI_AskQuestion.Dispose();
                _PQ_CutomerAPI_GetMailAddress.Dispose();
                _PQ_CutomerAPI_GetContactInfo.Dispose();
                _PQ_CutomerAPI_GetDealClientsList.Dispose();
                _PQ_CutomerAPI_SetContactInfo.Dispose();
                _PQ_CutomerAPI_SetMailAddress.Dispose();
                _Connection.Dispose();
                _rs.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
