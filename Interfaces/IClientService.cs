using System.Collections.Generic;
using PQ_API.Classes;

namespace PQ_API.Interfaces
{
    public interface IClientService
    {
        List<Client> GetAll(string RMR_ID);
        Client GetById(string CMR_ID);
        ContactInfo UpdateContactInfo(ContactInfo contactInfo);
        Address UpdateClientAddress(Address address);
    }
}