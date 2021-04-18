using PQ_API.Classes;
using PQ_API.DataConnect;
using PQ_API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace PQ_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ControlController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private User _user;
        private readonly ILogger<ControlController> _logger;
        private readonly RubiDBSettings _rubiDBSettings;
        private IUserService _userService;
        public ControlController(ILogger<ControlController> logger, RubiDBSettings rubiDBSettings, IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _rubiDBSettings = rubiDBSettings;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
            _user = _userService.GetById(_httpContextAccessor.HttpContext.User.Claims.First(i => i.Type == "id").Value);
        }

        [Authorize]
        [HttpGet("StreetTypes")]
        public IEnumerable<StreetType> Get()
        {
            RUBIDataConnect rubiDataConnect = new RUBIDataConnect(_rubiDBSettings.ConnectionString);

            List<StreetType> listStreetType = rubiDataConnect.GetStreetTypeListFunc();
            return listStreetType.ToArray();
        }

        [Authorize]
        [HttpGet("RequestTypes")]
        public IEnumerable<RequestType> Get(string Brand_CMR_ID)
        {
            RUBIDataConnect rubiDataConnect = new RUBIDataConnect(_rubiDBSettings.ConnectionString);

            List<RequestType> listRequestType = rubiDataConnect.GetRequestTypeListFunc(Brand_CMR_ID);
            return listRequestType.ToArray();
        }
    }
}
