using ProjectTest.FrameWork.Events;

namespace ProjectTest.CoreDomain.UserProfile.Events
{
    public class UserRegistered : IEvent
    {
        public UserRegistered(string email, string firstName, string lastName)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }

        public string Email { get;  }
        public string FirstName { get; }
        public string LastName { get;}
    }
}
