namespace ShiftsLogger.API.DTOs.Shift
{
    public class ShiftDTO
    {

        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public TimeSpan Duration => End - Start;

        public int WorkerId { get; set; }

    }
}
