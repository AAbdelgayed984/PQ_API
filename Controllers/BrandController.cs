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
        public IEnumerable<BrandInfo> BrandsList()
        {
            List<BrandInfo> listBrandInfo = _brandService.GetAll();
            return listBrandInfo.ToArray();
        }

        [Authorize]
        [HttpGet("brandInfo")]
        public IActionResult BrandInfo(string Brand_CMR_ID)
        {
            if (Brand_CMR_ID == null)
                return BadRequest(new { message = "Brand_CMR_ID is missing" });
            
            BrandInfo brandInfo = _brandService.GetById(Brand_CMR_ID);

            return Ok(brandInfo);
        }
    }
}