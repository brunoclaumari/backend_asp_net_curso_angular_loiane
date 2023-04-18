using Microsoft.EntityFrameworkCore.Migrations;

namespace APICourse.Migrations
{
    public partial class alter_column_id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tbCourse",
                newName: "_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "_id",
                table: "tbCourse",
                newName: "Id");
        }
    }
}
