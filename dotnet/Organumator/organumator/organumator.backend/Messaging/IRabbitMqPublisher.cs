namespace organumator.Messaging
{
    public interface IRabbitMqPublisher
    {
        void Publish(EventMessage message);
        void PublishCommand(VacuumCleaningsCommand command);
        Task<T?> QueryAsync<T>(VacuumCleaningsCommand command, TimeSpan? timeout = null);
    }
}
