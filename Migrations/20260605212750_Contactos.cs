using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chareun_contacts_api.Migrations
{
    /// <inheritdoc />
    public partial class Contactos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_contacto",
                table: "contacto");

            migrationBuilder.RenameTable(
                name: "contacto",
                newName: "Contactos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contactos",
                table: "Contactos",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Contactos",
                table: "Contactos");

            migrationBuilder.RenameTable(
                name: "Contactos",
                newName: "contacto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_contacto",
                table: "contacto",
                column: "Id");
        }
    }
}
