namespace organumator.Messaging
{
    public class EventMessage
    {
        public string EntityName { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public object? Payload { get; set; }
        public DateTime OccurredAt { get; set; } = DateTime.UtcNow;
    }
}
