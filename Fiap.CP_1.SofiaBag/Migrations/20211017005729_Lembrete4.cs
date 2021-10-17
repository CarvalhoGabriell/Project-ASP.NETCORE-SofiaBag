using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiap.CP_1.SofiaBag.Migrations
{
    public partial class Lembrete4 : Migration
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
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "TB_LEMBRETE",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "TB_LEMBRETE",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_OBJETOS_TB_LEMBRETE_LembreteId",
                table: "TB_OBJETOS",
                column: "LembreteId",
                principalTable: "TB_LEMBRETE",
                principalColumn: "LembreteId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "TB_LEMBRETE",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "TB_LEMBRETE",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_OBJETOS_TB_LEMBRETE_LembreteId",
                table: "TB_OBJETOS",
                column: "LembreteId",
                principalTable: "TB_LEMBRETE",
                principalColumn: "LembreteId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
