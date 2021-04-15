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
        private HashSet<UserTicket> userTickets = new HashSet<UserTicket>();
        public string Description { get;private set; }
        public IReadOnlyCollection<UserTicket> Chates => userTickets;


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

  
            var newChate = new UserTicket(HandleEvent);

            newChate.HandleEvent(new  UserTicketCreated
                (userSenderId,
                 userResiveId,
                 DateTime.Now));
            userTickets.Add(newChate);
         
          
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
