namespace organumator.Messaging
{
    /// <summary>
    /// No-op publisher used when RabbitMQ is disabled (e.g. in environments without a broker).
    /// Lets components that depend on <see cref="IRabbitMqPublisher"/> resolve without a connection.
    /// </summary>
    public class NullRabbitMqPublisher : IRabbitMqPublisher
    {
        public void Publish(EventMessage message) { }

        public void PublishCommand(object command, string routingKey) { }

        public Task<T?> QueryAsync<T>(object command, string routingKey, TimeSpan? timeout = null) =>
            Task.FromResult<T?>(default);
    }
}
