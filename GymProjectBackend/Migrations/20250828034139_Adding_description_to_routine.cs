using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymProjectBackend.Migrations
{
    /// <inheritdoc />
    public partial class Adding_description_to_routine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Routine",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Routine");
        }
    }
}
