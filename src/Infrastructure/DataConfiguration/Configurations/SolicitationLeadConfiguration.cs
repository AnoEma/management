using Infrastructure.Repository.Leads.Commands;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataConfiguration.Configurations;

public class SolicitationLeadConfiguration : IEntityTypeConfiguration<SolicitationLead>
{
    public void Configure(EntityTypeBuilder<SolicitationLead> builder)
    {
        builder.HasKey(c => c.Id);
    }
}
