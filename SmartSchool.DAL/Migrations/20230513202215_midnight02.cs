using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartSchool.DAL.Migrations
{
    /// <inheritdoc />
    public partial class midnight02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Teachers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_IdentityUserId",
                table: "Teachers",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_AspNetUsers_IdentityUserId",
                table: "Teachers",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_AspNetUsers_IdentityUserId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_IdentityUserId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Teachers");
        }
    }
}
