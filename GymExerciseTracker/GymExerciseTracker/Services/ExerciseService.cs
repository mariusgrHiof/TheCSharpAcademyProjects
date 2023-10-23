using GymExerciseTracker.Models;
using GymExerciseTracker.Repository;

namespace GymExerciseTracker.Services;
public class ExerciseService : IExerciseService
{
    private readonly IExerciseRepository _exerciseRepository;

    public ExerciseService(IExerciseRepository exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }

    public List<GymSession> GetGymSessions()
    {
        return _exerciseRepository.GetAllSessions();
    }
}

