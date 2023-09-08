using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntBa_Core.Migrations
{
    /// <inheritdoc />
    public partial class Fine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaxDuties_Users_UserDboId",
                table: "TaxDuties");

            migrationBuilder.DropIndex(
                name: "IX_TaxDuties_UserDboId",
                table: "TaxDuties");

            migrationBuilder.DropColumn(
                name: "UserDboId",
                table: "TaxDuties");

            migrationBuilder.CreateIndex(
                name: "IX_TaxDuties_UserId",
                table: "TaxDuties",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaxDuties_Users_UserId",
                table: "TaxDuties",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaxDuties_Users_UserId",
                table: "TaxDuties");

            migrationBuilder.DropIndex(
                name: "IX_TaxDuties_UserId",
                table: "TaxDuties");

            migrationBuilder.AddColumn<int>(
                name: "UserDboId",
                table: "TaxDuties",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaxDuties_UserDboId",
                table: "TaxDuties",
                column: "UserDboId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaxDuties_Users_UserDboId",
                table: "TaxDuties",
                column: "UserDboId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
