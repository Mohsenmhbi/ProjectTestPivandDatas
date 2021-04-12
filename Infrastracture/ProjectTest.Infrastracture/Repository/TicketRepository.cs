using ProjectTest.CoreDomain.TicketUser.Data;
using ProjectTest.CoreDomain.TicketUser.Entitie;
using ProjectTest.Infrastracture.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectTest.Infrastracture.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly TestContext _context;

        public TicketRepository(TestContext context)
        {
            _context = context;
        }
     
        public void Add(Ticket entity)
        {
            _context.Tickets.Add(entity);
        }

        public bool Exists(int id)
        {
            return _context.Tickets.Any(c => c.Id == id);
        }

        public Ticket Load(int id)
        {
            return _context.Tickets.Find(id);
        }
    }
}
