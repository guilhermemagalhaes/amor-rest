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
    public class HomelessController : BaseController
    {
        private readonly IHomelessService _homelessService;        
        public HomelessController(IHomelessService homelessService)
        {
            _homelessService = homelessService;            
        }

        [HttpGet]
        [ProducesResponseType(typeof(HomelessViewModel), (int)HttpStatusCode.OK)]
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
            bool ret;

            var personId = GetPersonId();

            if (!personId.HasValue)
                return NotFound();

            homelessInputModel.personIdCadastro = (int)personId;
            
            if (homelessInputModel.Id > 0)
                ret = await _homelessService.Update(homelessInputModel);
            else
                ret = await _homelessService.Add(homelessInputModel);

            return Ok(new { Ok = ret });
        }
    }
}
