using System;
using System.Text.Json.Serialization;

namespace PQ_API.Classes
{
    public class Borrower
    {
        public Enums.ClientType ClientType {get;set;}
        public string CustomerAccountNumber {get;set;}
        public string FirstName {get;set;}
        public string MiddleName { get; set; }
        public string LastName {get;set;}
        public Enums.MartialStatus MartialStatus {get;set;} 
        public DateTime DOB {get;set;}
        public int Sin {get;set;}
        public string HomePhone {get;set;}
        public string MobilePhone {get;set;}
        public string Email {get;set;}
        public Enums.Title Title {get;set;}
        public Enums.Gender Gender {get;set;}
        public int BeaconScore {get;set;}
        public string MailingAddress {get;set;}
        public string Unit {get;set;}
        public string Number {get;set;}
        public string StreetName {get;set;}
        public Enums.StreetTypes StreetType {get;set;}
        public string City {get;set;}
        public Enums.Province Province {get;set;}
        public string PostalCode {get;set;}
        public Enums.Country Country {get;set;}
        public Enums.Language Language {get;set;}
    }
}