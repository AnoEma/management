using Infrastructure.Repository.Leads.Commands;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataConfiguration;

public class InfrastructureDbContext : DbContext
{
    public InfrastructureDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<SolicitationLead> SolicitationLeads { get; set; }
    public DbSet<Transmission> Transmissions { get; set; }
    public DbSet<PaymentData> PaymentData { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Owner> Owner { get; set; }
    public DbSet<DriverP> DriverPs { get; set; }
    public DbSet<Driver17To25> Driver17To25s { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<VehicleUsageProfile> VehicleUsageProfiles { get; set; }
    public DbSet<VehicleDetails> VehicleDetails { get; set; }
    public DbSet<OpportuniteLead> OpportuniteLeads { get; set; }
    public DbSet<Insured> Insureds { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(InfrastructureDbContext).Assembly);
    }
}