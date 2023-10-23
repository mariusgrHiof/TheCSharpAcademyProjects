using GymExerciseTracker.Models;
using GymExerciseTracker.Services;

namespace GymExerciseTracker.Controllers;
public class ExerciseController
{
    private readonly IExerciseService _exerciseService;

    public ExerciseController(IExerciseService exerciseService)
    {
        _exerciseService = exerciseService;
    }

    public List<GymSession> GetAllGymSessions()
    {
        return _exerciseService.GetGymSessions();
    }
}

