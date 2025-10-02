using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GymProjectBackend.Migrations
{
    /// <inheritdoc />
    public partial class SeedingExerciseData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Exercise",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("00b12ad3-d154-4d1d-a12a-4a3bad0013cf"), "Strengthens trapezius muscles; improves upper back.", "Machine Shrug" },
                    { new Guid("19ed1d82-2e4f-454a-868c-7a21392eeba0"), "Works upper back; improves rowing strength.", "Pendlay Deficit Row" },
                    { new Guid("33d2e640-5ec6-404d-8a98-e8bac12b1d0e"), "Works outer thigh muscles; enhances hip strength.", "Machine Hip Abduction" },
                    { new Guid("3efde5b5-224d-4247-b3fc-256975550007"), "Biceps focused curl; builds arm muscle mass.", "Bayesian Cable Curl" },
                    { new Guid("44a34dfa-f3b6-4ee2-b11a-77ad2a996c6c"), "Targets triceps; increases arm strength.", "Overhead Cable Triceps Extension" },
                    { new Guid("530e99af-b707-4300-96e2-2ebd29568561"), "Targets quadriceps and glutes; improves leg power.", "Smith Machine Squat" },
                    { new Guid("5b524366-b936-45d7-81bc-f45b44d7aa84"), "Focuses on middle back; builds rowing muscles.", "Chest-Supported Machine Row" },
                    { new Guid("5c6e3644-55d4-40c8-a622-60937e6d1f1f"), "Targets hamstrings; improves knee flexion.", "Seated Leg Curl" },
                    { new Guid("5f3ea923-4f7e-43ba-8c72-a9e5fa1d0c35"), "Focuses on shoulder deltoids; builds shoulder stability.", "High-Cable Lateral Raise" },
                    { new Guid("64f94f80-4273-4448-b466-101c7f93911c"), "Works back and biceps; enhances pulling power.", "Neutral-Grip Seated Cable Row" },
                    { new Guid("6d29f811-26cc-4f4b-84b2-cf762dabbea6"), "Targets abdominal muscles; improves core stability.", "Cable Crunch" },
                    { new Guid("731c2f7a-d0f9-4e9b-a475-dd8378c961bb"), "Targets quadriceps; improves knee extension strength.", "Leg Extension" },
                    { new Guid("77b3f3ed-3d84-43ee-b825-b4196fd65fb6"), "Strengthens back and biceps; improves upper body strength.", "Wide-Grip Pull-Up" },
                    { new Guid("7c5574c3-9af0-4e51-972d-c8b505ee2f37"), "Triceps isolation; increases arm muscle tone.", "Cable Triceps Kickback" },
                    { new Guid("7df68621-8af0-458c-a406-26bcbd5e6a2f"), "Works calf muscles; builds lower leg strength.", "Standing Calf Raise" },
                    { new Guid("83377183-2181-41b0-a7a4-4997e91fefba"), "Targets inner thigh muscles; improves hip stability.", "Machine Hip Adduction" },
                    { new Guid("85dde610-fcf4-4257-bf79-7536ce9ef51e"), "Targets shoulder muscles; improves overhead strength.", "Machine Shoulder Press" },
                    { new Guid("89b5698a-c784-48f8-87cd-a3238146c7e6"), "Targets rear deltoids; improves shoulder posture.", "1-Arm 45° Cable Rear Delt Flye" },
                    { new Guid("9b83eca7-d801-461e-8828-01af82713e44"), "Biceps focused cable curl; builds arm strength.", "EZ-Bar Cable Curl" },
                    { new Guid("a725385c-fb51-474a-8918-a4d6655560f8"), "Works hamstrings; strengthens posterior leg muscles.", "Lying Leg Curl" },
                    { new Guid("acc12894-9671-4cb9-8d1b-03d1f2142334"), "Works quads and glutes; enhances balance.", "DB Bulgarian Split Squat" },
                    { new Guid("bdee0ca8-b85d-467d-a321-868562bccb7e"), "Targets chest muscles; enhances muscle definition.", "Cable Crossover Ladder" },
                    { new Guid("c47064a8-f6bf-41c3-b185-4835d431ab6e"), "Biceps strengthening exercise; builds arm bulk.", "EZ-Bar Curl" },
                    { new Guid("cafec9aa-0b10-4bd1-a3e6-5c4d906e9312"), "Strengthens latissimus dorsi and arms; improves back width.", "Neutral-Grip Lat Pulldown" },
                    { new Guid("d450388f-b618-4bff-8f7e-93057e3f126d"), "Works upper chest and shoulders; strengthens pectoral muscles.", "45° Incline Barbell Press" },
                    { new Guid("db3ee553-d9b3-49ec-86ad-4bda1b73089a"), "Works chest, shoulders, and triceps; builds upper body strength.", "Barbell Bench Press" },
                    { new Guid("dcb4352f-96d5-44ae-8306-a7bc79af29d9"), "Isolates biceps; enhances arm definition.", "Machine Preacher Curl" },
                    { new Guid("fc289eaf-67fa-42fd-b924-7a891bb9ecb0"), "Works hamstrings and lower back; enhances stability.", "Barbell RDL" },
                    { new Guid("fc347390-1b3f-474d-831f-de4d328aea74"), "Targets lower abs; improves core strength.", "Roman Chair Leg Raise" },
                    { new Guid("fe503335-d0c9-4852-a0c9-7740edbf2529"), "Works legs and glutes; increases leg power.", "Leg Press" },
                    { new Guid("ffcb3187-9f9f-4b68-9274-75c01c71b466"), "Focuses on chest; enhances muscle control.", "Bottom-Half DB Flye" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("00b12ad3-d154-4d1d-a12a-4a3bad0013cf"));

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("19ed1d82-2e4f-454a-868c-7a21392eeba0"));

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("33d2e640-5ec6-404d-8a98-e8bac12b1d0e"));

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("3efde5b5-224d-4247-b3fc-256975550007"));

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("44a34dfa-f3b6-4ee2-b11a-77ad2a996c6c"));

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("530e99af-b707-4300-96e2-2ebd29568561"));

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("5b524366-b936-45d7-81bc-f45b44d7aa84"));

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("5c6e3644-55d4-40c8-a622-60937e6d1f1f"));

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("5f3ea923-4f7e-43ba-8c72-a9e5fa1d0c35"));

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("64f94f80-4273-4448-b466-101c7f93911c"));

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("6d29f811-26cc-4f4b-84b2-cf762dabbea6"));

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("731c2f7a-d0f9-4e9b-a475-dd8378c961bb"));

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("77b3f3ed-3d84-43ee-b825-b4196fd65fb6"));

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("7c5574c3-9af0-4e51-972d-c8b505ee2f37"));

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("7df68621-8af0-458c-a406-26bcbd5e6a2f"));

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("83377183-2181-41b0-a7a4-4997e91fefba"));

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("85dde610-fcf4-4257-bf79-7536ce9ef51e"));

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("89b5698a-c784-48f8-87cd-a3238146c7e6"));

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("9b83eca7-d801-461e-8828-01af82713e44"));

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("a725385c-fb51-474a-8918-a4d6655560f8"));

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("acc12894-9671-4cb9-8d1b-03d1f2142334"));

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("bdee0ca8-b85d-467d-a321-868562bccb7e"));

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("c47064a8-f6bf-41c3-b185-4835d431ab6e"));

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("cafec9aa-0b10-4bd1-a3e6-5c4d906e9312"));

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("d450388f-b618-4bff-8f7e-93057e3f126d"));

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("db3ee553-d9b3-49ec-86ad-4bda1b73089a"));

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("dcb4352f-96d5-44ae-8306-a7bc79af29d9"));

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("fc289eaf-67fa-42fd-b924-7a891bb9ecb0"));

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("fc347390-1b3f-474d-831f-de4d328aea74"));

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("fe503335-d0c9-4852-a0c9-7740edbf2529"));

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: new Guid("ffcb3187-9f9f-4b68-9274-75c01c71b466"));
        }
    }
}
