namespace ShiftsLogger.API.DTOs.Shift
{
    public class UpdateShiftDTO
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public int WorkerId { get; set; }


    }
}
