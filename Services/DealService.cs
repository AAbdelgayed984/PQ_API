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
    public class DealService : IDealService
    {
        private List<Deal> _deals;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private User _user;
        private readonly RubiDBSettings _rubiDBSettings;
        private IUserService _userService;
        private RUBIDataConnect _rubiDataConnect;
        
        public DealService(RubiDBSettings rubiDBSettings, IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
             _rubiDBSettings = rubiDBSettings;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
            _user = _userService.GetById(_httpContextAccessor.HttpContext.User.Claims.First(i => i.Type == "id").Value);
            _rubiDataConnect = new RUBIDataConnect(rubiDBSettings.ConnectionString);
        }

        public List<Deal> GetAll(string brandId)
        {
            _deals = _rubiDataConnect.GetBrandDealsListFunc(brandId);
            return _deals;
        }

        public Deal GetById(string dealId)
        {
            return _deals.FirstOrDefault(x => x.RMR_ID == dealId);
        }

        public AskQuestion AskQuestion(AskQuestion question)
        {
            return _rubiDataConnect.AskQuestionFunc(question);
        }
    }
}