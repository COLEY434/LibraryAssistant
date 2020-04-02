using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryAssistant.Data.Migrations
{
    public partial class AddBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 30, nullable: false),
                    ISBN = table.Column<string>(maxLength: 30, nullable: false),
                    Published_Year = table.Column<DateTime>(nullable: false),
                    Cover_Price = table.Column<decimal>(nullable: false),
                    Availability_Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
