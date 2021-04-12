using MediatR;
using ProjectTest.ApplicationService.UserProfiles.Commands;
using ProjectTest.CoreDomain.UserProfile.Data;
using ProjectTest.CoreDomain.UserProfile.Entitie;
using ProjectTest.CoreDomain.UserProfile.ValueObjects;
using ProjectTest.FrameWork.Data;
using ProjectTest.Rabbit.Bus;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectTest.ApplicationService.UserProfiles.Handlers
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserProfile, bool>
    {
     
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventBus _eventBus;

        public RegisterUserHandler(IUserProfileRepository userProfileRepository,
            IUnitOfWork unitOfWork,
            IEventBus eventBus)
        {
            _userProfileRepository = userProfileRepository;
            _unitOfWork = unitOfWork;
            _eventBus = eventBus;
        }

       
     

        public async Task<bool> Handle(RegisterUserProfile request, CancellationToken cancellationToken)
        {
            UserProfile userProfile = new UserProfile(
             FirstName.FromString(request.FirstName),
             LastName.FromString(request.LastName),
             Email.FromString(request.Email));
          
            _userProfileRepository.Add(userProfile);
            int result = _unitOfWork.Commit();
            foreach (var @event in userProfile.GetEvents())
            {
                await _eventBus.Publish(@event);
            }
            return  true;
        }
    }
}
