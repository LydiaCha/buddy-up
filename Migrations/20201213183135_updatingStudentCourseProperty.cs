using Microsoft.EntityFrameworkCore.Migrations;

namespace buddy_up.Migrations
{
    public partial class updatingStudentCourseProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Course_CourseID",
                table: "Student");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "Student",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_CourseID",
                table: "Student",
                newName: "IX_Student_CourseId");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Student",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Course_CourseId",
                table: "Student",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Course_CourseId",
                table: "Student");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Student",
                newName: "CourseID");

            migrationBuilder.RenameIndex(
                name: "IX_Student_CourseId",
                table: "Student",
                newName: "IX_Student_CourseID");

            migrationBuilder.AlterColumn<int>(
                name: "CourseID",
                table: "Student",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Course_CourseID",
                table: "Student",
                column: "CourseID",
                principalTable: "Course",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
