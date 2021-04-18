using System;
using System.Collections.Generic;
using System.Linq;
using PQ_API.Classes;
using PQ_API.DataConnect;
using PQ_API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace PQ_API.Services
{
    public class ClientService : IClientService
    {
        private List<Client> _Clients;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private User _user;
        private readonly RubiDBSettings _rubiDBSettings;
        private IUserService _userService;
        private RUBIDataConnect _rubiDataConnect;
        
        public ClientService(RubiDBSettings rubiDBSettings, IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
             _rubiDBSettings = rubiDBSettings;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
            _user = _userService.GetById(_httpContextAccessor.HttpContext.User.Claims.First(i => i.Type == "id").Value);
            _rubiDataConnect = new RUBIDataConnect(rubiDBSettings.ConnectionString);
            
        }

        public List<Client> GetAll(string RMR_ID)
        {
            _Clients = _rubiDataConnect.GetDealClientsListFunc(RMR_ID);
            return _Clients;
        }

        public Client GetById(string clientId, string RMR_ID)
        {
            _Clients = _rubiDataConnect.GetDealClientsListFunc(RMR_ID);
            return _Clients.FirstOrDefault(x => x.CMR_ID == clientId);
        }

        public ContactInfo UpdateContactInfo(ContactInfo contactInfo)
        {
            return _rubiDataConnect.UpdateContactInfoFunc(contactInfo);
        }

        public Address UpdateClientAddress(Address address)
        {
            return _rubiDataConnect.UpdateClientAddressFunc(address);
        }
    }
}