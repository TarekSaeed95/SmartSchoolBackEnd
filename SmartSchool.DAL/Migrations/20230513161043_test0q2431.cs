using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartSchool.DAL.Migrations
{
    /// <inheritdoc />
    public partial class test0q2431 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Students",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Parents",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Students_IdentityUserId",
                table: "Students",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Parents_IdentityUserId",
                table: "Parents",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parents_AspNetUsers_IdentityUserId",
                table: "Parents",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_IdentityUserId",
                table: "Students",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parents_AspNetUsers_IdentityUserId",
                table: "Parents");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_IdentityUserId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_IdentityUserId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Parents_IdentityUserId",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Parents");
        }
    }
}
