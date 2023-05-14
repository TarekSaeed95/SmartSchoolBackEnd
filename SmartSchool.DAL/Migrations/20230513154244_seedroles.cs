using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartSchool.DAL.Migrations
{
    /// <inheritdoc />
    public partial class seedroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
               table: "AspNetRoles",
               columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },

               values: new object[] { Guid.NewGuid().ToString(), "Admin", "admin".ToUpper(), Guid.NewGuid().ToString() }
               );

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },

                values: new object[] { Guid.NewGuid().ToString(), "Teacher", "teacher".ToUpper(), Guid.NewGuid().ToString() }
                );

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },

                values: new object[] { Guid.NewGuid().ToString(), "Student", "student".ToUpper(), Guid.NewGuid().ToString() }
                );

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },

                values: new object[] { Guid.NewGuid().ToString(), "Parent", "parent".ToUpper(), Guid.NewGuid().ToString() }
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [dbo].[AspNetRoles]");
        }
    }
}
