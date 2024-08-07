using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class migratopm222 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_View_Modulo_moduleId",
                table: "View");

            migrationBuilder.DropColumn(
                name: "idModule",
                table: "View");

            migrationBuilder.RenameColumn(
                name: "moduleId",
                table: "View",
                newName: "ModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_View_moduleId",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_View_Modulo_ModuleId",
                table: "View");

            migrationBuilder.RenameColumn(
                name: "ModuleId",
                table: "View",
                newName: "moduleId");

            migrationBuilder.RenameIndex(
                name: "IX_View_ModuleId",
                table: "View",
                newName: "IX_View_moduleId");

            migrationBuilder.AddColumn<int>(
                name: "idModule",
                table: "View",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_View_Modulo_moduleId",
                table: "View",
                column: "moduleId",
                principalTable: "Modulo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
