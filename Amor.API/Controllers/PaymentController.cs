using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Amor.Application.InputModels;
using Amor.Application.Services;
using Amor.Application.ViewModels;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Amor.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class PaymentController : BaseController
    {
        private readonly IPaymentService _paymentService;
        private readonly IConfiguration _configuration;
        public PaymentController(IPaymentService paymentService, IConfiguration configuration)
        {
            _paymentService = paymentService;
            _configuration = configuration;
        }
       
        [HttpPost]        
        public async Task<IActionResult> Post([FromBody]PaymentInputModel paymentInputModel)
        {
            bool ret;
            var personId = GetPersonId();

            if (!personId.HasValue)
                return NotFound();

            paymentInputModel.PersonId = (int)personId;
            
            ret = await _paymentService.Add(paymentInputModel);                            

            return Ok(new { Ok = ret });
        }
    }
}
