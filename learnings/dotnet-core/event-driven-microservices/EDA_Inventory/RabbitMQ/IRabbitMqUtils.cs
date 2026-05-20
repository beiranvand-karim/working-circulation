using RabbitMQ.Client;

namespace EDA_Inventory.RabbitMQ
{
    public interface IRabbitMqUtils
    {
        Task DeclareExchangeAsync(IChannel channel, string exchange, string type);
        Task DeclareQueueAsync(IChannel channel, string queue);
        Task BindQueueAsync(IChannel channel, string queue, string exchange, string routingKey);
    }
}
