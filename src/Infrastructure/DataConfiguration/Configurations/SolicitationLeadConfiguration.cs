using Infrastructure.Repository.Leads.Commands;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataConfiguration.Configurations;

public class SolicitationLeadConfiguration : IEntityTypeConfiguration<SolicitationLead>
{
    public void Configure(EntityTypeBuilder<SolicitationLead> builder)
    {
        builder.HasKey(s => s.Id);

        builder.HasOne(s => s.Owner)
            .WithOne()
            .HasForeignKey<Owner>(o => o.Id);

        builder.HasOne(s => s.OpportuniteLead)
           .WithOne()
           .HasForeignKey<OpportuniteLead>(o => o.Id)
           .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(s => s.Vehicle)
           .WithOne()
           .HasForeignKey<Vehicle>(v => v.Id);

        builder.HasOne(s => s.Address)
           .WithOne()
           .HasForeignKey<Address>(a => a.Id);

        builder.HasOne(s => s.PrimaryDriver)
           .WithOne()
           .HasForeignKey<DriverPs>(p => p.Id);

        builder.HasOne(s => s.Transmission)
               .WithOne()
               .HasForeignKey<Transmission>(t => t.Id);

        builder.HasOne(s => s.Comment)
               .WithOne()
               .HasForeignKey<Comment>(c => c.Id);
    }
}
