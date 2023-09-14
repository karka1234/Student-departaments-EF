using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_departaments_EF.Migrations
{
    /// <inheritdoc />
    public partial class StudentFullNameUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_StudentModel_FullName",
                table: "StudentModel",
                column: "FullName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentModel_FullName",
                table: "StudentModel");
        }
    }
}
