using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessDataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Migration_0003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Usuario");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Usuario",
                newName: "Nombre");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "UsuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Users",
                newName: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UsuId");
        }
    }
}
