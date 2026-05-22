using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace organumator.Messaging
{
    public class RabbitMqConsumer : BackgroundService
    {
        private readonly RabbitMqSettings _settings;
        private readonly ILogger<RabbitMqConsumer> _logger;
        private IConnection? _connection;
        private IModel? _channel;

        public RabbitMqConsumer(IOptions<RabbitMqSettings> options, ILogger<RabbitMqConsumer> logger)
        {
            _settings = options.Value;
            _logger = logger;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory
            {
                HostName = _settings.Host,
                Port = _settings.Port,
                UserName = _settings.Username,
                Password = _settings.Password,
                VirtualHost = _settings.VirtualHost
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(_settings.ExchangeName, ExchangeType.Direct, durable: true);
            _channel.QueueDeclare(_settings.QueueName, durable: true, exclusive: false, autoDelete: false);
            _channel.QueueBind(_settings.QueueName, _settings.ExchangeName, routingKey: _settings.QueueName);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (_, ea) =>
            {
                var body = Encoding.UTF8.GetString(ea.Body.ToArray());
                var message = JsonSerializer.Deserialize<EventMessage>(body);
                _logger.LogInformation(
                    "Received: {Action} on {Entity} at {OccurredAt}",
                    message?.Action, message?.EntityName, message?.OccurredAt);
                _channel.BasicAck(ea.DeliveryTag, multiple: false);
            };

            _channel.BasicConsume(_settings.QueueName, autoAck: false, consumer: consumer);

            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            _channel?.Close();
            _connection?.Close();
            base.Dispose();
        }
    }
}
