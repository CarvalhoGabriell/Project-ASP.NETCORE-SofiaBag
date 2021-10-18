using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiap.CP_1.SofiaBag.Migrations
{
    public partial class RelacionamentoCategoriaObj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "TB_OBJETOS",
                newName: "CategoriaId");

            migrationBuilder.CreateTable(
                name: "TB_CATEGORIA",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DtCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CATEGORIA", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "TB_OBJETOS_CATEGORIAS",
                columns: table => new
                {
                    CodigoId = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_OBJETOS_CATEGORIAS", x => new { x.CategoriaId, x.CodigoId });
                    table.ForeignKey(
                        name: "FK_TB_OBJETOS_CATEGORIAS_TB_CATEGORIA_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "TB_CATEGORIA",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_OBJETOS_CATEGORIAS_TB_OBJETOS_CodigoId",
                        column: x => x.CodigoId,
                        principalTable: "TB_OBJETOS",
                        principalColumn: "CodigoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_OBJETOS_CATEGORIAS_CodigoId",
                table: "TB_OBJETOS_CATEGORIAS",
                column: "CodigoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_OBJETOS_CATEGORIAS");

            migrationBuilder.DropTable(
                name: "TB_CATEGORIA");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "TB_OBJETOS",
                newName: "Tipo");
        }
    }
}
