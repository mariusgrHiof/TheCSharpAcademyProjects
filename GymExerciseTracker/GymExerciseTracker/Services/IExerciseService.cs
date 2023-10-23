using GymExerciseTracker.Models;

namespace GymExerciseTracker.Services
{
    public interface IExerciseService
    {
        List<GymSession> GetGymSessions();
    }
}