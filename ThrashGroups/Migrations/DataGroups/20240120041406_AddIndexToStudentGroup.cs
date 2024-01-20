using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThrashGroups.Migrations.DataGroups
{
    /// <inheritdoc />
    public partial class AddIndexToStudentGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TypeCondition",
                table: "StudentGroups",
                columns: new[] { "StudentId", "Type" },
                unique: true,
                filter: "\"Type\"=1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TypeCondition",
                table: "StudentGroups");
        }
    }
}
