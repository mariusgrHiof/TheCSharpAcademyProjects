namespace CodingTracker.Models
{
    public class CodingSession
    {

        public int Id { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }



        public CodingSession(string startTime, string endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }


        public Duration? CalculateDuration()
        {
            try
            {
                TimeSpan timeSpan = DateTime.Parse(EndTime) - DateTime.Parse(StartTime);

                return new Duration
                {
                    Hours = timeSpan.Hours,
                    Minutes = timeSpan.Minutes,
                };
            }
            catch (Exception ex)
            {

                Console.WriteLine("Unable to parse date");

            }


            return null;


        }

    }
}
