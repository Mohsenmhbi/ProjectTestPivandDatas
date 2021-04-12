using ProjectTest.CoreDomain.TicketUser.Events;
using ProjectTest.FrameWork.Entieis;
using ProjectTest.FrameWork.Enum;
using ProjectTest.FrameWork.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTest.CoreDomain.TicketUser.Entitie
{
    public class UserTicket: BaseEntity<int>
    {
        public int SenderUser { get;private set; }
        public int ReciveUser { get; private set; }
     
        public ChateStatus  ReadStatus { get; private set; }
        public DateTime CreateDate { get; private set; }
    

        #region Constructors
        private UserTicket()
        {

        }
        public UserTicket(Action<IEvent> applier) : base(applier)
        {
        }
        #endregion

        protected override void SetStateByEvent(IEvent @event)
        {
            switch (@event)
            {
                case UserTicketCreated e:

                    SenderUser = e.UserSenderId;
                    ReciveUser = e.UserResiveId;
                    CreateDate = e.CeateDate;
                    break;
            }
        }

       
    }
}
