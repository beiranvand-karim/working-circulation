namespace organumator.Models
{
    public class LivergolPillTakingModel
    {
        public int Id { get; set; }
        public DateTime PerformedOnDate { get; set; } = DateTime.Now;        
    }
}