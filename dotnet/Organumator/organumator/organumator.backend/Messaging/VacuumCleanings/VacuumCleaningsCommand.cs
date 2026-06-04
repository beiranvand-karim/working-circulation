namespace organumator.Messaging.VacuumCleanings
{
    public class VacuumCleaningsCommand
    {
        public string Action { get; set; } = string.Empty;
        public Models.VacuumCleanings? Payload { get; set; }
        public int? Id { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 8;
    }
}
