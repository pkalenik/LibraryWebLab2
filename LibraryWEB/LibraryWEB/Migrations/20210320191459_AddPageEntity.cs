using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryWEB.Migrations
{
    public partial class AddPageEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleUa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleEng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentUa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentEng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortContentUa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortContentEng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEdit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ParentCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pages");
        }
    }
}
