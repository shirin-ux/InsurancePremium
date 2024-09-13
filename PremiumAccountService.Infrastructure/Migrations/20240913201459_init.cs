using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PremiumAccountService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "coverages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    PremiumRate = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    MinAmount = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    MaxAmount = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coverages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceRequestCoverages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoverageId = table.Column<int>(type: "int", nullable: false),
                    InsuranceRequestId = table.Column<int>(type: "int", nullable: false),
                    PayementAmount = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceRequestCoverages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsuranceRequestCoverages_InsuranceRequests_InsuranceRequestId",
                        column: x => x.InsuranceRequestId,
                        principalTable: "InsuranceRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InsuranceRequestCoverages_coverages_CoverageId",
                        column: x => x.CoverageId,
                        principalTable: "coverages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceRequestCoverages_CoverageId",
                table: "InsuranceRequestCoverages",
                column: "CoverageId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceRequestCoverages_InsuranceRequestId",
                table: "InsuranceRequestCoverages",
                column: "InsuranceRequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsuranceRequestCoverages");

            migrationBuilder.DropTable(
                name: "InsuranceRequests");

            migrationBuilder.DropTable(
                name: "coverages");
        }
    }
}
