using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment_3_Part_1.Migrations
{
    public partial class SalesData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "SalesId", "Amount", "EmployeeId", "Quarter", "Year" },
                values: new object[] { 1, 2541260m, 1, 3, 2024 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SalesId",
                keyValue: 1);
        }
    }
}
