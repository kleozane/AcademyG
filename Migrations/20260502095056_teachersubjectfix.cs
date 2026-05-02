using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GTest.Migrations
{
    /// <inheritdoc />
    public partial class teachersubjectfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSubject_Subjects_SubjectId",
                table: "TeacherSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSubject_Teachers_TeacherId",
                table: "TeacherSubject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherSubject",
                table: "TeacherSubject");

            migrationBuilder.RenameTable(
                name: "TeacherSubject",
                newName: "TeacherSubjects");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherSubject_SubjectId",
                table: "TeacherSubjects",
                newName: "IX_TeacherSubjects_SubjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherSubjects",
                table: "TeacherSubjects",
                columns: new[] { "TeacherId", "SubjectId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSubjects_Subjects_SubjectId",
                table: "TeacherSubjects",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSubjects_Teachers_TeacherId",
                table: "TeacherSubjects",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSubjects_Subjects_SubjectId",
                table: "TeacherSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSubjects_Teachers_TeacherId",
                table: "TeacherSubjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherSubjects",
                table: "TeacherSubjects");

            migrationBuilder.RenameTable(
                name: "TeacherSubjects",
                newName: "TeacherSubject");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherSubjects_SubjectId",
                table: "TeacherSubject",
                newName: "IX_TeacherSubject_SubjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherSubject",
                table: "TeacherSubject",
                columns: new[] { "TeacherId", "SubjectId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSubject_Subjects_SubjectId",
                table: "TeacherSubject",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSubject_Teachers_TeacherId",
                table: "TeacherSubject",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
