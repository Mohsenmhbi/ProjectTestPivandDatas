using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectTest.CoreDomain.TicketUser.Data;
using ProjectTest.CoreDomain.TicketUser.Dtoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.EndPoint.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketQueryController : ControllerBase
    {
        private readonly ITicketQueryService  _ticketQueryService;

        public TicketQueryController(ITicketQueryService ticketQueryService)
        {
            _ticketQueryService = ticketQueryService;
        }

       

        [HttpGet("GetTicketForAdmin", Name = nameof(GetTicketForAdmin))]
        public async Task<List<GetTicketForAdminUserQuery>> GetTicketForAdmin()
        {

            var result = await _ticketQueryService.GetTicketForAdminUsers();
            return result;
        }
        [HttpGet("GetTicketForUser", Name = nameof(GetTicketForUser))]
        public async Task<List<GetTicketForUserQuery>> GetTicketForUser()
        {
           
              var result=  await _ticketQueryService.GetTicketForUser();
            return result;
        }

    }
}
