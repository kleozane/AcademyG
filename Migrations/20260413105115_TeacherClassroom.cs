using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GTest.Migrations
{
    /// <inheritdoc />
    public partial class TeacherClassroom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classrooms_Teachers_HomeroomTeacherId",
                table: "Classrooms");

            migrationBuilder.DropIndex(
                name: "IX_Classrooms_HomeroomTeacherId",
                table: "Classrooms");

            migrationBuilder.AddColumn<int>(
                name: "ClassroomId",
                table: "Teachers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_ClassroomId",
                table: "Teachers",
                column: "ClassroomId",
                unique: true,
                filter: "[ClassroomId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Classrooms_ClassroomId",
                table: "Teachers",
                column: "ClassroomId",
                principalTable: "Classrooms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Classrooms_ClassroomId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_ClassroomId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "ClassroomId",
                table: "Teachers");

            migrationBuilder.CreateIndex(
                name: "IX_Classrooms_HomeroomTeacherId",
                table: "Classrooms",
                column: "HomeroomTeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classrooms_Teachers_HomeroomTeacherId",
                table: "Classrooms",
                column: "HomeroomTeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
