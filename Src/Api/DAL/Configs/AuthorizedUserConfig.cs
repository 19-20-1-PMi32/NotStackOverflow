using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configs
{
    class AuthorizedUserConfig : IEntityTypeConfiguration<AuthorizedUser>
    {
        public void Configure(EntityTypeBuilder<AuthorizedUser> builder)
        {
            builder.HasKey(b => b.Id);

            builder.HasIndex(b => b.RefreshToken).IsUnique(true);
        }
    }
}
