namespace organumator.Messaging
{
    public interface IRabbitMqPublisher
    {
        void Publish(EventMessage message);
        void PublishCommand(VacuumCleaningsCommand command);
        Task<T?> QueryAsync<T>(VacuumCleaningsCommand command, TimeSpan? timeout = null);
        void PublishCommand(object command, string routingKey);
        Task<T?> QueryAsync<T>(object command, string routingKey, TimeSpan? timeout = null);
    }
}
