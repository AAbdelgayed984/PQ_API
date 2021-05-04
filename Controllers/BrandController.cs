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
    public class BrandController : ControllerBase
    {
        private readonly ILogger<BrandController> _logger;
        private IBrandService _brandService;
        public BrandController(ILogger<BrandController> logger, IBrandService brandService)
        {
            _logger = logger;
            _brandService = brandService;
        }

        [Authorize]
        [HttpGet("brandsList")]
        public IActionResult BrandsList()
        {
            try
            {
                _logger.LogInformation("Brands List Call with");
                List<BrandInfo> listBrandInfo = _brandService.GetAll();
                return Ok(listBrandInfo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, message:"Exception Occurred.");
                return new StatusCodeResult(500);
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

                BrandInfo brandInfo = _brandService.GetById(Brand_CMR_ID);
                return Ok(brandInfo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, message:"Exception Occurred.");
                return new StatusCodeResult(500);
            }        
        }
    }
}