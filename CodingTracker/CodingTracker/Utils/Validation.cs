using System.Globalization;

namespace CodingTracker.Utils
{
    public static class Validation
    {
        public static bool ValidateDate(string date)
        {
            return DateTime.TryParseExact(date, "dd/MM/yyyy HH:mm", new CultureInfo("nb-NO"), DateTimeStyles.None, out _);
        }
    }
}
