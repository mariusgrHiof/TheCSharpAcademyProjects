namespace CodingTracker.Models
{
    public class CodingSession
    {

        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }



        public CodingSession(DateTime startTime, DateTime endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }


        public Duration CalculateDuration()
        {
            TimeSpan timeSpan = EndTime - StartTime;

            return new Duration
            {
                Hours = timeSpan.Hours,
                Minutes = timeSpan.Minutes,
            };

        }

    }
}
