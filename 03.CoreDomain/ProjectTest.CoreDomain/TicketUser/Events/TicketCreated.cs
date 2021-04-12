using ProjectTest.FrameWork.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTest.CoreDomain.TicketUser.Events
{
    public class TicketCreated:IEvent
    {
        public string Title { get;  set; }
        public string Description { get;  set; }
      
    }
}
