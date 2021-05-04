using PQ_API.Classes;
using PQ_API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Net;

namespace PQ_API.Controllers
{
    [Route("servicingapi/")]
    [ApiController]
    public class ServicingController : ControllerBase
    {
        private readonly ILogger<ServicingController> _logger;
        private ISubmitDealService _SubmitDealService;

        public ServicingController(ILogger<ServicingController> logger, ISubmitDealService dealService)
        {
            _logger = logger;
            _SubmitDealService = dealService;
        }

        [Authorize]
        [HttpPost("SubmitDeal")]
        public IActionResult SubmitDeal([FromBody] SubmitDealRequest submitDealRequest)
        {
            try
            {
                _logger.LogInformation($"SubmitDeal Call with submitDealRequest.RequestID {submitDealRequest.RequestID}");

                if (string.IsNullOrEmpty(submitDealRequest.RequestID))
                {
                    throw new Exception(message:"RequestID is missing.");
                }
                else if (submitDealRequest.PreauthorizedPaymentAccount == null)
                {
                    throw new Exception(message:"PreauthorizedPaymentAccount Object is missing.");
                }

                SubmitDealResponse SubmitDealResponse = _SubmitDealService.SubmitDeal(submitDealRequest);

                return Ok(SubmitDealResponse);
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
            Content = $"Status Code: {(int)statusCode} {statusCode}; Reason: {reason}",
            ContentType = "text/plain",
        };
    }
}