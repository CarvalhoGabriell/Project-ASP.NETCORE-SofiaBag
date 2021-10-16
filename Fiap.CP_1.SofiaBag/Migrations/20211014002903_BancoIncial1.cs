using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiap.CP_1.SofiaBag.Migrations
{
    public partial class BancoIncial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_OBJETOS",
                columns: table => new
                {
                    CodigoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    DtCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_OBJETOS", x => x.CodigoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_OBJETOS");
        }
    }
}
