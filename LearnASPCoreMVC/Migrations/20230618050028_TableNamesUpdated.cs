using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnASPCoreMVC.Migrations
{
    /// <inheritdoc />
    public partial class TableNamesUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Courses_CourseID",
                table: "StudentCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Students_StudentID",
                table: "StudentCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentCourses",
                table: "StudentCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Student_Table");

            migrationBuilder.RenameTable(
                name: "StudentCourses",
                newName: "StudentCourse_Table");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course_Table");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourses_StudentID",
                table: "StudentCourse_Table",
                newName: "IX_StudentCourse_Table_StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourses_CourseID",
                table: "StudentCourse_Table",
                newName: "IX_StudentCourse_Table_CourseID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student_Table",
                table: "Student_Table",
                column: "StudentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentCourse_Table",
                table: "StudentCourse_Table",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course_Table",
                table: "Course_Table",
                column: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourse_Table_Course_Table_CourseID",
                table: "StudentCourse_Table",
                column: "CourseID",
                principalTable: "Course_Table",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourse_Table_Student_Table_StudentID",
                table: "StudentCourse_Table",
                column: "StudentID",
                principalTable: "Student_Table",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourse_Table_Course_Table_CourseID",
                table: "StudentCourse_Table");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourse_Table_Student_Table_StudentID",
                table: "StudentCourse_Table");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentCourse_Table",
                table: "StudentCourse_Table");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student_Table",
                table: "Student_Table");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course_Table",
                table: "Course_Table");

            migrationBuilder.RenameTable(
                name: "StudentCourse_Table",
                newName: "StudentCourses");

            migrationBuilder.RenameTable(
                name: "Student_Table",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "Course_Table",
                newName: "Courses");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourse_Table_StudentID",
                table: "StudentCourses",
                newName: "IX_StudentCourses_StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourse_Table_CourseID",
                table: "StudentCourses",
                newName: "IX_StudentCourses_CourseID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentCourses",
                table: "StudentCourses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "StudentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Courses_CourseID",
                table: "StudentCourses",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Students_StudentID",
                table: "StudentCourses",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
