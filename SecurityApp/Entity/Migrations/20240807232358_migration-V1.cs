using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class migrationV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_View_Modulo_ModuleId",
                table: "View");

            migrationBuilder.RenameColumn(
                name: "ModuleId",
                table: "View",
                newName: "ModuloId");

            migrationBuilder.RenameIndex(
                name: "IX_View_ModuleId",
                table: "View",
                newName: "IX_View_ModuloId");

            migrationBuilder.AddForeignKey(
                name: "FK_View_Modulo_ModuloId",
                table: "View",
                column: "ModuloId",
                principalTable: "Modulo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_View_Modulo_ModuloId",
                table: "View");

            migrationBuilder.RenameColumn(
                name: "ModuloId",
                table: "View",
                newName: "ModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_View_ModuloId",
                table: "View",
                newName: "IX_View_ModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_View_Modulo_ModuleId",
                table: "View",
                column: "ModuleId",
                principalTable: "Modulo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
