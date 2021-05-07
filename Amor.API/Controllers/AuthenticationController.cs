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
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public AuthenticationController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("[action]")]
        [ActionName("SignUp")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(SignUpViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> SignUp([FromBody]SignUpInputModel signUpInputModel)
        {
            var retorno = await _userService.SignUp(signUpInputModel);
            return Ok(retorno);
        }

        [HttpPost]
        [Route("[action]")]
        [ActionName("SignIn")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(SignInViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> SignIn([FromBody]SignInInputModel signInInputModel)
        {
            var retorno = await _userService.SignIn(signInInputModel);

            if (retorno == null)
                return NotFound();

            return Ok(BuildToken(retorno));
        }

        private SignInViewModel BuildToken(SignInViewModel signInViewModel)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, signInViewModel.Person.Name),
                new Claim("personId", signInViewModel.Person.Id.ToString()),                
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            // tempo de expiração do token: 1 hora
            var expiration = DateTime.UtcNow.AddHours(1);
            JwtSecurityToken token = new JwtSecurityToken(
               issuer: null,
               audience: null,
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return new SignInViewModel(new JwtSecurityTokenHandler().WriteToken(token), expiration, signInViewModel.Person);
        }
    }
}
