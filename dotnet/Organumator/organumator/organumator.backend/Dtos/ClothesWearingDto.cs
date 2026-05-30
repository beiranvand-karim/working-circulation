namespace organumator.Dtos
{
    public class ClothesWearingDto
    {
        public int Id { get; set; }
        public string Differentiator { get; set; } = string.Empty;
        public DateTime WearingStart { get; set; }
        public DateTime? WearingFinish { get; set; }
    }
}
