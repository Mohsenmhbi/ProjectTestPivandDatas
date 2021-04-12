using Microsoft.EntityFrameworkCore;
using ProjectTest.CoreDomain.TicketUser.Entitie;
using ProjectTest.CoreDomain.UserProfile.Entitie;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTest.Infrastracture.Context
{
    public class TestContext:DbContext
    {
        public TestContext(DbContextOptions<TestContext> options):base(options)
        {

        }

        public DbSet<UserProfile>  userProfiles { get; set; }
        public DbSet<Ticket>  Tickets { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProjectTest.Infrastracture.UserProfileConfig.UserProfileConfig());
            modelBuilder.ApplyConfiguration(new ProjectTest.Infrastracture.TicketConfig.TicketConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectTest.Infrastracture.TicketConfig.TicketUserConfiguration());
        }

    }
}
