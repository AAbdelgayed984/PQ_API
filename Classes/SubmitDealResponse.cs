using System.Collections.Generic;

namespace PQ_API.Classes
{
    public class SubmitDealResponse
    {
        public Deal Deal { get; set; }
        public List<Client> Clients { get; set; }

        public SubmitDealResponse(Deal deal, List<Client> clients)
        {
            Deal = deal;
            Clients = clients;
        }
    }
}