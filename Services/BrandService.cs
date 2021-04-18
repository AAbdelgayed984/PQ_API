using System.Collections.Generic;
using System.Linq;
using PQ_API.Classes;
using PQ_API.DataConnect;
using PQ_API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace PQ_API.Services
{
    public class BrandService : IBrandService
    {
        private List<BrandInfo> _brands;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private User _user;
        private readonly RubiDBSettings _rubiDBSettings;
        private IUserService _userService;
        public BrandService(RubiDBSettings rubiDBSettings, IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
             _rubiDBSettings = rubiDBSettings;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
            _user = _userService.GetById(_httpContextAccessor.HttpContext.User.Claims.First(i => i.Type == "id").Value);
            RUBIDataConnect rubiDataConnect = new RUBIDataConnect(rubiDBSettings.ConnectionString);
            _brands = rubiDataConnect.GetUsersBrandsListFunc(_user.UserId );
        }

        public List<BrandInfo> GetAll()
        {
            return _brands;
        }

        public BrandInfo GetById(string brandId)
        {
            return _brands.FirstOrDefault(x => x.Brand_CMR_ID == brandId);
        }
    }
}