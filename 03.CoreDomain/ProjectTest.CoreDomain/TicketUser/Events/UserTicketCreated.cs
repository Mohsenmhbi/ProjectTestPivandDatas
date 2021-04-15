using ProjectTest.FrameWork.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTest.CoreDomain.TicketUser.Events
{
    public class UserTicketCreated:IEvent
    {
        public UserTicketCreated(int userSenderId, int userResiveId, DateTime ceateDate)
        {
            UserSenderId = userSenderId;
            UserResiveId = userResiveId;
            CeateDate = ceateDate;
        }

        public int UserSenderId { get;  }
        public int UserResiveId { get; }
        public DateTime CeateDate { get; }
  

    }
}
