using Microsoft.EntityFrameworkCore.Migrations;

namespace APICourse.Migrations
{
    public partial class first_seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tbCourse",
                columns: new[] { "Id", "Category", "Name" },
                values: new object[] { 1, "back-end", "Java" });

            migrationBuilder.InsertData(
                table: "tbCourse",
                columns: new[] { "Id", "Category", "Name" },
                values: new object[] { 2, "back-end", "C sharp" });

            migrationBuilder.InsertData(
                table: "tbCourse",
                columns: new[] { "Id", "Category", "Name" },
                values: new object[] { 3, "front-end", "Angular" });

            migrationBuilder.InsertData(
                table: "tbCourse",
                columns: new[] { "Id", "Category", "Name" },
                values: new object[] { 4, "front-end", "React JS" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tbCourse",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tbCourse",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tbCourse",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tbCourse",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
