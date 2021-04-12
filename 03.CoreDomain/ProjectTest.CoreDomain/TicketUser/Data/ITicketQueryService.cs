using ProjectTest.CoreDomain.TicketUser.Dtoes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.CoreDomain.TicketUser.Data
{
    public interface ITicketQueryService
    {
       Task< List<GetTicketForAdminUserQuery>> GetTicketForAdminUsers();

        Task<List<GetTicketForUserQuery>> GetTicketForUser();
    }
}
