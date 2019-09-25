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
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(b => b.Surname)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(b => b.NickName)
                .HasMaxLength(20);

            builder.Property(b => b.Email)
                .IsRequired();

            builder.Property(b => b.Job)
                .HasMaxLength(200);

            builder.Property(b => b.Role)
                .IsRequired();

            builder.Property(b => b.Rating)
                .HasDefaultValue(0);

           

        }
    }
}
