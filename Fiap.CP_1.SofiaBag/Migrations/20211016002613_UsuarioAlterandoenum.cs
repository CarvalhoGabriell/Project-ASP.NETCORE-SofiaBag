using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiap.CP_1.SofiaBag.Migrations
{
    public partial class UsuarioAlterandoenum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "sexo",
                table: "T_USUARIO",
                newName: "Sexo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sexo",
                table: "T_USUARIO",
                newName: "sexo");
        }
    }
}
