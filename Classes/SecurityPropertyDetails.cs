using System;
using System.Text.Json.Serialization;

namespace PQ_API.Classes
{
    public class SecurityPropertyDetails
    {
        public string UnitNumber { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string StreetType { get; set; }
        public string Direction { get; set; }
        public string City { get; set; }
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
        public string PostalCode { get; set; }
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
        public Decimal PropertyValue { get;set; }
        private Enums.PropertyStyles _PropertyStyle;
        public Enums.PropertyStyles PropertyStyle 
        {
            get
            {
                return _PropertyStyle;
            }
            set
            {
                if (!Enum.IsDefined(typeof(Enums.PropertyStyles), value))
                    throw new System.ArgumentException(string.Format("Invalid Enums.PropertyStyles {0}.", value));
                _PropertyStyle = value;
            }
        }
        private Enums.ValuationMethods _ValuationMethod;
        public Enums.ValuationMethods ValuationMethod 
        {
            get
            {
                return _ValuationMethod;
            }
            set
            {
                if (!Enum.IsDefined(typeof(Enums.ValuationMethods), value))
                    throw new System.ArgumentException(string.Format("Invalid Enums.ValuationMethods {0}.", value));
                _ValuationMethod = value;
            }
        }
        private Enums.PropertyTypes _PropertyType;
        public Enums.PropertyTypes PropertyType 
        {
            get
            {
                return _PropertyType;
            }
            set
            {
                if (!Enum.IsDefined(typeof(Enums.PropertyTypes), value))
                    throw new System.ArgumentException(string.Format("Invalid Enums.PropertyTypes {0}.", value));
                _PropertyType = value;
            }
        }
        private Enums.DwellingTypes _DwellingType;
        public Enums.DwellingTypes DwellingType 
        {
            get
            {
                return _DwellingType;
            }
            set
            {
                if (!Enum.IsDefined(typeof(Enums.DwellingTypes), value))
                    throw new System.ArgumentException(string.Format("Invalid Enums.DwellingTypes {0}.", value));
                _DwellingType = value;
            }
        }
        private Enums.Occupancies _Occupancy;
        public Enums.Occupancies Occupancy 
        {
            get
            {
                return _Occupancy;
            }
            set
            {
                if (!Enum.IsDefined(typeof(Enums.Occupancies), value))
                    throw new System.ArgumentException(string.Format("Invalid Enums.Occupancies {0}.", value));
                _Occupancy = value;
            }
        }
        private Enums.PropertyZones _PropertyZone;
        public Enums.PropertyZones PropertyZone 
        {
            get
            {
                return _PropertyZone;
            }
            set
            {
                if (!Enum.IsDefined(typeof(Enums.PropertyZones), value))
                    throw new System.ArgumentException(string.Format("Invalid Enums.PropertyZones {0}.", value));
                _PropertyZone = value;
            }
        }
        private Enums.SewageTypes _SewageType;
        public Enums.SewageTypes SewageType 
        {
            get
            {
                return _SewageType;
            }
            set
            {
                if (!Enum.IsDefined(typeof(Enums.SewageTypes), value))
                    throw new System.ArgumentException(string.Format("Invalid Enums.SewageTypes {0}.", value));
                _SewageType = value;
            }
        }
        private Enums.WaterType _WaterType;
        public Enums.WaterType WaterType 
        {
            get
            {
                return _WaterType;
            }
            set
            {
                if (!Enum.IsDefined(typeof(Enums.WaterType), value))
                    throw new System.ArgumentException(string.Format("Invalid Enums.WaterType {0}.", value));
                _WaterType = value;
            }
        }
        private Enums.ConstructionTypes _ConstructionType;
        public Enums.ConstructionTypes ConstructionType 
        {
            get
            {
                return _ConstructionType;
            }
            set
            {
                if (!Enum.IsDefined(typeof(Enums.ConstructionTypes), value))
                    throw new System.ArgumentException(string.Format("Invalid Enums.ConstructionTypes {0}.", value));
                _ConstructionType = value;
            }
        }
        public int LoanToValue {get;set;}
        private Enums.BorrowerFlag _BorrowerFlag;
        public Enums.BorrowerFlag BorrowerFlag 
        {
            get
            {
                return _BorrowerFlag;
            }
            set
            {
                if (!Enum.IsDefined(typeof(Enums.BorrowerFlag), value))
                    throw new System.ArgumentException(string.Format("Invalid Enums.BorrowerFlag {0}.", value));
                _BorrowerFlag = value;
            }
        }

        private Enums.PropertyListingType _PropertyListingType;
        public Enums.PropertyListingType PropertyListingType 
        {
            get
            {
                return _PropertyListingType;
            }
            set
            {
                if (!Enum.IsDefined(typeof(Enums.PropertyListingType), value))
                    throw new System.ArgumentException(string.Format("Invalid Enums.PropertyListingType {0}.", value));
                _PropertyListingType = value;
            }
        }  

        public Int32 AgeOfStructure {set; get;}   
    }
}
