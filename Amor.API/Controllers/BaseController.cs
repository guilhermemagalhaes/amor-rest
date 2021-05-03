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
    
    public class BaseController : ControllerBase
    {
        
        public BaseController()
        {
            
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public int? GetPersonId()
        {
            var value = User.FindFirst("personId").Value;

            if (value != null)
                return Convert.ToInt32(value);
            else
                return null;            
        }    
    }
}
