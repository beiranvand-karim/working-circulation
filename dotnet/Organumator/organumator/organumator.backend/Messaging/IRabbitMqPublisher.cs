namespace organumator.Messaging
{
    public interface IRabbitMqPublisher
    {
        void Publish(EventMessage message);
        void PublishCommand(object command, string routingKey);
        Task<T?> QueryAsync<T>(object command, string routingKey, TimeSpan? timeout = null);
    }
}
