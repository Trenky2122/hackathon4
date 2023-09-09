using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntBa_Core.Migrations
{
    /// <inheritdoc />
    public partial class AddForgottenProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VariableSymbol",
                table: "TaxDuties",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VariableSymbol",
                table: "TaxDuties");
        }
    }
}
