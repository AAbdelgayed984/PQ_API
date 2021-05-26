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
using System;
using System.Net;

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
        public IActionResult Get()
        {            
            try
            {
                _logger.LogInformation("Get StreetTypes Call");
                
                RUBIDataConnect rubiDataConnect = new RUBIDataConnect(_rubiDBSettings.ConnectionString);

                List<StreetType> listStreetType = rubiDataConnect.GetStreetTypeListFunc();
                return Ok(listStreetType);
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, message:"Exception Occurred.");
                return Result(HttpStatusCode.InternalServerError, ex.Message);
            } 
        }

        [Authorize]
        [HttpGet("RequestTypes")]
        public IActionResult Get(string Brand_CMR_ID)
        {
            try
            {
                _logger.LogInformation($"Get RequestTypes Call with Brand_CMR_ID {Brand_CMR_ID}");
                
                if (String.IsNullOrEmpty(Brand_CMR_ID))
                {
                    throw new Exception(message:"Brand_CMR_ID is missing.");
                }
                
                RUBIDataConnect rubiDataConnect = new RUBIDataConnect(_rubiDBSettings.ConnectionString);

                List<RequestType> listRequestType = rubiDataConnect.GetRequestTypeListFunc(Brand_CMR_ID);
                return Ok(listRequestType);
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, message:"Exception Occurred.");
                return Result(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize]
        [HttpGet("GetProducts")]
        public IActionResult GetProducts(string Brand_CMR_ID)
        {
            try
            {
                _logger.LogInformation($"Get GetProducts Call with Brand_CMR_ID {Brand_CMR_ID}");
                
                if (String.IsNullOrEmpty(Brand_CMR_ID))
                {
                    throw new Exception(message:"Brand_CMR_ID is missing.");
                }
                
                RUBIDataConnect rubiDataConnect = new RUBIDataConnect(_rubiDBSettings.ConnectionString);

                List<Product> listProduct = rubiDataConnect.GetProductsListFunc(Brand_CMR_ID);
                return Ok(listProduct);
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, message:"Exception Occurred.");
                return Result(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize]
        [HttpGet("GetIncomeTypes")]
        public IActionResult GetIncomeTypes()
        {
            try
            {
                _logger.LogInformation($"Get GetIncomeTypes Call");
                
                RUBIDataConnect rubiDataConnect = new RUBIDataConnect(_rubiDBSettings.ConnectionString);

                List<IncomeType> listIncomeTypes = rubiDataConnect.GetIncomeTypesListFunc();
                return Ok(listIncomeTypes);
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, message:"Exception Occurred.");
                return Result(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize]
        [HttpGet("GetOccupationTypes")]
        public IActionResult GetOccupationTypes()
        {
            try
            {
                _logger.LogInformation($"Get GetOccupationTypes Call");
                
                RUBIDataConnect rubiDataConnect = new RUBIDataConnect(_rubiDBSettings.ConnectionString);

                List<OccupationType> listOccupationTypes = rubiDataConnect.GetOccupationTypesListFunc();
                return Ok(listOccupationTypes);
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, message:"Exception Occurred.");
                return Result(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize]
        [HttpGet("GetIndustrySectors")]
        public IActionResult GetIndustrySectors()
        {
            try
            {
                _logger.LogInformation($"Get GetIndustrySectors Call");
                
                RUBIDataConnect rubiDataConnect = new RUBIDataConnect(_rubiDBSettings.ConnectionString);

                List<IndustrySector> listGetIndustrySectors = rubiDataConnect.GetIndustrySectorsListFunc();
                return Ok(listGetIndustrySectors);
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, message:"Exception Occurred.");
                return Result(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        private static ActionResult Result(HttpStatusCode statusCode, string reason) => new ContentResult
        {
            StatusCode = (int)statusCode,
            Content = $"Status Code: {(int)statusCode}; {statusCode}; Reason: {reason}",
            ContentType = "text/plain",
        };
    }
}
