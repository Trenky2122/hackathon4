using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EntBa_Core.Migrations
{
    /// <inheritdoc />
    public partial class FinesFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Entrance",
                table: "Entrances");

            migrationBuilder.RenameColumn(
                name: "Exit",
                table: "Entrances",
                newName: "EntranceCameraFront");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "EntranceCameraBack",
                table: "Entrances",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ExitCameraBack",
                table: "Entrances",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ExitCameraFront",
                table: "Entrances",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PermissionId",
                table: "Entrances",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsYearly",
                table: "EntranceRequests",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Fines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    DueDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fines_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entrances_PermissionId",
                table: "Entrances",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Fines_UserId",
                table: "Fines",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrances_EntrancePermissions_PermissionId",
                table: "Entrances",
                column: "PermissionId",
                principalTable: "EntrancePermissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrances_EntrancePermissions_PermissionId",
                table: "Entrances");

            migrationBuilder.DropTable(
                name: "Fines");

            migrationBuilder.DropIndex(
                name: "IX_Entrances_PermissionId",
                table: "Entrances");

            migrationBuilder.DropColumn(
                name: "EntranceCameraBack",
                table: "Entrances");

            migrationBuilder.DropColumn(
                name: "ExitCameraBack",
                table: "Entrances");

            migrationBuilder.DropColumn(
                name: "ExitCameraFront",
                table: "Entrances");

            migrationBuilder.DropColumn(
                name: "PermissionId",
                table: "Entrances");

            migrationBuilder.DropColumn(
                name: "IsYearly",
                table: "EntranceRequests");

            migrationBuilder.RenameColumn(
                name: "EntranceCameraFront",
                table: "Entrances",
                newName: "Exit");

            migrationBuilder.AddColumn<DateTime>(
                name: "Entrance",
                table: "Entrances",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
