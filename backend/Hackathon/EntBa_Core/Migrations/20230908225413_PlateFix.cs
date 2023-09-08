using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntBa_Core.Migrations
{
    /// <inheritdoc />
    public partial class PlateFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LicensePlate",
                table: "EntrancePermissions");

            migrationBuilder.AddColumn<int>(
                name: "LicensePlateId",
                table: "EntrancePermissions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EntrancePermissions_LicensePlateId",
                table: "EntrancePermissions",
                column: "LicensePlateId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntrancePermissions_LicensePlates_LicensePlateId",
                table: "EntrancePermissions",
                column: "LicensePlateId",
                principalTable: "LicensePlates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntrancePermissions_LicensePlates_LicensePlateId",
                table: "EntrancePermissions");

            migrationBuilder.DropIndex(
                name: "IX_EntrancePermissions_LicensePlateId",
                table: "EntrancePermissions");

            migrationBuilder.DropColumn(
                name: "LicensePlateId",
                table: "EntrancePermissions");

            migrationBuilder.AddColumn<string>(
                name: "LicensePlate",
                table: "EntrancePermissions",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
