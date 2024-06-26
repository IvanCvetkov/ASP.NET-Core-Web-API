using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class CommentOneToOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Portfolios_Comments_CommentId",
                table: "Portfolios");

            migrationBuilder.DropIndex(
                name: "IX_Portfolios_CommentId",
                table: "Portfolios");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b429b4a-bcc0-4c17-9fcf-cdcbad80717f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5acb537-6c03-47e9-8009-f36817c501c2");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Portfolios");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "42bec06c-95e3-4d6b-a7e6-81421e41812d", null, "Admin", "ADMIN" },
                    { "a596e205-fa38-4f67-b068-09d921cb5252", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AppUserId",
                table: "Comments",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_AppUserId",
                table: "Comments",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_AppUserId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AppUserId",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42bec06c-95e3-4d6b-a7e6-81421e41812d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a596e205-fa38-4f67-b068-09d921cb5252");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "Portfolios",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7b429b4a-bcc0-4c17-9fcf-cdcbad80717f", null, "Admin", "ADMIN" },
                    { "d5acb537-6c03-47e9-8009-f36817c501c2", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_CommentId",
                table: "Portfolios",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolios_Comments_CommentId",
                table: "Portfolios",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id");
        }
    }
}
