using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Configs
{
    public class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.PostId)
                .IsRequired();

            builder.Property(b => b.PostNum)
                .IsRequired();

            builder.Property(b => b.UpVotes)
                .IsRequired();

            builder.Property(b => b.DownVotes)
                .IsRequired();

            builder.Property(b => b.Text)
                .IsRequired();

            builder.Property(b => b.Viewed)
                .IsRequired();

            builder.Property(b => b.DateOfPublish)
                .IsRequired();

            builder.HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId);

        }
    }
}
