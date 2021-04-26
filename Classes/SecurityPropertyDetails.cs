using System;
using System.Text.Json.Serialization;

namespace PQ_API.Classes
{
    public class SecurityPropertyDetails
    {
        public string UnitNumber { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public Enums.StreetTypes StreetType { get; set; }
        public string Direction { get; set; }
        public string City { get; set; }
        public Enums.Province Province { get; set; }
        public string PostalCode { get; set; }
        public Enums.Country Country { get; set; }
        public Decimal PropertyValue { get;set; }
        public Enums.PropertyStyles propertyStyle {get;set;}
        public Enums.ValuationMethods ValuationMethod {get;set;}
        public Enums.PropertyTypes PropertyType {get;set;}
        public Enums.DwellingTypes DwellingType {get;set;}
        public Enums.Occupancies Occupancy {get;set;}
        public Enums.PropertyZones PropertyZone {get;set;}
        public Enums.SewageTypes SewageType {get;set;}
        public Enums.WaterType WaterType {get;set;}
        public Enums.ConstructionTypes ConstructionType {get;set;}
        public int LoanToValue {get;set;}
        public Enums.BorrowerFlag BorrowerFlag {get;set;}

        
    }
}
