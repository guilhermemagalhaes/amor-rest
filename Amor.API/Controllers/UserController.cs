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
    [Authorize]
    [Route("[controller]")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;        
        public UserController(IUserService userService)
        {
            _userService = userService;            
        }

        [HttpGet]                
        public async Task<IActionResult> Get()
        {
            var personId = GetPersonId();

            if (personId == null)
                return NotFound();

            var retorno = await _userService.GetUserByPersonId((int)personId);
            return Ok(retorno);
        }        
    }
}
