using ProjectTest.CoreDomain.TicketUser.Events;
using ProjectTest.CoreDomain.TicketUser.ValueObjects;
using ProjectTest.FrameWork.Entieis;
using ProjectTest.FrameWork.Events;
using ProjectTest.FrameWork.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTest.CoreDomain.TicketUser.Entitie
{
    public class Ticket: BaseAggregateRoot<int>
    {
        public Title Title { get;private set; }
        public string Description { get;private set; }
        public IList<UserTicket> Chates { get; private set; }
      

        #region Costructurs
        private Ticket() { }

        public Ticket(
                          Title  title,
                          string description,
                          int userSenderId,
                          int userResiveId
                        )
        {


            HandleEvent(new TicketCreated
            {
                Title = title,
                Description = description,
            });

            Chates = new List<UserTicket>();
            var newChate = new UserTicket(HandleEvent);

            newChate.HandleEvent(new UserTicketCreated
            {
                UserSenderId = userSenderId,
                UserResiveId = userResiveId,
                CeateDate = DateTime.Now
              
            }) ;
            Chates.Add(newChate);
         
          
        }
        #endregion

        protected override void SetStateByEvent(IEvent @event)
        {
            switch (@event)
            {
               

                case TicketCreated e:
                    Title = Title.FromString(e.Title);
                    Description = e.Description;
                    break;

                default:
                    break;
            }
        }

        protected override void ValidateInvariants()
        {
            var isValid = Title != null;
                  
                  


            if (!isValid)
            {
                throw new InvalidEntityStateException(this, $"ticket Invalid");
            }
        }
    }
}
