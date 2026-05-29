namespace organumator.Dtos
{
    public class CleanupDaySummaryDto
    {
        public DateOnly Date { get; set; }
        public int Count { get; set; }
        public long TotalDurationSeconds { get; set; }
    }
}
