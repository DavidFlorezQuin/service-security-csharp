using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class migracionultima : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_role_Views_roles_roleId",
                table: "role_Views");

            migrationBuilder.DropForeignKey(
                name: "FK_role_Views_views_viewId",
                table: "role_Views");

            migrationBuilder.RenameColumn(
                name: "viewId",
                table: "role_Views",
                newName: "ViewId");

            migrationBuilder.RenameColumn(
                name: "roleId",
                table: "role_Views",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_role_Views_viewId",
                table: "role_Views",
                newName: "IX_role_Views_ViewId");

            migrationBuilder.RenameIndex(
                name: "IX_role_Views_roleId",
                table: "role_Views",
                newName: "IX_role_Views_RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_role_Views_roles_RoleId",
                table: "role_Views",
                column: "RoleId",
                principalTable: "roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_role_Views_views_ViewId",
                table: "role_Views",
                column: "ViewId",
                principalTable: "views",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_role_Views_roles_RoleId",
                table: "role_Views");

            migrationBuilder.DropForeignKey(
                name: "FK_role_Views_views_ViewId",
                table: "role_Views");

            migrationBuilder.RenameColumn(
                name: "ViewId",
                table: "role_Views",
                newName: "viewId");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "role_Views",
                newName: "roleId");

            migrationBuilder.RenameIndex(
                name: "IX_role_Views_ViewId",
                table: "role_Views",
                newName: "IX_role_Views_viewId");

            migrationBuilder.RenameIndex(
                name: "IX_role_Views_RoleId",
                table: "role_Views",
                newName: "IX_role_Views_roleId");

            migrationBuilder.AddForeignKey(
                name: "FK_role_Views_roles_roleId",
                table: "role_Views",
                column: "roleId",
                principalTable: "roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_role_Views_views_viewId",
                table: "role_Views",
                column: "viewId",
                principalTable: "views",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
