namespace organumator.Models
{
    public class ClothesWearing
    {
        public int Id { get; set; }
        public string Differentiator { get; set; } = string.Empty;
        public DateTime WearingStart { get; set; }
        public DateTime? WearingFinish { get; set; }
    }
}
