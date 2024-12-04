using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Logic.Migrations
{
    /// <inheritdoc />
    public partial class added_notes_to_Course : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Notes_CourseId",
                table: "Notes",
                column: "CourseId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Course_CourseId",
                table: "Notes",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Course_CourseId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_CourseId",
                table: "Notes");
        }
    }
}
