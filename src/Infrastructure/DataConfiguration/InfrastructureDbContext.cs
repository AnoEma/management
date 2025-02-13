using Infrastructure.Repository.Leads.Commands;
using Infrastructure.Repository.Users.Commands;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataConfiguration;

public class InfrastructureDbContext : IdentityDbContext<ManagementUser>
{
    public InfrastructureDbContext(DbContextOptions<InfrastructureDbContext> options) : base(options)
    {
    }

    public DbSet<SolicitationLead> SolicitationLeads { get; set; }
    public DbSet<Transmission> Transmissions { get; set; }
    public DbSet<PaymentData> PaymentData { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Owner> Owner { get; set; }
    public DbSet<Driver> Driver { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<VehicleUsageProfile> VehicleUsageProfiles { get; set; }
    public DbSet<OpportuniteLead> OpportuniteLeads { get; set; }
    public DbSet<Insured> Insureds { get; set; }
    public DbSet<UserManagement> UserManagements { get; set; }
    public DbSet<Address> Address { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(InfrastructureDbContext).Assembly);
    }
}