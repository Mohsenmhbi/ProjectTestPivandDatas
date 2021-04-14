using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectTest.ApplicationService.TicketUser.Commands;
using ProjectTest.ApplicationService.TicketUser.Handlers;

namespace ProjectTest.EndPoint.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TicketController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost(Name = nameof(RegisterTicket))]
        public IActionResult RegisterTicket( CreateTicket request)
        {
            _mediator.Send(request);
            return Ok();
        }
    }
}