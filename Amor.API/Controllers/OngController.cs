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
using Amor.Core.Entities;
using Amor.Core.Interfaces;
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
    public class OngController : BaseController
    {
        private readonly IOngService _ongService;                
        public OngController(IOngService ongService)
        {
            _ongService = ongService;            
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var personId = GetPersonId();

            if (!personId.HasValue)
                return BadRequest();

            var response = await _ongService.GetByPersonId((int)personId);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]OngInputModel ongInputModel)
        {
            bool ret = false;

            var personId = GetPersonId();

            if (!personId.HasValue)
                return BadRequest();

            ongInputModel.personId = (int)personId;

            ret = await _ongService.Update(ongInputModel);
            
            return Ok(new { Ok = ret });
        }
    }
}
