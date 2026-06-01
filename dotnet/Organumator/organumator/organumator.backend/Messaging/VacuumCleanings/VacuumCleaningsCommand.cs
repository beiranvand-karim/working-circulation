namespace organumator.Messaging.VacuumCleanings
{
    public class VacuumCleaningsCommand
    {
        public string Action { get; set; } = string.Empty; // "Create", "Update", "Delete"
        public Models.VacuumCleanings? Payload { get; set; }
        public int? Id { get; set; }
    }
}
