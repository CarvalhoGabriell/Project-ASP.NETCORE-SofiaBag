using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiap.CP_1.SofiaBag.Migrations
{
    public partial class RelacionamentoLembrete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LembreteId",
                table: "TB_OBJETOS",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NomeMochila",
                table: "T_USUARIO",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_OBJETOS_LembreteId",
                table: "TB_OBJETOS",
                column: "LembreteId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_OBJETOS_TB_LEMBRETE_LembreteId",
                table: "TB_OBJETOS",
                column: "LembreteId",
                principalTable: "TB_LEMBRETE",
                principalColumn: "LembreteId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_OBJETOS_TB_LEMBRETE_LembreteId",
                table: "TB_OBJETOS");

            migrationBuilder.DropIndex(
                name: "IX_TB_OBJETOS_LembreteId",
                table: "TB_OBJETOS");

            migrationBuilder.DropColumn(
                name: "LembreteId",
                table: "TB_OBJETOS");

            migrationBuilder.AlterColumn<string>(
                name: "NomeMochila",
                table: "T_USUARIO",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40,
                oldNullable: true);
        }
    }
}
