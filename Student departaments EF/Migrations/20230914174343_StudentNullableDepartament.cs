using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_departaments_EF.Migrations
{
    /// <inheritdoc />
    public partial class StudentNullableDepartament : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentModel_DepartamentModel_DepartamentId",
                table: "StudentModel");

            migrationBuilder.AlterColumn<Guid>(
                name: "DepartamentId",
                table: "StudentModel",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentModel_DepartamentModel_DepartamentId",
                table: "StudentModel",
                column: "DepartamentId",
                principalTable: "DepartamentModel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentModel_DepartamentModel_DepartamentId",
                table: "StudentModel");

            migrationBuilder.AlterColumn<Guid>(
                name: "DepartamentId",
                table: "StudentModel",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentModel_DepartamentModel_DepartamentId",
                table: "StudentModel",
                column: "DepartamentId",
                principalTable: "DepartamentModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
