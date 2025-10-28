using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mysql_100_init_fitness : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBadges_Badges_BadgeId",
                table: "UserBadges");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBadges_Users_UserId",
                table: "UserBadges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBadges",
                table: "UserBadges");

            migrationBuilder.RenameTable(
                name: "UserBadges",
                newName: "UserBadge");

            migrationBuilder.RenameIndex(
                name: "IX_UserBadges_BadgeId",
                table: "UserBadge",
                newName: "IX_UserBadge_BadgeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBadge",
                table: "UserBadge",
                columns: new[] { "UserId", "BadgeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserBadge_Badges_BadgeId",
                table: "UserBadge",
                column: "BadgeId",
                principalTable: "Badges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBadge_Users_UserId",
                table: "UserBadge",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBadge_Badges_BadgeId",
                table: "UserBadge");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBadge_Users_UserId",
                table: "UserBadge");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBadge",
                table: "UserBadge");

            migrationBuilder.RenameTable(
                name: "UserBadge",
                newName: "UserBadges");

            migrationBuilder.RenameIndex(
                name: "IX_UserBadge_BadgeId",
                table: "UserBadges",
                newName: "IX_UserBadges_BadgeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBadges",
                table: "UserBadges",
                columns: new[] { "UserId", "BadgeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserBadges_Badges_BadgeId",
                table: "UserBadges",
                column: "BadgeId",
                principalTable: "Badges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBadges_Users_UserId",
                table: "UserBadges",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
