using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymProjectBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddingIDFieldToRoutineExercises : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RoutineExercises",
                table: "RoutineExercises");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "RoutineExercises",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoutineExercises",
                table: "RoutineExercises",
                columns: new[] { "RoutineId", "ExerciseId", "Id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RoutineExercises",
                table: "RoutineExercises");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RoutineExercises");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoutineExercises",
                table: "RoutineExercises",
                columns: new[] { "RoutineId", "ExerciseId" });
        }
    }
}
