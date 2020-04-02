using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAssistant.Extensions;
using LibraryAssistant.Resources.Request;
using LibraryAssistant.Services.CheckoutService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAssistant.Controllers
{
    [Route("api")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CheckOutController : ControllerBase
    {

        private readonly ICheckoutService _checkoutService;
        public CheckOutController(ICheckoutService checkoutService)
        {
            _checkoutService = checkoutService;
        }

        [HttpPost]
        [Route("checkout")]
        public async Task<IActionResult> CheckoutAsync(CheckoutRequest checkoutRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());

            }
             var UserId = HttpContext.GetUserId();

            var result = await _checkoutService.CheckoutBooksAsync(checkoutRequest, UserId);          
            return Ok(result);
        }
    }
}