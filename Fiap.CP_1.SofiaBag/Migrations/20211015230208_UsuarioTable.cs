using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiap.CP_1.SofiaBag.Migrations
{
    public partial class UsuarioTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_USUARIO",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCompleto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NomeMochila = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Idade = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    DtNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    sexo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_USUARIO", x => x.UsuarioId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_USUARIO");
        }
    }
}
