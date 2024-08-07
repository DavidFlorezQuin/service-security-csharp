using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class lalalal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_Roles_roles_roleId",
                table: "user_Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_user_Roles_users_userId",
                table: "user_Roles");

            migrationBuilder.DropColumn(
                name: "IdRole",
                table: "user_Roles");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "user_Roles");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "user_Roles",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "roleId",
                table: "user_Roles",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_user_Roles_userId",
                table: "user_Roles",
                newName: "IX_user_Roles_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_user_Roles_roleId",
                table: "user_Roles",
                newName: "IX_user_Roles_RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_user_Roles_roles_RoleId",
                table: "user_Roles",
                column: "RoleId",
                principalTable: "roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_Roles_users_UserId",
                table: "user_Roles",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_Roles_roles_RoleId",
                table: "user_Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_user_Roles_users_UserId",
                table: "user_Roles");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "user_Roles",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "user_Roles",
                newName: "roleId");

            migrationBuilder.RenameIndex(
                name: "IX_user_Roles_UserId",
                table: "user_Roles",
                newName: "IX_user_Roles_userId");

            migrationBuilder.RenameIndex(
                name: "IX_user_Roles_RoleId",
                table: "user_Roles",
                newName: "IX_user_Roles_roleId");

            migrationBuilder.AddColumn<int>(
                name: "IdRole",
                table: "user_Roles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "user_Roles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_user_Roles_roles_roleId",
                table: "user_Roles",
                column: "roleId",
                principalTable: "roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_Roles_users_userId",
                table: "user_Roles",
                column: "userId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
