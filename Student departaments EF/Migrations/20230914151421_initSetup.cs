using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_departaments_EF.Migrations
{
    /// <inheritdoc />
    public partial class initSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DepartamentModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartamentModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LectureModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LectureModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DepartamentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentModel_DepartamentModel_DepartamentId",
                        column: x => x.DepartamentId,
                        principalTable: "DepartamentModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartamentLectureModel",
                columns: table => new
                {
                    DepartamentModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LectureModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartamentLectureModel", x => new { x.DepartamentModelId, x.LectureModelId });
                    table.ForeignKey(
                        name: "FK_DepartamentLectureModel_DepartamentModel_DepartamentModelId",
                        column: x => x.DepartamentModelId,
                        principalTable: "DepartamentModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartamentLectureModel_LectureModel_LectureModelId",
                        column: x => x.LectureModelId,
                        principalTable: "LectureModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LectureStudentModels",
                columns: table => new
                {
                    LectureModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentIModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LectureStudentModels", x => new { x.LectureModelId, x.StudentIModelId });
                    table.ForeignKey(
                        name: "FK_LectureStudentModels_LectureModel_LectureModelId",
                        column: x => x.LectureModelId,
                        principalTable: "LectureModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LectureStudentModels_StudentModel_StudentIModelId",
                        column: x => x.StudentIModelId,
                        principalTable: "StudentModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartamentLectureModel_LectureModelId",
                table: "DepartamentLectureModel",
                column: "LectureModelId");

            migrationBuilder.CreateIndex(
                name: "IX_LectureStudentModels_StudentIModelId",
                table: "LectureStudentModels",
                column: "StudentIModelId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentModel_DepartamentId",
                table: "StudentModel",
                column: "DepartamentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartamentLectureModel");

            migrationBuilder.DropTable(
                name: "LectureStudentModels");

            migrationBuilder.DropTable(
                name: "LectureModel");

            migrationBuilder.DropTable(
                name: "StudentModel");

            migrationBuilder.DropTable(
                name: "DepartamentModel");
        }
    }
}
