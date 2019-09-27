using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Configs
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .IsRequired();

            builder.Property(b => b.Password)
                .IsRequired();

            builder.Property(b => b.Surname)
                .IsRequired();

            builder.Property(b => b.NickName);

            builder.Property(b => b.Email)
                .IsRequired();

            builder.Property(b => b.Job);

            builder.Property(b => b.Role)
                .IsRequired();

            builder.Property(b => b.Rating)
                .HasDefaultValue(0);

           

        }
    }
}
