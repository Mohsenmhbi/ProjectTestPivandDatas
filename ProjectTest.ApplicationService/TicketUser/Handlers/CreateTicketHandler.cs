using MediatR;
using ProjectTest.ApplicationService.TicketUser.Commands;
using ProjectTest.CoreDomain.TicketUser.Data;
using ProjectTest.CoreDomain.TicketUser.Entitie;
using ProjectTest.CoreDomain.TicketUser.ValueObjects;
using ProjectTest.CoreDomain.UserProfile.Data;
using ProjectTest.FrameWork.Data;
using ProjectTest.Rabbit.Bus;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectTest.ApplicationService.TicketUser.Handlers
{
    public class CreateTicketHandler : IRequestHandler<CreateTicket,bool>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventBus _eventBus;
        public CreateTicketHandler(ITicketRepository ticketRepository,
            IUserProfileRepository userProfileRepository,
            IUnitOfWork unitOfWork, IEventBus eventBus)
        {
            _ticketRepository = ticketRepository;
            _userProfileRepository = userProfileRepository;
            _unitOfWork = unitOfWork;
            _eventBus = eventBus;
        }

        

        public async Task<bool> Handle(CreateTicket request, CancellationToken cancellationToken)
        {
       
            Ticket tickets = new Ticket(
            Title.FromString(request.Title),
             request.Description,
             request.UserSenderId,
             request.UserResiveId
             );

            
            _ticketRepository.Add(tickets);
            int result = _unitOfWork.Commit();

            foreach (var @event in tickets.GetEvents())
            {
                await _eventBus.Publish(@event);
            }
            return true;
        }
    }
}
