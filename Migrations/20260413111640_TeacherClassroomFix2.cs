using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GTest.Migrations
{
    /// <inheritdoc />
    public partial class TeacherClassroomFix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Classrooms_ClassroomId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_ClassroomId",
                table: "Teachers");

            migrationBuilder.AlterColumn<int>(
                name: "HomeroomTeacherId",
                table: "Classrooms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Classrooms_HomeroomTeacherId",
                table: "Classrooms",
                column: "HomeroomTeacherId",
                unique: true,
                filter: "[HomeroomTeacherId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Classrooms_Teachers_HomeroomTeacherId",
                table: "Classrooms",
                column: "HomeroomTeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classrooms_Teachers_HomeroomTeacherId",
                table: "Classrooms");

            migrationBuilder.DropIndex(
                name: "IX_Classrooms_HomeroomTeacherId",
                table: "Classrooms");

            migrationBuilder.AlterColumn<int>(
                name: "HomeroomTeacherId",
                table: "Classrooms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
