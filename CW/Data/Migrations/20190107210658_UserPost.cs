using Microsoft.EntityFrameworkCore.Migrations;

namespace CW.Data.Migrations
{
    public partial class UserPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MyUserId",
                table: "Statuses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MyUserId",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_MyUserId",
                table: "Statuses",
                column: "MyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_MyUserId",
                table: "Comments",
                column: "MyUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_MyUserId",
                table: "Comments",
                column: "MyUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Statuses_AspNetUsers_MyUserId",
                table: "Statuses",
                column: "MyUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_MyUserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Statuses_AspNetUsers_MyUserId",
                table: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_Statuses_MyUserId",
                table: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_Comments_MyUserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "MyUserId",
                table: "Statuses");

            migrationBuilder.DropColumn(
                name: "MyUserId",
                table: "Comments");
        }
    }
}
