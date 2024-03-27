using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCarRentalApi.DAL.Migrations
{
    /// <inheritdoc />
    public partial class drivindlicense : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DrivingLisence",
                table: "Customers",
                newName: "DrivingLicense");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DrivingLicense",
                table: "Customers",
                newName: "DrivingLisence");
        }
    }
}
