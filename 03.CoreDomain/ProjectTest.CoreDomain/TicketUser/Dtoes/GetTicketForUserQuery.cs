using System;

namespace ProjectTest.CoreDomain.TicketUser.Dtoes
{
    public class GetTicketForUserQuery
    {
        public string Description { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime CreateDate { get; set; }
        public string ReadStatus { get; set; }
    }
}
