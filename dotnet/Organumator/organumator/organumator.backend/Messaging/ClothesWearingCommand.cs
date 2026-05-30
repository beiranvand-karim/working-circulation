using organumator.Models;

namespace organumator.Messaging
{
    public class ClothesWearingCommand
    {
        public string Action { get; set; } = string.Empty;
        public ClothesWearing? Payload { get; set; }
        public int? Id { get; set; }
    }
}
