using organumator.Models;

namespace organumator.Messaging
{
    public class VacuumCleaningsCommand
    {
        public string Action { get; set; } = string.Empty; // "Create", "Update", "Delete"
        public VacuumCleanings? Payload { get; set; }
        public int? Id { get; set; }
    }
}
