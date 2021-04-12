using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTest.CoreDomain.TicketUser.Entitie;
using ProjectTest.CoreDomain.TicketUser.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTest.Infrastracture.TicketConfig
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.Property(c => c.Title).HasMaxLength(20).HasConversion(c => c.Value, d => Title.FromString(d));
            builder.Property(c => c.Description).HasMaxLength(1000);

        }
    }
    public class TicketUserConfiguration : IEntityTypeConfiguration<UserTicket>
    {
        public void Configure(EntityTypeBuilder<UserTicket> builder)
        {
            builder.Property(c => c.ReadStatus).HasConversion<string>();

        }
    }
}
