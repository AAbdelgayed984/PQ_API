using System.Collections.Generic;
using PQ_API.Classes;
using PQ_API.Helpers;
using PQ_API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PQ_API.Controllers
{
    [Route("customerapi/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private IClientService _ClientService;
        public ClientController(ILogger<ClientController> logger, IClientService clientService)
        {
            _logger = logger;
            _ClientService = clientService;
        }

        [Authorize]
        [HttpGet("ClientsList")]
        public IEnumerable<Client> ClientsList(string RMR_ID)
        {
            List<Client> listClientsInfo = _ClientService.GetAll(RMR_ID);
            return listClientsInfo.ToArray();
        }

        [Authorize]
        [HttpGet("ClientInfo")]
        public IActionResult ClientInfo(string CMR_ID, string RMR_ID)
        {
            if (CMR_ID == null)
                return BadRequest(new { message = "CMR_ID is missing" });
            
            Client ClientInfo = _ClientService.GetById(CMR_ID, RMR_ID);

            return Ok(ClientInfo);
        }

        [Authorize]
        [HttpPost("UpdateClientAddress")]
        public IActionResult UpdateClientAddress([FromBody] Address address)
        {
            Address UpdateClientAddressResponse = _ClientService.UpdateClientAddress(address);

            return Ok(UpdateClientAddressResponse);
        }

        [Authorize]
        [HttpPost("UpdateContactInfo")]
        public IActionResult UpdateContactInfo([FromBody] ContactInfo contactInfo)
        {
            ContactInfo UpdateContactInfoResponse = _ClientService.UpdateContactInfo(contactInfo);

            return Ok(UpdateContactInfoResponse);
        }
    }
}