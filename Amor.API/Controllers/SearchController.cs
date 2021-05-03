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
    public class SearchController : BaseController
    {
        private readonly IOngService _ongService;
        private readonly IEventService _eventService;
        public SearchController(IOngService ongService, IEventService eventService)
        {
            _ongService = ongService;
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string name)
        {
            if (string.IsNullOrEmpty(name))
                return NotFound();

            List<SearchByNameViewModel> ret = new List<SearchByNameViewModel>();

            var ongs = await _ongService.GetByName(name);
            var events = await _eventService.GetByName(name);

            if(ongs != null)
                ret.AddRange(ongs);

            if (events != null)
                ret.AddRange(events);

            return Ok(ret);
        }        
    }
}
