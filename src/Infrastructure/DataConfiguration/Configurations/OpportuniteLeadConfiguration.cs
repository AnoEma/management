using Infrastructure.Repository.Leads.Commands;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataConfiguration.Configurations;

public class OpportuniteLeadConfiguration : IEntityTypeConfiguration<OpportuniteLead>
{
    public void Configure(EntityTypeBuilder<OpportuniteLead> builder)
    {
        builder.HasKey(c => c.Id);
    }
}
