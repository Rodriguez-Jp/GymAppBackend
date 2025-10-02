using GymProjectBackend.Entities;

using System;

namespace GymProjectBackend.Seed
{
    public static class ExerciseSeedData
    {
        public static readonly Exercise[] AllExercises = new[]
        {
            new Exercise { Id = Guid.Parse("b4921f63-a4f4-4771-944b-d83aa412990f"), Name = "45° Incline Barbell Press", Description = "Works upper chest and shoulders; strengthens pectoral muscles." },
            new Exercise { Id = Guid.Parse("7258c531-e5e6-4381-ac39-bef8e172abb3"), Name = "Cable Crossover Ladder", Description = "Targets chest muscles; enhances muscle definition." },
            new Exercise { Id = Guid.Parse("3b688d62-81ef-47dc-a3fe-d7d171f048f9"), Name = "Wide-Grip Pull-Up", Description = "Strengthens back and biceps; improves upper body strength." },
            new Exercise { Id = Guid.Parse("481ea5b5-3563-4dda-9c94-5f0b497afc50"), Name = "High-Cable Lateral Raise", Description = "Focuses on shoulder deltoids; builds shoulder stability." },
            new Exercise { Id = Guid.Parse("1a44675c-7cff-4029-85ce-3e8520bf7a08"), Name = "Pendlay Deficit Row", Description = "Works upper back; improves rowing strength." },
            new Exercise { Id = Guid.Parse("60573d49-fa8b-43da-898a-27e9b3e269a5"), Name = "Overhead Cable Triceps Extension", Description = "Targets triceps; increases arm strength." },
            new Exercise { Id = Guid.Parse("9d34005b-0b74-4eb4-88d2-451418918e0b"), Name = "Bayesian Cable Curl", Description = "Biceps focused curl; builds arm muscle mass." },
            new Exercise { Id = Guid.Parse("c3cfa0ab-db58-41bc-8789-ffc5b30c175c"), Name = "Lying Leg Curl", Description = "Works hamstrings; strengthens posterior leg muscles." },
            new Exercise { Id = Guid.Parse("9589df47-1ef3-472c-9cdf-bc3f270141c0"), Name = "Smith Machine Squat", Description = "Targets quadriceps and glutes; improves leg power." },
            new Exercise { Id = Guid.Parse("8e2b6a1c-75d0-4b65-a2f0-45f35a22e316"), Name = "Barbell RDL", Description = "Works hamstrings and lower back; enhances stability." },
            new Exercise { Id = Guid.Parse("107e847a-a9e3-4aad-ae72-abcac5276407"), Name = "Leg Extension", Description = "Targets quadriceps; improves knee extension strength." },
            new Exercise { Id = Guid.Parse("9e504cc8-5ea0-48bf-9903-31e256cdcd4d"), Name = "Standing Calf Raise", Description = "Works calf muscles; builds lower leg strength." },
            new Exercise { Id = Guid.Parse("586619af-1eeb-44d8-91b8-3effa260dbeb"), Name = "Cable Crunch", Description = "Targets abdominal muscles; improves core stability." },
            new Exercise { Id = Guid.Parse("d3a1f831-9533-4284-af53-5de73a29b5e6"), Name = "Neutral-Grip Lat Pulldown", Description = "Strengthens latissimus dorsi and arms; improves back width." },
            new Exercise { Id = Guid.Parse("e5cad7d1-1b2d-4a09-ac6e-d37dcfb8915b"), Name = "Chest-Supported Machine Row", Description = "Focuses on middle back; builds rowing muscles." },
            new Exercise { Id = Guid.Parse("917aa842-c9f8-49fb-92e0-456a9c74abae"), Name = "Neutral-Grip Seated Cable Row", Description = "Works back and biceps; enhances pulling power." },
            new Exercise { Id = Guid.Parse("b99471a5-aea1-4a68-a6a2-85b155877503"), Name = "1-Arm 45° Cable Rear Delt Flye", Description = "Targets rear deltoids; improves shoulder posture." },
            new Exercise { Id = Guid.Parse("f3d041ea-4be3-4917-b6ac-ff083d6f8c05"), Name = "Machine Shrug", Description = "Strengthens trapezius muscles; improves upper back." },
            new Exercise { Id = Guid.Parse("eb4f475b-353e-4105-87d5-fce442c0f30e"), Name = "EZ-Bar Curl", Description = "Biceps strengthening exercise; builds arm bulk." },
            new Exercise { Id = Guid.Parse("149d052f-3c6f-4bfb-9d9a-7f05920afc1f"), Name = "Machine Preacher Curl", Description = "Isolates biceps; enhances arm definition." },
            new Exercise { Id = Guid.Parse("40fa391d-30b3-4683-b4e9-2287127111df"), Name = "Barbell Bench Press", Description = "Works chest, shoulders, and triceps; builds upper body strength." },
            new Exercise { Id = Guid.Parse("2341500d-a031-4803-a3fc-3ae24c6c3662"), Name = "Machine Shoulder Press", Description = "Targets shoulder muscles; improves overhead strength." },
            new Exercise { Id = Guid.Parse("3da9c379-9fa9-4f0c-93db-7074289254a5"), Name = "Bottom-Half DB Flye", Description = "Focuses on chest; enhances muscle control." },
            new Exercise { Id = Guid.Parse("dbcf9322-65a8-4c5a-8426-dec86f58e937"), Name = "Cable Triceps Kickback", Description = "Triceps isolation; increases arm muscle tone." },
            new Exercise { Id = Guid.Parse("c8b2002c-8619-4143-820d-1a0e91a51a2d"), Name = "Roman Chair Leg Raise", Description = "Targets lower abs; improves core strength." },
            new Exercise { Id = Guid.Parse("a185c69e-302c-40ac-b194-16547413515b"), Name = "Leg Press", Description = "Works legs and glutes; increases leg power." },
            new Exercise { Id = Guid.Parse("3b94ecc8-e8d6-40de-bc0c-be8afbd79f02"), Name = "Seated Leg Curl", Description = "Targets hamstrings; improves knee flexion." },
            new Exercise { Id = Guid.Parse("d615e2cc-99eb-4227-805b-a3dd834b732d"), Name = "DB Bulgarian Split Squat", Description = "Works quads and glutes; enhances balance." },
            new Exercise { Id = Guid.Parse("84e2a93d-bdf4-4e88-826d-7d0453bd82b6"), Name = "Machine Hip Adduction", Description = "Targets inner thigh muscles; improves hip stability." },
            new Exercise { Id = Guid.Parse("c3324199-e791-48bb-9b79-84e794ab3530"), Name = "Machine Hip Abduction", Description = "Works outer thigh muscles; enhances hip strength." },
            new Exercise { Id = Guid.Parse("42052304-e86b-41be-8382-080ce288b853"), Name = "EZ-Bar Cable Curl", Description = "Biceps focused cable curl; builds arm strength." }
        };
    }
}

