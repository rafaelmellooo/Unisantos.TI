using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unisantos.TI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnRatingTableCompanies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Rating",
                table: "Companies",
                type: "real",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Companies");
        }
    }
}
