﻿// <auto-generated />
using System;
using Infrastructure.DataConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(InfrastructureDbContext))]
    partial class InfrastructureDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Infrastructure.Repository.Leads.Commands.AccountPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("AccountPayment");
                });

            modelBuilder.Entity("Infrastructure.Repository.Leads.Commands.Address", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Neighborhood")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Infrastructure.Repository.Leads.Commands.Comment", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Infrastructure.Repository.Leads.Commands.CreditPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("CreditPayment");
                });

            modelBuilder.Entity("Infrastructure.Repository.Leads.Commands.Driver17To25", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Exists17To25")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Driver17To25s");
                });

            modelBuilder.Entity("Infrastructure.Repository.Leads.Commands.DriverPs", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("BirthDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Driver17To25Id")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LivesWithInsured")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaritalStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RelationshipToInsured")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Driver17To25Id");

                    b.ToTable("DriverPs");
                });

            modelBuilder.Entity("Infrastructure.Repository.Leads.Commands.Insured", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BirthDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaritalStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneAreaCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RelationshipToOwner")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Insureds");
                });

            modelBuilder.Entity("Infrastructure.Repository.Leads.Commands.OpportuniteLead", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CanceledDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("InsuredId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("IssueDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("SaleDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartLead")
                        .HasColumnType("datetime2");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Type")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("InsuredId");

                    b.ToTable("OpportuniteLeads");
                });

            modelBuilder.Entity("Infrastructure.Repository.Leads.Commands.Owner", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("BirthDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaritalStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Owner");
                });

            modelBuilder.Entity("Infrastructure.Repository.Leads.Commands.PaymentData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AccountPaymentId")
                        .HasColumnType("int");

                    b.Property<int?>("CreditPaymentId")
                        .HasColumnType("int");

                    b.Property<int>("PaymentType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountPaymentId");

                    b.HasIndex("CreditPaymentId");

                    b.ToTable("PaymentData");
                });

            modelBuilder.Entity("Infrastructure.Repository.Leads.Commands.SolicitationLead", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("GuidSolicitation")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("QuotationId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuotationToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("SolicitationLeads");
                });

            modelBuilder.Entity("Infrastructure.Repository.Leads.Commands.Transmission", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FinalValidityDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InitialValidityDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Insurer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InsurerId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Transmissions");
                });

            modelBuilder.Entity("Infrastructure.Repository.Leads.Commands.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CirculationZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsNew")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModelYear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OvernightLocation")
                        .HasColumnType("int");

                    b.Property<string>("OvernightZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Plate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResidentialGarage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResidentialZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Usage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VehicleDetailsId")
                        .HasColumnType("int");

                    b.Property<string>("WorkGarage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("VehicleDetailsId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("Infrastructure.Repository.Leads.Commands.VehicleDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModelYear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Plate")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VehicleDetails");
                });

            modelBuilder.Entity("Infrastructure.Repository.Leads.Commands.VehicleUsageProfile", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("Usage")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("VehicleUsageProfiles");
                });

            modelBuilder.Entity("Infrastructure.Repository.Users.Commands.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessLevel")
                        .HasColumnType("int");

                    b.Property<DateTime>("AdmissionDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateDismissal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteIn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamName")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Infrastructure.Repository.Leads.Commands.Address", b =>
                {
                    b.HasOne("Infrastructure.Repository.Leads.Commands.SolicitationLead", null)
                        .WithOne("Address")
                        .HasForeignKey("Infrastructure.Repository.Leads.Commands.Address", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Infrastructure.Repository.Leads.Commands.Comment", b =>
                {
                    b.HasOne("Infrastructure.Repository.Leads.Commands.SolicitationLead", null)
                        .WithOne("Comment")
                        .HasForeignKey("Infrastructure.Repository.Leads.Commands.Comment", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Infrastructure.Repository.Leads.Commands.DriverPs", b =>
                {
                    b.HasOne("Infrastructure.Repository.Leads.Commands.Driver17To25", "Driver17To25")
                        .WithMany()
                        .HasForeignKey("Driver17To25Id");

                    b.HasOne("Infrastructure.Repository.Leads.Commands.SolicitationLead", null)
                        .WithOne("PrimaryDriver")
                        .HasForeignKey("Infrastructure.Repository.Leads.Commands.DriverPs", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver17To25");
                });

            modelBuilder.Entity("Infrastructure.Repository.Leads.Commands.OpportuniteLead", b =>
                {
                    b.HasOne("Infrastructure.Repository.Leads.Commands.SolicitationLead", null)
                        .WithOne("OpportuniteLead")
                        .HasForeignKey("Infrastructure.Repository.Leads.Commands.OpportuniteLead", "Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Infrastructure.Repository.Leads.Commands.Insured", "Insured")
                        .WithMany()
                        .HasForeignKey("InsuredId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Insured");
                });

            modelBuilder.Entity("Infrastructure.Repository.Leads.Commands.Owner", b =>
                {
                    b.HasOne("Infrastructure.Repository.Leads.Commands.SolicitationLead", null)
                        .WithOne("Owner")
                        .HasForeignKey("Infrastructure.Repository.Leads.Commands.Owner", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Infrastructure.Repository.Leads.Commands.PaymentData", b =>
                {
                    b.HasOne("Infrastructure.Repository.Leads.Commands.AccountPayment", "AccountPayment")
                        .WithMany()
                        .HasForeignKey("AccountPaymentId");

                    b.HasOne("Infrastructure.Repository.Leads.Commands.CreditPayment", "CreditPayment")
                        .WithMany()
                        .HasForeignKey("CreditPaymentId");

                    b.Navigation("AccountPayment");

                    b.Navigation("CreditPayment");
                });

            modelBuilder.Entity("Infrastructure.Repository.Leads.Commands.Transmission", b =>
                {
                    b.HasOne("Infrastructure.Repository.Leads.Commands.SolicitationLead", null)
                        .WithOne("Transmission")
                        .HasForeignKey("Infrastructure.Repository.Leads.Commands.Transmission", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Infrastructure.Repository.Leads.Commands.Vehicle", b =>
                {
                    b.HasOne("Infrastructure.Repository.Leads.Commands.SolicitationLead", null)
                        .WithOne("Vehicle")
                        .HasForeignKey("Infrastructure.Repository.Leads.Commands.Vehicle", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Repository.Leads.Commands.VehicleDetails", "VehicleDetails")
                        .WithMany()
                        .HasForeignKey("VehicleDetailsId");

                    b.Navigation("VehicleDetails");
                });

            modelBuilder.Entity("Infrastructure.Repository.Leads.Commands.VehicleUsageProfile", b =>
                {
                    b.HasOne("Infrastructure.Repository.Leads.Commands.Vehicle", null)
                        .WithOne("UsageProfile")
                        .HasForeignKey("Infrastructure.Repository.Leads.Commands.VehicleUsageProfile", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Infrastructure.Repository.Leads.Commands.SolicitationLead", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("Comment");

                    b.Navigation("OpportuniteLead");

                    b.Navigation("Owner");

                    b.Navigation("PrimaryDriver");

                    b.Navigation("Transmission");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Infrastructure.Repository.Leads.Commands.Vehicle", b =>
                {
                    b.Navigation("UsageProfile");
                });
#pragma warning restore 612, 618
        }
    }
}
