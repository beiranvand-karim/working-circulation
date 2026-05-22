
namespace organumator.Models
{
    public class VacuumCleanings
    {
        public int Id { get; set; }
        public DateTime PerformedOnDate { get; set; } = DateTime.Now;
    }
}