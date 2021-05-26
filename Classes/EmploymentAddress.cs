using System;

namespace PQ_API.Classes
{
    public class EmploymentAddress
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

        public EmploymentAddress()
        {

        }
        
        public EmploymentAddress(string unitNumber, string streetNumber, string streetName, string streetType, string direction, string city, Enums.Province province, string postalCode)
        {
            UnitNumber = unitNumber;
            StreetNumber = streetNumber;
            StreetName = streetName;
            StreetType = streetType;
            Direction = direction;
            City = city;
            Province = province;
            PostalCode = postalCode;
        }

        public override string ToString()
        {
            return $"UnitNumber {UnitNumber}, StreetNumber {StreetNumber}, StreetName {StreetName}, StreetType {StreetType}, Direction {Direction}, City {City}, Province {Province}, PostalCode {PostalCode}";
        }
    }
}