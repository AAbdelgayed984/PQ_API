namespace PQ_API.Classes
{
    public class Address
    {
        public string AddressId { get; set; }
        public string AddressType { get; set; }
        public string UnitNumber { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string StreetType { get; set; }
        public string Direction { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }

        public Address()
        {

        }
        
        public Address(string addressId, string addressType, string unitNumber, string streetNumber, string streetName, string streetType, string direction, string city, string province, string postalCode)
        {
            AddressId = addressId;
            AddressType = addressType;
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
            return $"AddressId {AddressId}, AddressType {AddressType}, UnitNumber {UnitNumber}, StreetNumber {StreetNumber}, StreetName {StreetName}, StreetType {StreetType}, Direction {Direction}, City {City}, Province {Province}, PostalCode {PostalCode}";
        }
    }
}