using Microsoft.EntityFrameworkCore.Migrations;

namespace buddy_up.Migrations
{
    public partial class UpdatingBuddyMatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuddyMatch_Student_MenteeIdStudentID",
                table: "BuddyMatch");

            migrationBuilder.DropForeignKey(
                name: "FK_BuddyMatch_Student_MentorIdStudentID",
                table: "BuddyMatch");

            migrationBuilder.DropIndex(
                name: "IX_BuddyMatch_MenteeIdStudentID",
                table: "BuddyMatch");

            migrationBuilder.DropIndex(
                name: "IX_BuddyMatch_MentorIdStudentID",
                table: "BuddyMatch");

            migrationBuilder.DropColumn(
                name: "MenteeIdStudentID",
                table: "BuddyMatch");

            migrationBuilder.DropColumn(
                name: "MentorIdStudentID",
                table: "BuddyMatch");

            migrationBuilder.AddColumn<int>(
                name: "MenteeId",
                table: "BuddyMatch",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MentorId",
                table: "BuddyMatch",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BuddyMatch_MenteeId",
                table: "BuddyMatch",
                column: "MenteeId");

            migrationBuilder.CreateIndex(
                name: "IX_BuddyMatch_MentorId",
                table: "BuddyMatch",
                column: "MentorId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuddyMatch_Student_MenteeId",
                table: "BuddyMatch",
                column: "MenteeId",
                principalTable: "Student",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BuddyMatch_Student_MentorId",
                table: "BuddyMatch",
                column: "MentorId",
                principalTable: "Student",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuddyMatch_Student_MenteeId",
                table: "BuddyMatch");

            migrationBuilder.DropForeignKey(
                name: "FK_BuddyMatch_Student_MentorId",
                table: "BuddyMatch");

            migrationBuilder.DropIndex(
                name: "IX_BuddyMatch_MenteeId",
                table: "BuddyMatch");

            migrationBuilder.DropIndex(
                name: "IX_BuddyMatch_MentorId",
                table: "BuddyMatch");

            migrationBuilder.DropColumn(
                name: "MenteeId",
                table: "BuddyMatch");

            migrationBuilder.DropColumn(
                name: "MentorId",
                table: "BuddyMatch");

            migrationBuilder.AddColumn<int>(
                name: "MenteeIdStudentID",
                table: "BuddyMatch",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MentorIdStudentID",
                table: "BuddyMatch",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BuddyMatch_MenteeIdStudentID",
                table: "BuddyMatch",
                column: "MenteeIdStudentID");

            migrationBuilder.CreateIndex(
                name: "IX_BuddyMatch_MentorIdStudentID",
                table: "BuddyMatch",
                column: "MentorIdStudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_BuddyMatch_Student_MenteeIdStudentID",
                table: "BuddyMatch",
                column: "MenteeIdStudentID",
                principalTable: "Student",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BuddyMatch_Student_MentorIdStudentID",
                table: "BuddyMatch",
                column: "MentorIdStudentID",
                principalTable: "Student",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
