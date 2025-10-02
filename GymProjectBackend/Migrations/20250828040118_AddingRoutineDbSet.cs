using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymProjectBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddingRoutineDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routine_Users_UserId",
                table: "Routine");

            migrationBuilder.DropForeignKey(
                name: "FK_RoutineExercises_Routine_RoutineId",
                table: "RoutineExercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Routine",
                table: "Routine");

            migrationBuilder.RenameTable(
                name: "Routine",
                newName: "Routines");

            migrationBuilder.RenameIndex(
                name: "IX_Routine_UserId",
                table: "Routines",
                newName: "IX_Routines_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Routines",
                table: "Routines",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoutineExercises_Routines_RoutineId",
                table: "RoutineExercises",
                column: "RoutineId",
                principalTable: "Routines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Routines_Users_UserId",
                table: "Routines",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoutineExercises_Routines_RoutineId",
                table: "RoutineExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Routines_Users_UserId",
                table: "Routines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Routines",
                table: "Routines");

            migrationBuilder.RenameTable(
                name: "Routines",
                newName: "Routine");

            migrationBuilder.RenameIndex(
                name: "IX_Routines_UserId",
                table: "Routine",
                newName: "IX_Routine_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Routine",
                table: "Routine",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Routine_Users_UserId",
                table: "Routine",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoutineExercises_Routine_RoutineId",
                table: "RoutineExercises",
                column: "RoutineId",
                principalTable: "Routine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
