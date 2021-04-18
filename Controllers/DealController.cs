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
    public class DealController : ControllerBase
    {
        private readonly ILogger<DealController> _logger;
        private IDealService _dealService;
        public DealController(ILogger<DealController> logger, IDealService brandService)
        {
            _logger = logger;
            _dealService = brandService;
        }

        [Authorize]
        [HttpGet("dealsList")]
        public IEnumerable<Deal> DealsList(string Brand_CMR_ID)
        {
            List<Deal> listdealsInfo = _dealService.GetAll(Brand_CMR_ID);
            return listdealsInfo.ToArray();
        }

        [Authorize]
        [HttpGet("dealInfo")]
        public IActionResult DealInfo(string RMR_ID, string Brand_CMR_ID)
        {
            if (RMR_ID == null)
                return BadRequest(new { message = "RMR_ID is missing" });
            
            Deal dealInfo = _dealService.GetById(RMR_ID, Brand_CMR_ID);

            return Ok(dealInfo);
        }

        [Authorize]
        [HttpPost("AskQuestion")]
        public IActionResult AskQuestion([FromBody] AskQuestion question)
        {
            AskQuestion AskQuestionResponse = _dealService.AskQuestion(question);

            return Ok(AskQuestionResponse);
        }
    }
}