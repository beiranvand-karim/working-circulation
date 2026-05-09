namespace organumator.Dtos
{
    public class BetweenTeethBrushingDto
    {
        public int Id { get; set; }
        public DateTime PerformedOnDate { get; set; } = DateTime.Now;
    }
}