using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleInsuranceSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddQuoteGeneratedDateAndAddOnListToProposal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "QuoteGeneratedDate",
                table: "PolicyProposals",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SelectedAddOnsCsv",
                table: "PolicyProposals",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuoteGeneratedDate",
                table: "PolicyProposals");

            migrationBuilder.DropColumn(
                name: "SelectedAddOnsCsv",
                table: "PolicyProposals");
        }
    }
}
