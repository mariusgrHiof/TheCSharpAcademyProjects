using System.Globalization;

namespace CodingTracker.Utils
{
    public static class Validation
    {
        public static bool ValidateDate(string date)
        {
            return DateTime.TryParseExact(date, "dd/MM/yyyy HH:mm", new CultureInfo("nb-NO"), DateTimeStyles.None, out _);
        }

        public static bool ValidateId(string id)
        {
            bool result = false;
            try
            {
                result = Convert.ToInt32(id) > 0;
            }
            catch (Exception)
            {

                Console.WriteLine("invalid id");
            }

            return result;
        }
    }
}
