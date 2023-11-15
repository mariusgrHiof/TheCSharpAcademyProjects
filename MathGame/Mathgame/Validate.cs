namespace Mathgame;

public static class Validate
{
    public static bool IsValidNumber(string number)
    {
        return int.TryParse(number, out _);
    }

}

