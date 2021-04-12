using ProjectTest.FrameWork.Events;

namespace ProjectTest.CoreDomain.UserProfile.Events
{
    public class UserRegistered : IEvent
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
