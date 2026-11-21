using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UmrahBookingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UBS46_AddPhoneNumberCheck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CK_AspNetUsers_PhoneNumber_IsNull",
                table: "AspNetUsers",
                sql: "[PhoneNumber] IS NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_AspNetUsers_PhoneNumber_IsNull",
                table: "AspNetUsers");
        }
    }
}
