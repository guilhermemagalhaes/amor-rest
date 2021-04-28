using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amor.Application.InputModels;
using Amor.Application.Services;
using Amor.Application.ViewModels;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Amor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("[action]")]
        [ActionName("SignUp")]
        public async Task<IActionResult> SignUp([FromBody]SignUpInputModel signUpInputModel)
        {
            var retorno =  await _userService.SignUp(signUpInputModel);
            return Ok(retorno);            
        }

        [HttpPost]
        [Route("[action]")]
        [ActionName("SignIn")]
        public async Task<IActionResult> SignIn([FromBody]SignInInputModel signInInputModel)
        {
            var retorno = await _userService.SignIn(signInInputModel);

            if (retorno == null)
                return NotFound();

            return Ok(retorno);
        }
    }
}
