namespace organumator.Models
{
    public class CalciferolTakingModel
    {
        public int Id { get; set; }
        public DateTime PerformedOnDate { get; set; } = DateTime.Now;
    }
}