using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PQ_API.Classes;

namespace PQ_API.DataConnect
{
    public class RUBIDataConnect : IDisposable
    {
        public const string SubmitDeal = "EXEC dbo.PQ_ServicingAPI_SubmitDeal"; 
        public const string GetAPIUsersList = "EXEC dbo.PQ_CutomerAPI_GetAPIUsersList"; 
        public const string GetUserBrandsList = "EXEC dbo.PQ_CutomerAPI_GetUserBrandsList @UserId";
        public const string GetStreetTypeList = "EXEC dbo.PQ_CutomerAPI_GetStreetTypeList";
        public const string GetBrandDealsList = "EXEC dbo.PQ_CutomerAPI_GetBrandDealsList @Brand_CMR_ID";
        public const string GetRequestTypeList = "EXEC dbo.PQ_CutomerAPI_GetRequestTypeList @Brand_CMR_ID";
        public const string AskQuestion = "EXEC dbo.PQ_PQ_API_AskQuestion @CMR_ID, @RMR_ID, @RequestType, @Comments, @ContactInformation, @ContactTime";
        public const string GetClientsList = "EXEC dbo.PQ_CutomerAPI_GetDealClientsList @RMR_ID";
        public const string GetClientAddressesList = "EXEC dbo.PQ_CutomerAPI_GetMailAddress @CMR_ID";
        public const string GetClientContactInfoList = "EXEC dbo.PQ_CutomerAPI_GetContactInfo @CMR_ID";
        public const string SetClientContactInfo = "EXEC dbo.PQ_CutomerAPI_SetContactInfo @ContactId, @Email, @HomePhone, @WorkPhone, @MobilePhone";
        public const string SetClientAddress = "EXEC PQ_CutomerAPI_SetMailAddress @AddressId, @AddressType, @UnitNumber, @StreetNumber, @StreetName, @StreetType, @Direction, @City, @Province, @PostalCode";
        private SqlCommand _SubmitDeal;
        private SqlCommand _GetClientsList;
        private SqlCommand _GetClientAddressesList;
        private SqlCommand _GetClientContactInfoList;
        private SqlCommand _GetAPIUsersList;
        private SqlCommand _GetUserBrandsList;
        private SqlCommand _GetStreetTypeList;
        private SqlCommand _GetRequestTypeList;
        private SqlCommand _GetBrandDealsList;
        private SqlCommand _AskQuestion;
        private SqlCommand _SetClientContactInfo;
        private SqlCommand _SetClientAddress;
        private SqlConnection _Connection;
        private SqlDataReader _rs;
        private string _ConnectionString;

        public RUBIDataConnect(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
            _Connection = new SqlConnection(ConnectionString);
            _Connection.Open();

            _SubmitDeal = new SqlCommand(SubmitDeal, _Connection);
            
            _GetAPIUsersList = new SqlCommand(GetAPIUsersList, _Connection);

            _GetUserBrandsList = new SqlCommand(GetUserBrandsList, _Connection);
            _GetUserBrandsList.Parameters.Add("@UserId", SqlDbType.VarChar);

            _GetClientsList = new SqlCommand(GetClientsList, _Connection);
            _GetClientsList.Parameters.Add("@RMR_ID", SqlDbType.VarChar);

            _GetClientAddressesList = new SqlCommand(GetClientAddressesList, _Connection);
            _GetClientAddressesList.Parameters.Add("@CMR_ID", SqlDbType.VarChar);

            _GetClientContactInfoList = new SqlCommand(GetClientContactInfoList, _Connection);
            _GetClientContactInfoList.Parameters.Add("@CMR_ID", SqlDbType.VarChar);

            _GetBrandDealsList = new SqlCommand(GetBrandDealsList, _Connection);
            _GetBrandDealsList.Parameters.Add("@Brand_CMR_ID", SqlDbType.VarChar);

            _GetRequestTypeList = new SqlCommand(GetRequestTypeList, _Connection);
            _GetRequestTypeList.Parameters.Add("@Brand_CMR_ID", SqlDbType.VarChar);

            _GetStreetTypeList = new SqlCommand(GetStreetTypeList, _Connection);

            _AskQuestion = new SqlCommand(AskQuestion, _Connection);
            _AskQuestion.Parameters.Add("@CMR_ID", SqlDbType.VarChar);
            _AskQuestion.Parameters.Add("@RMR_ID", SqlDbType.VarChar);
            _AskQuestion.Parameters.Add("@RequestType", SqlDbType.VarChar);
            _AskQuestion.Parameters.Add("@Comments", SqlDbType.VarChar);
            _AskQuestion.Parameters.Add("@ContactInformation", SqlDbType.VarChar);
            _AskQuestion.Parameters.Add("@ContactTime", SqlDbType.VarChar);

            _SetClientAddress = new SqlCommand(SetClientAddress, _Connection);
            _SetClientAddress.Parameters.Add("@AddressID", SqlDbType.VarChar);
             _SetClientAddress.Parameters.Add("@AddressType", SqlDbType.VarChar);
            _SetClientAddress.Parameters.Add("@UnitNumber", SqlDbType.VarChar);
            _SetClientAddress.Parameters.Add("@StreetNumber", SqlDbType.VarChar);
            _SetClientAddress.Parameters.Add("@StreetName", SqlDbType.VarChar);
            _SetClientAddress.Parameters.Add("@StreetType", SqlDbType.VarChar);
            _SetClientAddress.Parameters.Add("@Direction", SqlDbType.VarChar);
            _SetClientAddress.Parameters.Add("@City", SqlDbType.VarChar);
            _SetClientAddress.Parameters.Add("@Province", SqlDbType.VarChar);
            _SetClientAddress.Parameters.Add("@PostalCode", SqlDbType.VarChar);

            _SetClientContactInfo = new SqlCommand(SetClientContactInfo, _Connection);
            _SetClientContactInfo.Parameters.Add("@ContactId", SqlDbType.VarChar);
            _SetClientContactInfo.Parameters.Add("@Email", SqlDbType.VarChar);
            _SetClientContactInfo.Parameters.Add("@HomePhone", SqlDbType.VarChar);
            _SetClientContactInfo.Parameters.Add("@WorkPhone", SqlDbType.VarChar);
            _SetClientContactInfo.Parameters.Add("@MobilePhone", SqlDbType.VarChar);
        }

        public List<User> GetAPIUsersListFunc()
        {
            List<User> result = new List<User>();
            string API_User_ID = null;
            string API_User_FirstName = null;
            string API_User_LastName = null;
            string API_User_UserName = null;
            string API_User_Password = null;

            _rs = _GetAPIUsersList.ExecuteReader();

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
            _GetUserBrandsList.Parameters["@UserId"].Value = (object)UserId ?? DBNull.Value; ;
            List<BrandInfo> result = new List<BrandInfo>();
            string Brand_CMR_ID = null;
            string Brand_Name = null;
            string Brand_EmailAddress = null;

            _rs = _GetUserBrandsList.ExecuteReader();

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
            _GetBrandDealsList.Parameters["@Brand_CMR_ID"].Value = (object)Brand_CMR_ID ?? DBNull.Value; ;
            List<Deal> result = new List<Deal>();
            string RMR_ID = null;
            Int32 RMR_SeqNumber;
            string ComponentType = null;
            double LoanAmount;
            string MortgageType = null;
            string PropertyAddress = null;
            double InterestPaidPriorYear;
            double InterestPaidYearToDate;
            double PrincipalPaidPriorYear;
            double PrincipalPaidYearToDate;
            double CurrentMortgageBalance;
            string ProductDescription = null;
            string RateType = null;
            string InterestRate = null;
            string PaymentType = null;
            double PaymentAmount;
            string PaymentFrequency = null;
            string LastPaymentDate = null;
            string NextPaymentDate = null;
            string MaturityDate = null;
            Int32 RemainingAmortization_Months;		
            Int32 RemainingAmortization_Years;

            _rs = _GetBrandDealsList.ExecuteReader();

            if (_rs.HasRows)
            {
                while (_rs.Read())
                {
                    RMR_ID = _rs["RMR_ID"].ToString();
                    RMR_SeqNumber = Convert.ToInt32(_rs["RMR_SeqNumber"]);
                    ComponentType = _rs["ComponentType"].ToString();
                    LoanAmount = Convert.ToDouble(_rs["LoanAmount"]);
                    MortgageType = _rs["MortgageType"].ToString();
                    PropertyAddress = _rs["PropertyAddress"].ToString();
                    InterestPaidPriorYear = Convert.ToDouble(_rs["InterestPaidPriorYear"]);
                    InterestPaidYearToDate = Convert.ToDouble(_rs["InterestPaidYearToDate"]);
                    PrincipalPaidPriorYear = Convert.ToDouble(_rs["PrincipalPaidPriorYear"]);
                    PrincipalPaidYearToDate = Convert.ToDouble(_rs["PrincipalPaidYearToDate"]);
                    CurrentMortgageBalance = Convert.ToDouble(_rs["CurrentMortgageBalance"]);
                    ProductDescription = _rs["ProductDescription"].ToString();
                    RateType = _rs["RateType"].ToString();
                    InterestRate = _rs["InterestRate"].ToString();
                    PaymentType = _rs["PaymentType"].ToString();
                    PaymentAmount = Convert.ToDouble(_rs["PaymentAmount"]);
                    PaymentFrequency = _rs["PaymentFrequency"].ToString();
                    LastPaymentDate = _rs["LastPaymentDate"].ToString();
                    NextPaymentDate = _rs["NextPaymentDate"].ToString();
                    MaturityDate = _rs["MaturityDate"].ToString();
                    RemainingAmortization_Months = Convert.ToInt32(_rs["RemainingAmortization_Months"]);		
                    RemainingAmortization_Years = Convert.ToInt32(_rs["RemainingAmortization_Years"]);

                    
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
            _GetRequestTypeList.Parameters["@Brand_CMR_ID"].Value = (object)Brand_CMR_ID ?? DBNull.Value; ;
            List<RequestType> result = new List<RequestType>();
            string TypeOfRequest_En = null;
            string TypeOfRequest_Fq = null;
            string TypeOfRequest_lbl_En = null;
            string TypeOfRequest_lbl_Fq = null;

            _rs = _GetRequestTypeList.ExecuteReader();

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
            _GetClientsList.Parameters["@RMR_ID"].Value = (object)RMR_ID ?? DBNull.Value;
            List<Client> clientsList = new List<Client>();
            List<Address> addressList = new List<Address>();

            _rs = _GetClientsList.ExecuteReader();
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
                    _GetClientAddressesList.Parameters["@CMR_ID"].Value = (object)clientFromList.CMR_ID ?? DBNull.Value;
                    _rs = _GetClientAddressesList.ExecuteReader();
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
                    _GetClientContactInfoList.Parameters["@CMR_ID"].Value = (object)clientFromList.CMR_ID ?? DBNull.Value;
                    _rs = _GetClientContactInfoList.ExecuteReader();
                    if (_rs.HasRows)
                    {
                        ContactInfo contactInfo = new ContactInfo();
                        while (_rs.Read())
                        {  
                            contactInfo.ContactId = _rs["ContactId"].ToString();                          
                            contactInfo.Email = _rs["Email"].ToString();
                            contactInfo.HomePhone = _rs["HomePhone"].ToString();
                            contactInfo.WorkPhone = _rs["WorkPhone"].ToString();
                            contactInfo.MobilePhone = _rs["MobilePhone"].ToString();   
                        }
                        clientFromList.ContactInfo = contactInfo;
                    }
                    _rs.Close();
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

            _rs = _GetStreetTypeList.ExecuteReader();

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
            _AskQuestion.Parameters["@CMR_ID"].Value = (object)question.CMR_ID ?? DBNull.Value; ;
            _AskQuestion.Parameters["@RMR_ID"].Value = (object)question.RMR_ID ?? DBNull.Value; ;
            _AskQuestion.Parameters["@RequestType"].Value = (object)question.RequestType ?? DBNull.Value; ;
            _AskQuestion.Parameters["@Comments"].Value = (object)question.Comments ?? DBNull.Value; ;
            _AskQuestion.Parameters["@ContactInformation"].Value = (object)question.ContactInformation ?? DBNull.Value; ;
            _AskQuestion.Parameters["@ContactTime"].Value = (object)question.ContactTime ?? DBNull.Value; ;
            
            AskQuestion result = null;
            string CMR_ID_Selected = null;
            string RMR_ID_Selected = null;
            string RequestType = null;
            string Comments = null;
            string ContactInformation = null;
            string ContactTime = null;

            _rs = _AskQuestion.ExecuteReader();

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
            _SetClientContactInfo.Parameters["@ContactId"].Value = (object)contactInfo.ContactId ?? DBNull.Value; ;
            _SetClientContactInfo.Parameters["@Email"].Value = (object)contactInfo.Email ?? DBNull.Value; ;
            _SetClientContactInfo.Parameters["@HomePhone"].Value = (object)contactInfo.HomePhone ?? DBNull.Value; ;
            _SetClientContactInfo.Parameters["@WorkPhone"].Value = (object)contactInfo.WorkPhone ?? DBNull.Value; ;
            _SetClientContactInfo.Parameters["@MobilePhone"].Value = (object)contactInfo.MobilePhone ?? DBNull.Value; ;
            
            ContactInfo result = null;
            string ContactId = null;
            string Email = null;
            string HomePhone = null;
            string WorkPhone = null;
            string MobilePhone = null;

            _rs = _SetClientContactInfo.ExecuteReader();

            if (_rs.HasRows)
            {
                while (_rs.Read())
                {
                    ContactId = _rs["ContactId"].ToString();
                    Email = _rs["Email"].ToString();
                    HomePhone = _rs["HomePhone"].ToString();
                    WorkPhone = _rs["WorkPhone"].ToString();
                    MobilePhone = _rs["MobilePhone"].ToString();
                    
                    result = new ContactInfo(ContactId, Email, HomePhone, WorkPhone, MobilePhone);
                }
                _rs.Close();
                return result;
            }
            _rs.Close();
            return result;
        }

        public Address UpdateClientAddressFunc(Address address)
        {
            _SetClientAddress.Parameters["@AddressId"].Value = (object)address.AddressId ?? DBNull.Value;
            _SetClientAddress.Parameters["@AddressType"].Value = (object)address.AddressId ?? DBNull.Value;
            _SetClientAddress.Parameters["@UnitNumber"].Value = (object)address.UnitNumber ?? DBNull.Value;
            _SetClientAddress.Parameters["@StreetNumber"].Value = (object)address.StreetNumber ?? DBNull.Value;
            _SetClientAddress.Parameters["@StreetName"].Value = (object)address.StreetName ?? DBNull.Value;
            _SetClientAddress.Parameters["@StreetType"].Value = (object)address.StreetType ?? DBNull.Value;
            _SetClientAddress.Parameters["@Direction"].Value = (object)address.Direction ?? DBNull.Value;
            _SetClientAddress.Parameters["@City"].Value = (object)address.City ?? DBNull.Value;
            _SetClientAddress.Parameters["@Province"].Value = (object)address.Province ?? DBNull.Value;
            _SetClientAddress.Parameters["@PostalCode"].Value = (object)address.PostalCode ?? DBNull.Value;
            
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

            _rs = _SetClientAddress.ExecuteReader();

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

        public SubmitDealResponse SubmitDealFunc(SubmitDealRequest submitDealRequest)
        {
            List<User> result = new List<User>();
            string API_User_ID = null;
            string API_User_FirstName = null;
            string API_User_LastName = null;
            string API_User_UserName = null;
            string API_User_Password = null;

            _rs = _GetAPIUsersList.ExecuteReader();

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
                return null;
            }
            _rs.Close();
            return null;

        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _GetAPIUsersList.Dispose();
                _GetStreetTypeList.Dispose();
                _GetUserBrandsList.Dispose();
                _GetBrandDealsList.Dispose();
                _GetRequestTypeList.Dispose();
                _AskQuestion.Dispose();
                _GetClientAddressesList.Dispose();
                _GetClientContactInfoList.Dispose();
                _GetClientsList.Dispose();
                _SetClientContactInfo.Dispose();
                _SetClientAddress.Dispose();
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
