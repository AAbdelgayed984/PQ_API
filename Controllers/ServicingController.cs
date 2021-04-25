using PQ_API.Classes;
using PQ_API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

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
            //
            //if (item == null)
            //{
            //    var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            //    {
            //        Content = new StringContent(string.Format("No product with ID = {0}", id)),
            //        ReasonPhrase = "Product ID Not Found"
            //    };
            //    throw new HttpResponseException(resp);
            //}
            //

            SubmitDealResponse SubmitDealResponse = _SubmitDealService.SubmitDeal(submitDealRequest);

            return Ok(SubmitDealResponse);
        }
    }
}