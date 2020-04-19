using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactInformationService.Migrations
{
    public partial class initialSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contact",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PhoneNumber", "Status" },
                values: new object[] { 1, "mary.t@test.com", "Mary", "Thomas", "9826098260", true });

            migrationBuilder.InsertData(
                table: "Contact",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PhoneNumber", "Status" },
                values: new object[] { 2, "john.k@test.com", "John", "Kindom", "9826098260", true });

            migrationBuilder.InsertData(
                table: "Contact",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PhoneNumber", "Status" },
                values: new object[] { 3, "sam.w@test.com", "Sam", "Willier", "9826098260", true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contact",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contact",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Contact",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
