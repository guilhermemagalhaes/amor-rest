using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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
    //[Authorize]
    [Route("[controller]")]
    public class HomelessController : ControllerBase
    {
        private readonly IHomelessService _homelessService;
        private readonly IConfiguration _configuration;
        public HomelessController(IHomelessService homelessService, IConfiguration configuration)
        {
            _homelessService = homelessService;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _homelessService.Get(id);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]HomelessInputModel homelessInputModel)
        {
            bool ret = false;

            if (homelessInputModel.Id > 0)
                ret = await _homelessService.Update(homelessInputModel);
            else
                ret = await _homelessService.Add(homelessInputModel);

            return Ok(new { Ok = ret });
        }
    }
}
