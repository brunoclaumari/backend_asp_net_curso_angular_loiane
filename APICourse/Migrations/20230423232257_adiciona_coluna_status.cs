using Microsoft.EntityFrameworkCore.Migrations;

namespace APICourse.Migrations
{
    public partial class adiciona_coluna_status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "tbCourse",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "tbCourse",
                type: "TEXT",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "tbCourse",
                type: "TEXT",
                maxLength: 10,
                nullable: false,
                defaultValue: "Ativo");

            migrationBuilder.UpdateData(
                table: "tbCourse",
                keyColumn: "_id",
                keyValue: 1,
                column: "Status",
                value: "Ativo");

            migrationBuilder.UpdateData(
                table: "tbCourse",
                keyColumn: "_id",
                keyValue: 2,
                column: "Status",
                value: "Ativo");

            migrationBuilder.UpdateData(
                table: "tbCourse",
                keyColumn: "_id",
                keyValue: 3,
                column: "Status",
                value: "Ativo");

            migrationBuilder.UpdateData(
                table: "tbCourse",
                keyColumn: "_id",
                keyValue: 4,
                column: "Status",
                value: "Ativo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "tbCourse");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "tbCourse",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "tbCourse",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 10);
        }
    }
}
