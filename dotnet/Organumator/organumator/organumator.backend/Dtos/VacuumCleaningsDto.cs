namespace organumator.Dtos
{
    public class VacuumCleaningsDto
    {
        public int Id { get; set; }
        public DateTime PerformedOnDate { get; set; } = DateTime.Now;
    }
}