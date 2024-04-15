using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FullName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_MyPlanes_PlaneFK",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyPlanes",
                table: "MyPlanes");

            migrationBuilder.RenameTable(
                name: "MyPlanes",
                newName: "Myplanes");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Passengers",
                newName: "FullName_LastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Passengers",
                newName: "FullName_FirstName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Myplanes",
                table: "Myplanes",
                column: "PlaneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Myplanes_PlaneFK",
                table: "Flights",
                column: "PlaneFK",
                principalTable: "Myplanes",
                principalColumn: "PlaneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Myplanes_PlaneFK",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Myplanes",
                table: "Myplanes");

            migrationBuilder.RenameTable(
                name: "Myplanes",
                newName: "MyPlanes");

            migrationBuilder.RenameColumn(
                name: "FullName_LastName",
                table: "Passengers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "FullName_FirstName",
                table: "Passengers",
                newName: "FirstName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyPlanes",
                table: "MyPlanes",
                column: "PlaneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_MyPlanes_PlaneFK",
                table: "Flights",
                column: "PlaneFK",
                principalTable: "MyPlanes",
                principalColumn: "PlaneId");
        }
    }
}
