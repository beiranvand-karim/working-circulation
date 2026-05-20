using RabbitMQ.Client;

namespace EDA_Inventory.RabbitMQ
{
    public class RabbitMqUtils : IRabbitMqUtils
    {
        public async Task DeclareExchangeAsync(IChannel channel, string exchange, string type = ExchangeType.Topic)
        {
            await channel.ExchangeDeclareAsync(exchange, type, durable: true, autoDelete: false);
        }

        public async Task DeclareQueueAsync(IChannel channel, string queue)
        {
            await channel.QueueDeclareAsync(queue, durable: true, exclusive: false, autoDelete: false);
        }

        public async Task BindQueueAsync(IChannel channel, string queue, string exchange, string routingKey)
        {
            await channel.QueueBindAsync(queue, exchange, routingKey);
        }
    }
}
