using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTest.CoreDomain.UserProfile.Entitie;
using ProjectTest.CoreDomain.UserProfile.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTest.Infrastracture.UserProfileConfig
{
    public class UserProfileConfig : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.Property(c => c.FirstName).HasMaxLength(40).HasConversion(c => c.Value, d => FirstName.FromString(d));
            builder.Property(c => c.LastName).HasMaxLength(30).HasConversion(c => c.Value, d => LastName.FromString(d));
            builder.Property(c => c.Email).HasMaxLength(50).HasConversion(c => c.Value, d => Email.FromString(d));

        }
    }
}
