using Microsoft.EntityFrameworkCore.Migrations;

namespace Mini_Assignment.Migrations
{
    public partial class Change123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Student_StudentID",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Subject_SubjectID",
                table: "Enrollment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subject",
                table: "Subject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrollment",
                table: "Enrollment");

            migrationBuilder.DropColumn(
                name: "enrollmentId",
                table: "Enrollment");

            migrationBuilder.RenameTable(
                name: "Subject",
                newName: "Subjects");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "Enrollment",
                newName: "Enrollments");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Subjects",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Subjects",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "userName",
                table: "Students",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Students",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "mobileNo",
                table: "Students",
                newName: "MobileNo");

            migrationBuilder.RenameColumn(
                name: "addreess",
                table: "Students",
                newName: "Addreess");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Students",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "StudentID",
                table: "Enrollments",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "SubjectID",
                table: "Enrollments",
                newName: "SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_StudentID",
                table: "Enrollments",
                newName: "IX_Enrollments_StudentId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Enrollments",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrollments",
                table: "Enrollments",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_SubjectId",
                table: "Enrollments",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Students_StudentId",
                table: "Enrollments",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Subjects_SubjectId",
                table: "Enrollments",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Students_StudentId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Subjects_SubjectId",
                table: "Enrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subjects",
                table: "Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrollments",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_SubjectId",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Enrollments");

            migrationBuilder.RenameTable(
                name: "Subjects",
                newName: "Subject");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Student");

            migrationBuilder.RenameTable(
                name: "Enrollments",
                newName: "Enrollment");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Subject",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Subject",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Student",
                newName: "userName");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Student",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "MobileNo",
                table: "Student",
                newName: "mobileNo");

            migrationBuilder.RenameColumn(
                name: "Addreess",
                table: "Student",
                newName: "addreess");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Student",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "Enrollment",
                newName: "SubjectID");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Enrollment",
                newName: "StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_StudentId",
                table: "Enrollment",
                newName: "IX_Enrollment_StudentID");

            migrationBuilder.AddColumn<int>(
                name: "enrollmentId",
                table: "Enrollment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subject",
                table: "Subject",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrollment",
                table: "Enrollment",
                columns: new[] { "SubjectID", "StudentID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Student_StudentID",
                table: "Enrollment",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Subject_SubjectID",
                table: "Enrollment",
                column: "SubjectID",
                principalTable: "Subject",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
