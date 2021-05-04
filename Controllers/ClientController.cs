using System.Collections.Generic;
using PQ_API.Classes;
using PQ_API.Helpers;
using PQ_API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

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
        public IActionResult ClientsList(string RMR_ID)
        {
            try
            {
                _logger.LogInformation($"ClientsList Call with RMR_ID {RMR_ID}");
                if (String.IsNullOrEmpty(RMR_ID))
                {
                    throw new Exception(message:"Missing RMR_ID.");
                }
                
                List<Client> listClientsInfo = _ClientService.GetAll(RMR_ID);
                return Ok(listClientsInfo);
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, message:"Exception Occurred.");
                return new StatusCodeResult(500);
            }  
        }

        [Authorize]
        [HttpGet("ClientInfo")]
        public IActionResult ClientInfo(string CMR_ID, string RMR_ID)
        {
            try
            {
                _logger.LogInformation($"ClientInfo Call with CMR_ID {CMR_ID}, RMR_ID {RMR_ID}");
                if (String.IsNullOrEmpty(CMR_ID))
                {
                    throw new Exception(message:"Missing CMR_ID.");
                }
                
                Client ClientInfo = _ClientService.GetById(CMR_ID, RMR_ID);
                return Ok(ClientInfo);
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, message:"Exception Occurred.");
                return new StatusCodeResult(500);
            }  
        }

        [Authorize]
        [HttpPost("UpdateClientAddress")]
        public IActionResult UpdateClientAddress([FromBody] Address address)
        {
            try
            {
                string addressString = address.ToString();
                _logger.LogInformation($"UpdateClientAddress Call with {addressString}");
                if (String.IsNullOrEmpty(address.AddressId))
                {
                    throw new Exception(message:"Missing AddressId.");
                }
                
                Address UpdateClientAddressResponse = _ClientService.UpdateClientAddress(address);
                return Ok(UpdateClientAddressResponse);
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, message:"Exception Occurred.");
                return new StatusCodeResult(500);
            } 
        }

        [Authorize]
        [HttpPost("UpdateContactInfo")]
        public IActionResult UpdateContactInfo([FromBody] ContactInfo contactInfo)
        {
            try
            {
                string contactInfoString = contactInfo.ToString();
                _logger.LogInformation($"UpdateClientAddress Call with {contactInfoString}");
                if (String.IsNullOrEmpty(contactInfo.ContactId))
                {
                    throw new Exception(message:"Missing ContactId.");
                }
                
                ContactInfo UpdateContactInfoResponse = _ClientService.UpdateContactInfo(contactInfo);
                return Ok(UpdateContactInfoResponse);
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, message:"Exception Occurred.");
                return new StatusCodeResult(500);
            } 
        }
    }
}