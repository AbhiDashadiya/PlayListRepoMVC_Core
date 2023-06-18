using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnASPCoreMVC.Migrations
{
	/// <inheritdoc />
	public partial class InitialMigration : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Courses",
				columns: table => new
				{
					CourseID = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Code = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Courses", x => x.CourseID);
				});

			migrationBuilder.CreateTable(
				name: "Students",
				columns: table => new
				{
					StudentID = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Enrolled = table.Column<DateTime>(type: "datetime2", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Students", x => x.StudentID);
				});

			migrationBuilder.CreateTable(
				name: "StudentCourses",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					StudentID = table.Column<int>(type: "int", nullable: false),
					CourseID = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_StudentCourses", x => x.Id);
					table.ForeignKey(
						name: "FK_StudentCourses_Courses_CourseID",
						column: x => x.CourseID,
						principalTable: "Courses",
						principalColumn: "CourseID",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_StudentCourses_Students_StudentID",
						column: x => x.StudentID,
						principalTable: "Students",
						principalColumn: "StudentID",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_StudentCourses_CourseID",
				table: "StudentCourses",
				column: "CourseID");

			migrationBuilder.CreateIndex(
				name: "IX_StudentCourses_StudentID",
				table: "StudentCourses",
				column: "StudentID");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "StudentCourses");

			migrationBuilder.DropTable(
				name: "Courses");

			migrationBuilder.DropTable(
				name: "Students");
		}
	}
}
