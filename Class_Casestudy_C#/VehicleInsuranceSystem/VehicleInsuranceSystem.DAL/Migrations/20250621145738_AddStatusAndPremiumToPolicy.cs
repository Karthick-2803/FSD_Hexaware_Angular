using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleInsuranceSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusAndPremiumToPolicy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PremiumAmount",
                table: "Policies",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Policies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PremiumAmount",
                table: "Policies");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Policies");
        }
    }
}
