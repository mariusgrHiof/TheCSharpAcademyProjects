using GymExerciseTracker.Controllers;
using GymExerciseTracker.Data;
using GymExerciseTracker.Models;
using GymExerciseTracker.Repository;
using GymExerciseTracker.Services;

ApplicationDbContext context = new ApplicationDbContext();
ExerciseRepository exerciseRepository = new ExerciseRepository(context);
ExerciseService exerciseService = new ExerciseService(exerciseRepository);
ExerciseController exerciseController = new ExerciseController(exerciseService);

List<GymSession> gymSessions = exerciseController.GetAllGymSessions();

foreach (var gymSession in gymSessions)
{
    Console.WriteLine($"{gymSession.Name}, Sets: {gymSession.Sets}, Reps: {gymSession.Reps}");
}