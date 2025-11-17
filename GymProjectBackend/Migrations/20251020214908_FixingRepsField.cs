using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymProjectBackend.Migrations
{
    /// <inheritdoc />
    public partial class FixingRepsField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                ALTER TABLE ""RoutineExercises"" 
                ALTER COLUMN ""Reps"" TYPE integer 
                USING ""Reps""::integer;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                ALTER TABLE ""RoutineExercises"" 
                ALTER COLUMN ""Reps"" TYPE text 
                USING ""Reps""::text;
            ");
        }
    }
}
