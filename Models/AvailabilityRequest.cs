namespace DMS_3.Models
{
    public class AvailabilityRequest
    {
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
