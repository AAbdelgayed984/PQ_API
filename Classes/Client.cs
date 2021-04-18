using System.Collections.Generic;

namespace PQ_API.Classes
{
    public class Client
    {
        public string CMR_ID { get; set; } 
        public string FirstName { get; set; } 
        public string MiddleName { get; set; } 
        public string LastName { get; set; }
        public List<Address> Addresses { get; set; }
        public ContactInfo ContactInfo { get; set; }   
    }
}