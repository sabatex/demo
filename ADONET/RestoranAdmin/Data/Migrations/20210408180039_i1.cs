using Microsoft.EntityFrameworkCore.Migrations;

namespace RestoranAdmin.Data.Migrations
{
    public partial class i1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                schema: "mybase",
                table: "Офіціант",
                type: "TEXT",
                maxLength: 18,
                nullable: true,
                comment: "Пароль в відкитому виді",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 18,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                schema: "mybase",
                table: "Офіціант",
                type: "TEXT",
                maxLength: 18,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 18,
                oldNullable: true,
                oldComment: "Пароль в відкитому виді");
        }
    }
}
