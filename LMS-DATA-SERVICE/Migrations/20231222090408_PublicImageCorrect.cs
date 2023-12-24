using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS_DATA_SERVICE.Migrations
{
    /// <inheritdoc />
    public partial class PublicImageCorrect : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThumbNails_Courses_CourseId",
                table: "ThumbNails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ThumbNails",
                table: "ThumbNails");

            migrationBuilder.RenameTable(
                name: "ThumbNails",
                newName: "PublicImages");

            migrationBuilder.RenameIndex(
                name: "IX_ThumbNails_CourseId",
                table: "PublicImages",
                newName: "IX_PublicImages_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PublicImages",
                table: "PublicImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PublicImages_Courses_CourseId",
                table: "PublicImages",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PublicImages_Courses_CourseId",
                table: "PublicImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PublicImages",
                table: "PublicImages");

            migrationBuilder.RenameTable(
                name: "PublicImages",
                newName: "ThumbNails");

            migrationBuilder.RenameIndex(
                name: "IX_PublicImages_CourseId",
                table: "ThumbNails",
                newName: "IX_ThumbNails_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ThumbNails",
                table: "ThumbNails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ThumbNails_Courses_CourseId",
                table: "ThumbNails",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
