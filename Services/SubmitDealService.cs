using System.Linq;
using Microsoft.AspNetCore.Http;
using PQ_API.Classes;
using PQ_API.DataConnect;
using PQ_API.Interfaces;

namespace PQ_API.Services
{
    public class SubmitDealService : ISubmitDealService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private User _user;
        private readonly RubiDBSettings _rubiDBSettings;
        private IUserService _userService;
        private RUBIDataConnect _rubiDataConnect;
        public SubmitDealService(RubiDBSettings rubiDBSettings, IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
             _rubiDBSettings = rubiDBSettings;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
            _user = _userService.GetById(_httpContextAccessor.HttpContext.User.Claims.First(i => i.Type == "id").Value);
            _rubiDataConnect = new RUBIDataConnect(rubiDBSettings.ConnectionString);
        }

        public SubmitDealResponse SubmitDeal(SubmitDealRequest request)
        {
            return _rubiDataConnect.SubmitDealFunc(request);
        }

    }
}