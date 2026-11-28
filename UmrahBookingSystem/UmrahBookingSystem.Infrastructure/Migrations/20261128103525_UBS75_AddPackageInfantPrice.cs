using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UmrahBookingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UBS75_AddPackageInfantPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "InfantPrice",
                table: "Packages",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InfantPrice",
                table: "Packages");
        }
    }
}
