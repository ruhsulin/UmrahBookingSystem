using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UmrahBookingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UBS74_AddServiceNameUniqueIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Services_ServiceName",
                table: "Services",
                column: "ServiceName",
                unique: true,
                filter: "[IsDeleted] = 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Services_ServiceName",
                table: "Services");
        }
    }
}
