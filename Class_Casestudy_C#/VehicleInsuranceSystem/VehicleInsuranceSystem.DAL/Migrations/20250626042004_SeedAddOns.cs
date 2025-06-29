using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VehicleInsuranceSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedAddOns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AddOns",
                columns: new[] { "AddOnId", "Cost", "Name" },
                values: new object[,]
                {
                    { 1, 1000m, "Roadside Assistance" },
                    { 2, 1500m, "Engine Protection" },
                    { 3, 2000m, "Zero Depreciation" },
                    { 4, 800m, "Tyre Cover" },
                    { 5, 600m, "Key Replacement" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AddOns",
                keyColumn: "AddOnId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AddOns",
                keyColumn: "AddOnId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AddOns",
                keyColumn: "AddOnId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AddOns",
                keyColumn: "AddOnId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AddOns",
                keyColumn: "AddOnId",
                keyValue: 5);
        }
    }
}
