using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartSchool.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updateStudentAttendance02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAttendance_Students_studentId",
                table: "StudentAttendance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentAttendance",
                table: "StudentAttendance");

            migrationBuilder.RenameTable(
                name: "StudentAttendance",
                newName: "StudAttendances");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAttendance_studentId",
                table: "StudAttendances",
                newName: "IX_StudAttendances_studentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudAttendances",
                table: "StudAttendances",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudAttendances_Students_studentId",
                table: "StudAttendances",
                column: "studentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudAttendances_Students_studentId",
                table: "StudAttendances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudAttendances",
                table: "StudAttendances");

            migrationBuilder.RenameTable(
                name: "StudAttendances",
                newName: "StudentAttendance");

            migrationBuilder.RenameIndex(
                name: "IX_StudAttendances_studentId",
                table: "StudentAttendance",
                newName: "IX_StudentAttendance_studentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentAttendance",
                table: "StudentAttendance",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAttendance_Students_studentId",
                table: "StudentAttendance",
                column: "studentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
