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
    public class EventParticipantsController : BaseController
    {
        private readonly IEventService _eventService;
        private readonly IConfiguration _configuration;
        public EventParticipantsController(IEventService eventService, IConfiguration configuration)
        {
            _eventService = eventService;
            _configuration = configuration;
        }
       
        [HttpPost]        
        public async Task<IActionResult> Post([FromBody]EventParticipantsInputModel eventParticipants)
        {
            bool ret;
            var personId = GetPersonId();

            if (!personId.HasValue)
                return NotFound();

            eventParticipants.PersonId = (int)personId;
            
            ret = await _eventService.AddEventParticipants(eventParticipants);                            

            return Ok(new { Ok = ret });
        }
    }
}
