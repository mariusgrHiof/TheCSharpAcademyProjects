using GymExerciseTracker.Services;

namespace GymExerciseTracker.Utils;
public class Validate
{
    static private readonly IExerciseService _exerciseService;


    public static bool IsValidNumber(string number)
    {
        return int.TryParse(number, out _);
    }

    public static bool IsValidId(string inputId)
    {
        if (!IsValidNumber(inputId)) return false;


        int id = int.Parse(inputId);

        var session = _exerciseService.GetGymSession(id);

        return session != null;
    }

    public static bool IsValidString(string name)
    {
        return !string.IsNullOrWhiteSpace(name);

    }
}

