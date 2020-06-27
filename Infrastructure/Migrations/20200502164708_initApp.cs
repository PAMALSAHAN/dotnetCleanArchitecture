using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class initApp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Application.common.IApplicationDbContext.Invoicestbl",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastMadifiedBy = table.Column<string>(nullable: true),
                    LastMadified = table.Column<DateTime>(nullable: true),
                    InvoiceNumber = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    From = table.Column<string>(nullable: true),
                    To = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    PaymentTerms = table.Column<string>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: false),
                    Discount = table.Column<double>(nullable: false),
                    DiscountTypes = table.Column<int>(nullable: false),
                    Tax = table.Column<double>(nullable: false),
                    TaxTypes = table.Column<int>(nullable: false),
                    AmountPaid = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application.common.IApplicationDbContext.Invoicestbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Application.common.IApplicationDbContext.InvoiceItemstbl",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastMadifiedBy = table.Column<string>(nullable: true),
                    LastMadified = table.Column<DateTime>(nullable: true),
                    InvoiceId = table.Column<int>(nullable: false),
                    Item = table.Column<string>(nullable: true),
                    Quantity = table.Column<double>(nullable: false),
                    Rate = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application.common.IApplicationDbContext.InvoiceItemstbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Application.common.IApplicationDbContext.InvoiceItemstbl_Application.common.IApplicationDbContext.Invoicestbl_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Application.common.IApplicationDbContext.Invoicestbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Application.common.IApplicationDbContext.InvoiceItemstbl_InvoiceId",
                table: "Application.common.IApplicationDbContext.InvoiceItemstbl",
                column: "InvoiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Application.common.IApplicationDbContext.InvoiceItemstbl");

            migrationBuilder.DropTable(
                name: "Application.common.IApplicationDbContext.Invoicestbl");
        }
    }
}
