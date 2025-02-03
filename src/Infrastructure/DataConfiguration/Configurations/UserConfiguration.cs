using Infrastructure.Repository.Users.Commands;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataConfiguration.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<UserManagement>
{
    public void Configure(EntityTypeBuilder<UserManagement> builder)
    {
        builder.HasKey(c => c.Id);
    }
}
