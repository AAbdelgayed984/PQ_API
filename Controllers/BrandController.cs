using System.Collections.Generic;
using PQ_API.Classes;
using PQ_API.Helpers;
using PQ_API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using PQ_API.DataConnect;
using System.Net;

namespace PQ_API.Controllers
{
    [Route("customerapi/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly ILogger<BrandController> _logger;
        private readonly RubiDBSettings _rubiDBSettings;
        private IBrandService _brandService;
        private RUBIDataConnect rubiDataConnect;
        public BrandController(ILogger<BrandController> logger, IBrandService brandService, RubiDBSettings rubiDBSettings)
        {
            _logger = logger;
            _brandService = brandService;
            _rubiDBSettings = rubiDBSettings;
            rubiDataConnect = new RUBIDataConnect(_rubiDBSettings.ConnectionString);
        }

        [Authorize]
        [HttpGet("brandsList")]
        public IActionResult BrandsList()
        {
            try
            {
                _logger.LogInformation("Brands List Call");
                List<BrandInfo> listBrandInfo = _brandService.GetAll();
                return Ok(listBrandInfo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, message:"Exception Occurred.");
                return Result(HttpStatusCode.InternalServerError, ex.Message);
            } 
            
        }

        [Authorize]
        [HttpGet("brandInfo")]
        public IActionResult BrandInfo(string Brand_CMR_ID)
        {
            try
            {
                _logger.LogInformation($"Brand Info Call with Brand_CMR_ID {Brand_CMR_ID}");
                if (String.IsNullOrEmpty(Brand_CMR_ID))
                {
                    throw new Exception(message:"Missing Brand_CMR_ID.");
                }
                else if (!rubiDataConnect.IsValid_CMR_ID(Brand_CMR_ID))
                {
                    throw new Exception(message:"Invalid Brand_CMR_ID.");
                }                    

                BrandInfo brandInfo = _brandService.GetById(Brand_CMR_ID);
                return Ok(brandInfo);
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