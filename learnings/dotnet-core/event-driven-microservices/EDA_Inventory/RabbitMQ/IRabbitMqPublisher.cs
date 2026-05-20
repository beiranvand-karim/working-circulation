namespace EDA_Inventory.RabbitMQ
{
    public interface IRabbitMqPublisher : IAsyncDisposable
    {
        Task PublishAsync<T>(string exchange, string routingKey, T message);
    }
}
