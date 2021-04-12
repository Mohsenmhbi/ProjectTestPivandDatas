using MediatR;

namespace ProjectTest.ApplicationService.UserProfiles.Commands
{
    public class RegisterUserProfile : IRequest<bool>
    {
      
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
