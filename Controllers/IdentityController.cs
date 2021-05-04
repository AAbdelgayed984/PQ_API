using PQ_API.Classes;
using PQ_API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace PQ_API.Controllers
{
    /// <summary>
    /// This service will be used to generate a JWT Token for subsequent call.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private IUserService _userService;
        private readonly ILogger<IdentityController> _logger;
        public IdentityController(ILogger<IdentityController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            try
            {
                _logger.LogInformation($"Authenticate Call with model.Username {model.Username}, model.Password {model.Password}");
                var response = _userService.Authenticate(model);

                if (response == null)
                {
                    throw new Exception(message:"Username or password is incorrect.");
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                 _logger.LogError(ex, message:"Exception Occurred.");
                return new StatusCodeResult(500);
            }           
        }
    }
}
