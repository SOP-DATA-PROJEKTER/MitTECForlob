using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Logic.Migrations
{
    /// <inheritdoc />
    public partial class Fixed_Word_Error_in_Subj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subj_Course_CourseId",
                table: "Subj");

            migrationBuilder.DropColumn(
                name: "CouseId",
                table: "Subj");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Subj",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Subj_Course_CourseId",
                table: "Subj",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subj_Course_CourseId",
                table: "Subj");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Subj",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CouseId",
                table: "Subj",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Subj_Course_CourseId",
                table: "Subj",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id");
        }
    }
}
