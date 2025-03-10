using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsuranceProject.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employers",
                columns: table => new
                {
                    EmployerName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployerId = table.Column<int>(type: "int", nullable: false),
                    EmployerType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployerCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employers", x => x.EmployerName);
                });

            migrationBuilder.CreateTable(
                name: "ClaimCases",
                columns: table => new
                {
                    ClaimCaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployerName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimCases", x => x.ClaimCaseId);
                    table.ForeignKey(
                        name: "FK_ClaimCases_Employers_EmployerName",
                        column: x => x.EmployerName,
                        principalTable: "Employers",
                        principalColumn: "EmployerName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Complaints",
                columns: table => new
                {
                    ComplaintId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployerName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ComplaintDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ComplaintDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaints", x => x.ComplaintId);
                    table.ForeignKey(
                        name: "FK_Complaints_Employers_EmployerName",
                        column: x => x.EmployerName,
                        principalTable: "Employers",
                        principalColumn: "EmployerName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DebtTrackings",
                columns: table => new
                {
                    DebtId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployerName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeadlineDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebtTrackings", x => x.DebtId);
                    table.ForeignKey(
                        name: "FK_DebtTrackings_Employers_EmployerName",
                        column: x => x.EmployerName,
                        principalTable: "Employers",
                        principalColumn: "EmployerName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceLists",
                columns: table => new
                {
                    InsuranceListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployerName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ListMonth = table.Column<int>(type: "int", nullable: false),
                    ListYear = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceLists", x => x.InsuranceListId);
                    table.ForeignKey(
                        name: "FK_InsuranceLists_Employers_EmployerName",
                        column: x => x.EmployerName,
                        principalTable: "Employers",
                        principalColumn: "EmployerName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    ReceiptId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployerName = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReceiptDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReceiptType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployerName1 = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.ReceiptId);
                    table.ForeignKey(
                        name: "FK_Receipts_Employers_EmployerName1",
                        column: x => x.EmployerName1,
                        principalTable: "Employers",
                        principalColumn: "EmployerName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Installments",
                columns: table => new
                {
                    InstallmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DebtId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Installments", x => x.InstallmentId);
                    table.ForeignKey(
                        name: "FK_Installments_DebtTrackings_DebtId",
                        column: x => x.DebtId,
                        principalTable: "DebtTrackings",
                        principalColumn: "DebtId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClaimCases_EmployerName",
                table: "ClaimCases",
                column: "EmployerName");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_EmployerName",
                table: "Complaints",
                column: "EmployerName");

            migrationBuilder.CreateIndex(
                name: "IX_DebtTrackings_EmployerName",
                table: "DebtTrackings",
                column: "EmployerName");

            migrationBuilder.CreateIndex(
                name: "IX_Installments_DebtId",
                table: "Installments",
                column: "DebtId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceLists_EmployerName",
                table: "InsuranceLists",
                column: "EmployerName");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_EmployerName1",
                table: "Receipts",
                column: "EmployerName1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClaimCases");

            migrationBuilder.DropTable(
                name: "Complaints");

            migrationBuilder.DropTable(
                name: "Installments");

            migrationBuilder.DropTable(
                name: "InsuranceLists");

            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.DropTable(
                name: "DebtTrackings");

            migrationBuilder.DropTable(
                name: "Employers");
        }
    }
}
