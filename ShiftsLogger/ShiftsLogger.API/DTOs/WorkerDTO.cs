namespace ShiftsLogger.API.DTOs
{
    public class WorkerDTO
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public ICollection<ShiftDTO> Shifts { get; set; }
    }
}