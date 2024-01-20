using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThrashGroups.Migrations.DataGroups
{
    /// <inheritdoc />
    public partial class AddCHKForTypeInStudentGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CHK_StudentGroup_Type",
                table: "StudentGroups",
                sql: "\"Type\" IN (1, 2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CHK_StudentGroup_Type",
                table: "StudentGroups");
        }
    }
}
