using System;
using System.Text.Json.Serialization;

namespace PQ_API.Classes
{
    public class Borrower
    {
        private Enums.ClientType _ClientType;
        public Enums.ClientType ClientType 
        {
            get
            {
                return _ClientType;
            }
            set
            {
                if (!Enum.IsDefined(typeof(Enums.ClientType), value))
                    throw new System.ArgumentException(string.Format("Invalid Enums.ClientType {0}.", value));
                _ClientType = value;
            }
        }
        public string CustomerAccountNumber {get;set;}
        public string FirstName {get;set;}
        public string MiddleName { get; set; }
        public string LastName {get;set;}
        private Enums.MartialStatus _MartialStatus;
        public Enums.MartialStatus MartialStatus 
        {
            get
            {
                return _MartialStatus;
            }
            set
            {
                if (!Enum.IsDefined(typeof(Enums.MartialStatus), value))
                    throw new System.ArgumentException(string.Format("Invalid Enums.MartialStatus {0}.", value));
                _MartialStatus = value;
            }
        } 
        public DateTime DOB {get;set;}
        public int Sin {get;set;}
        public string HomePhone {get;set;}
        public string MobilePhone {get;set;}
        public string Email {get;set;}
        private Enums.Title _Title;
        public Enums.Title Title 
        {
            get
            {
                return _Title;
            }
            set
            {
                if (!Enum.IsDefined(typeof(Enums.Title), value))
                    throw new System.ArgumentException(string.Format("Invalid Enums.Title {0}.", value));
                _Title = value;
            }
        }
        private Enums.Gender _Gender;
        public Enums.Gender Gender 
        {
            get
            {
                return _Gender;
            }
            set
            {
                if (!Enum.IsDefined(typeof(Enums.Gender), value))
                    throw new System.ArgumentException(string.Format("Invalid Enums.Gender {0}.", value));
                _Gender = value;
            }
        }
        public int BeaconScore {get;set;}
        public string Unit {get;set;}
        public string Number {get;set;}
        public string StreetName {get;set;}
        public string StreetType {get;set;}
        public string City {get;set;}
        private Enums.Province _Province; 
        public Enums.Province Province 
        {
            get
            {
                return _Province;
            }
            set
            {
                if (!Enum.IsDefined(typeof(Enums.Province), value))
                    throw new System.ArgumentException(string.Format("Invalid Enums.Province {0}.", value));
                _Province = value;
            }
        }
        public string PostalCode {get;set;}
        private Enums.Country _Country;
        public Enums.Country Country 
        {
            get
            {
                return _Country;
            }
            set
            {
                if (!Enum.IsDefined(typeof(Enums.Country), value))
                    throw new System.ArgumentException(string.Format("Invalid Enums.Country {0}.", value));
                _Country = value;
            }
        }
        private Enums.Language _Language;
        public Enums.Language Language 
        {
            get
            {
                return _Language;
            }
            set
            {
                if (!Enum.IsDefined(typeof(Enums.Language), value))
                    throw new System.ArgumentException(string.Format("Invalid Enums.Language {0}.", value));
                _Language = value;
            }
        }

        public int TimeInServiceYear;
        public int TimeInServiceMonth;

        public DateTime EmploymentStart;
        public string EmploymentName;
        public Address EmploymentAddress;

        public Decimal IncomeAmount;
        public string IncomeType;

    }
}