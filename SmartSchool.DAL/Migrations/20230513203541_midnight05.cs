using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartSchool.DAL.Migrations
{
    /// <inheritdoc />
    public partial class midnight05 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Teachers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Teachers",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "Teachers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Teachers");
        }
    }
}
