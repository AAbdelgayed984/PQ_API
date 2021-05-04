using System.Collections.Generic;
using PQ_API.Classes;
using PQ_API.Helpers;
using PQ_API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using PQ_API.DataConnect;

namespace PQ_API.Controllers
{
    [Route("customerapi/[controller]")]
    [ApiController]
    public class DealController : ControllerBase
    {
        private readonly ILogger<DealController> _logger;
        private readonly RubiDBSettings _rubiDBSettings;
        private IDealService _dealService;
        private RUBIDataConnect rubiDataConnect;
        public DealController(ILogger<DealController> logger, IDealService brandService, RubiDBSettings rubiDBSettings )
        {
            _logger = logger;
            _dealService = brandService;
            _rubiDBSettings = rubiDBSettings;
            rubiDataConnect = new RUBIDataConnect(_rubiDBSettings.ConnectionString);
        }

        [Authorize]
        [HttpGet("dealsList")]
        public IActionResult DealsList(string Brand_CMR_ID)
        {
            try
            {
                _logger.LogInformation($"DealsList Call with Brand_CMR_ID {Brand_CMR_ID}" );

                if (string.IsNullOrEmpty(Brand_CMR_ID))
                {
                    throw new Exception(message:"Brand_CMR_ID is missing.");
                }

                List<Deal> listdealsInfo = _dealService.GetAll(Brand_CMR_ID);

                return Ok(listdealsInfo);
            }
            catch (Exception ex)
            {
                 _logger.LogError(ex, message:"Exception Occurred.");
                return new BadRequestObjectResult(new { message = ex.Message, currentDate = DateTime.Now });
            } 
        }

        [Authorize]
        [HttpGet("dealInfo")]
        public IActionResult DealInfo(string RMR_ID, string Brand_CMR_ID)
        {
            try
            {
                _logger.LogInformation($"DealInfo Call with Brand_CMR_ID {Brand_CMR_ID} and RMR_ID {RMR_ID}");

                if (string.IsNullOrEmpty(Brand_CMR_ID))
                {
                    throw new Exception(message:"Brand_CMR_ID is missing.");
                }
                else if (string.IsNullOrEmpty(RMR_ID))
                {
                    throw new Exception(message:"RMR_ID is missing.");
                }

                Deal dealInfo = _dealService.GetById(RMR_ID, Brand_CMR_ID);

                return Ok(dealInfo);
            }
            catch (Exception ex)
            {
                 _logger.LogError(ex, message:"Exception Occurred.");
                return new BadRequestObjectResult(new { message = ex.Message, currentDate = DateTime.Now });
            } 
        }

        [Authorize]
        [HttpPost("AskQuestion")]
        public IActionResult AskQuestion([FromBody] AskQuestion question)
        {
            try
            {
                string questionString = question.ToString();
                _logger.LogInformation($"AskQuestion Call with question {questionString}");

                if (string.IsNullOrEmpty(question.CMR_ID))
                {
                    throw new Exception(message:"CMR_ID is missing.");
                }
                else if (string.IsNullOrEmpty(question.RMR_ID))
                {
                    throw new Exception(message:"RMR_ID is missing.");
                }
                else if (string.IsNullOrEmpty(question.ContactInformation))
                {
                    throw new Exception(message:"ContactInformation is missing.");
                }
                else if (string.IsNullOrEmpty(question.RequestType))
                {
                    throw new Exception(message:"RequestType is missing.");
                }
                else if (!rubiDataConnect.IsValid_CMR_ID(question.CMR_ID))
                {
                    throw new Exception(message:"Invalid CMR_ID.");
                }
                else if (!rubiDataConnect.IsValid_RMR_ID(question.RMR_ID))
                {
                    throw new Exception(message:"Invalid RMR_ID.");
                }

                AskQuestion AskQuestionResponse = _dealService.AskQuestion(question);

                return Ok(AskQuestionResponse);
            }
            catch (Exception ex)
            {
                 _logger.LogError(ex, message:"Exception Occurred.");
                return new BadRequestObjectResult(new { message = ex.Message, currentDate = DateTime.Now });
            } 
        }
    }
}