using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTest.ApplicationService.TicketUser.Commands
{
    public class CreateTicket:IRequest<bool>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserSenderId { get; set; }
        public int UserResiveId { get; set; }

    }
}
