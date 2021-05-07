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
    public class EventController : BaseController
    {
        private readonly IEventService _eventService;
        private readonly IConfiguration _configuration;
        public EventController(IEventService eventService, IConfiguration configuration)
        {
            _eventService = eventService;
            _configuration = configuration;
        }

        [HttpGet]
        [ProducesResponseType(typeof(EventViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _eventService.Get(id);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpPut]        
        public async Task<IActionResult> Put([FromBody]EventInputModel eventInputModel)
        {
            bool ret;

            var personId = GetPersonId();

            if (!personId.HasValue)
                return NotFound();

            eventInputModel.personIdCadastro = (int)personId;

            if (eventInputModel.Id > 0)
                ret = await _eventService.Update(eventInputModel);
            else
                ret = await _eventService.Add(eventInputModel);

            return Ok(new { Ok = ret });
        }
    }
}
