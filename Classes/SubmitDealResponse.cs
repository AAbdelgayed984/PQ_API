using System.Collections.Generic;

namespace PQ_API.Classes
{
    public class SubmitDealResponse
    {
        public Deal Deal { get; set; }
        public List<Client> Clients { get; set; }
    }
}