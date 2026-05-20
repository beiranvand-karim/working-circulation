using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace EDA_Inventory.RabbitMQ
{
    public class RabbitMqPublisher : IRabbitMqPublisher
    {
        private readonly IConnection _connection;
        private readonly IChannel _channel;

        private RabbitMqPublisher(IConnection connection, IChannel channel)
        {
            _connection = connection;
            _channel = channel;
        }

        public static async Task<RabbitMqPublisher> CreateAsync(string hostName = "localhost")
        {
            var factory = new ConnectionFactory { HostName = hostName };
            var connection = await factory.CreateConnectionAsync();
            var channel = await connection.CreateChannelAsync();
            return new RabbitMqPublisher(connection, channel);
        }

        public async Task PublishAsync<T>(string exchange, string routingKey, T message)
        {
            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
            await _channel.BasicPublishAsync(exchange, routingKey, body);
        }

        public async ValueTask DisposeAsync()
        {
            await _channel.DisposeAsync();
            await _connection.DisposeAsync();
        }
    }
}
