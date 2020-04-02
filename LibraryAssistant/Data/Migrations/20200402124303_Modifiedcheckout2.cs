using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryAssistant.Data.Migrations
{
    public partial class Modifiedcheckout2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_AspNetUsers_UserId",
                table: "Checkouts");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Checkouts",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Checkouts_AspNetUsers_UserId",
                table: "Checkouts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkouts_AspNetUsers_UserId",
                table: "Checkouts");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Checkouts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Checkouts_AspNetUsers_UserId",
                table: "Checkouts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
