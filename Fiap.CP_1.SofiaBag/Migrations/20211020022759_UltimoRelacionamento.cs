using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiap.CP_1.SofiaBag.Migrations
{
    public partial class UltimoRelacionamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_OBJETOS_TB_LEMBRETE_LembreteId",
                table: "TB_OBJETOS");

            migrationBuilder.AlterColumn<int>(
                name: "LembreteId",
                table: "TB_OBJETOS",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "TB_OBJETOS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "TB_CATEGORIA",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_OBJETOS_UsuarioId",
                table: "TB_OBJETOS",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_OBJETOS_T_USUARIO_UsuarioId",
                table: "TB_OBJETOS",
                column: "UsuarioId",
                principalTable: "T_USUARIO",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_TB_OBJETOS_T_USUARIO_UsuarioId",
                table: "TB_OBJETOS");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_OBJETOS_TB_LEMBRETE_LembreteId",
                table: "TB_OBJETOS");

            migrationBuilder.DropIndex(
                name: "IX_TB_OBJETOS_UsuarioId",
                table: "TB_OBJETOS");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "TB_OBJETOS");

            migrationBuilder.AlterColumn<int>(
                name: "LembreteId",
                table: "TB_OBJETOS",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "TB_CATEGORIA",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_OBJETOS_TB_LEMBRETE_LembreteId",
                table: "TB_OBJETOS",
                column: "LembreteId",
                principalTable: "TB_LEMBRETE",
                principalColumn: "LembreteId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
