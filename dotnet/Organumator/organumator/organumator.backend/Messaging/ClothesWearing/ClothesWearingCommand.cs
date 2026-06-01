namespace organumator.Messaging.ClothesWearing
{
    public class ClothesWearingCommand
    {
        public string Action { get; set; } = string.Empty;
        public Models.ClothesWearing? Payload { get; set; }
        public int? Id { get; set; }
    }
}
