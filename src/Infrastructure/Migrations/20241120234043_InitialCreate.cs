using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountPayment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountPayment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditPayment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditPayment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Driver17To25s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Exists17To25 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver17To25s", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Insured",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneAreaCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelationshipToOwner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insured", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transmissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InitialValidityDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinalValidityDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Insurer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsurerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transmissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleUsageProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleUsageProfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentType = table.Column<int>(type: "int", nullable: false),
                    AccountPaymentId = table.Column<int>(type: "int", nullable: true),
                    CreditPaymentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentData_AccountPayment_AccountPaymentId",
                        column: x => x.AccountPaymentId,
                        principalTable: "AccountPayment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PaymentData_CreditPayment_CreditPaymentId",
                        column: x => x.CreditPaymentId,
                        principalTable: "CreditPayment",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DriverPs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LivesWithInsured = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelationshipToInsured = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Driver17To25Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverPs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DriverPs_Driver17To25s_Driver17To25Id",
                        column: x => x.Driver17To25Id,
                        principalTable: "Driver17To25s",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OpportuniteLeads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    Type = table.Column<byte>(type: "tinyint", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsuredId = table.Column<int>(type: "int", nullable: false),
                    SaleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpportuniteLeads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpportuniteLeads_Insured_InsuredId",
                        column: x => x.InsuredId,
                        principalTable: "Insured",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsNew = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Usage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsageProfileId = table.Column<int>(type: "int", nullable: true),
                    OvernightZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CirculationZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResidentialZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResidentialGarage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkGarage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OvernightLocation = table.Column<int>(type: "int", nullable: false),
                    VehicleDetailsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleDetails_VehicleDetailsId",
                        column: x => x.VehicleDetailsId,
                        principalTable: "VehicleDetails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleUsageProfiles_UsageProfileId",
                        column: x => x.UsageProfileId,
                        principalTable: "VehicleUsageProfiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SolicitationLeads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuidSolicitation = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: true),
                    PrimaryDriverId = table.Column<int>(type: "int", nullable: true),
                    VehicleId = table.Column<int>(type: "int", nullable: true),
                    CommentId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransmissionId = table.Column<int>(type: "int", nullable: true),
                    OpportuniteLeadId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitationLeads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolicitationLeads_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SolicitationLeads_DriverPs_PrimaryDriverId",
                        column: x => x.PrimaryDriverId,
                        principalTable: "DriverPs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SolicitationLeads_OpportuniteLeads_OpportuniteLeadId",
                        column: x => x.OpportuniteLeadId,
                        principalTable: "OpportuniteLeads",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SolicitationLeads_Owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owner",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SolicitationLeads_Transmissions_TransmissionId",
                        column: x => x.TransmissionId,
                        principalTable: "Transmissions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SolicitationLeads_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DriverPs_Driver17To25Id",
                table: "DriverPs",
                column: "Driver17To25Id");

            migrationBuilder.CreateIndex(
                name: "IX_OpportuniteLeads_InsuredId",
                table: "OpportuniteLeads",
                column: "InsuredId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentData_AccountPaymentId",
                table: "PaymentData",
                column: "AccountPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentData_CreditPaymentId",
                table: "PaymentData",
                column: "CreditPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitationLeads_CommentId",
                table: "SolicitationLeads",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitationLeads_OpportuniteLeadId",
                table: "SolicitationLeads",
                column: "OpportuniteLeadId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitationLeads_OwnerId",
                table: "SolicitationLeads",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitationLeads_PrimaryDriverId",
                table: "SolicitationLeads",
                column: "PrimaryDriverId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitationLeads_TransmissionId",
                table: "SolicitationLeads",
                column: "TransmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitationLeads_VehicleId",
                table: "SolicitationLeads",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_UsageProfileId",
                table: "Vehicles",
                column: "UsageProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleDetailsId",
                table: "Vehicles",
                column: "VehicleDetailsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentData");

            migrationBuilder.DropTable(
                name: "SolicitationLeads");

            migrationBuilder.DropTable(
                name: "AccountPayment");

            migrationBuilder.DropTable(
                name: "CreditPayment");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "DriverPs");

            migrationBuilder.DropTable(
                name: "OpportuniteLeads");

            migrationBuilder.DropTable(
                name: "Owner");

            migrationBuilder.DropTable(
                name: "Transmissions");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Driver17To25s");

            migrationBuilder.DropTable(
                name: "Insured");

            migrationBuilder.DropTable(
                name: "VehicleDetails");

            migrationBuilder.DropTable(
                name: "VehicleUsageProfiles");
        }
    }
}
