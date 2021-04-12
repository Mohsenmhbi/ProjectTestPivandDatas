using ProjectTest.CoreDomain.TicketUser.Entitie;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTest.CoreDomain.TicketUser.Data
{
    public interface ITicketRepository
    {
        Ticket Load(int id);
        void Add(Ticket entity);
        bool Exists(int id);
        
    }
}
