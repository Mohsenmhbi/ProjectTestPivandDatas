using ProjectTest.FrameWork.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTest.CoreDomain.TicketUser.Events
{
    public class UserTicketCreated:IEvent
    {
        public int UserSenderId { get; set; }
        public int UserResiveId { get; set; }
        public DateTime CeateDate { get; set; }
  

    }
}
