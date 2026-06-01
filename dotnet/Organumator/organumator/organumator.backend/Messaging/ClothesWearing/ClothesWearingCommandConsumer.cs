using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using organumator.Interfaces;
using organumator.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace organumator.Messaging.ClothesWearing
{
    public class ClothesWearingCommandConsumer : BackgroundService
    {
        private readonly RabbitMqSettings _settings;
        private readonly ILogger<ClothesWearingCommandConsumer> _logger;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IRabbitMqPublisher _publisher;
        private IConnection? _connection;
        private IModel? _channel;

        private readonly string _queueName;

        public ClothesWearingCommandConsumer(
            IOptions<RabbitMqSettings> options,
            ILogger<ClothesWearingCommandConsumer> logger,
            IServiceScopeFactory scopeFactory,
            IRabbitMqPublisher publisher)
        {
            _settings = options.Value;
            _logger = logger;
            _scopeFactory = scopeFactory;
            _publisher = publisher;
            _queueName = _settings.ClothesWearingCommandQueueName;
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
            _channel.QueueDeclare(_queueName, durable: true, exclusive: false, autoDelete: false);
            _channel.QueueBind(_queueName, _settings.ExchangeName, routingKey: _queueName);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (_, ea) =>
            {
                var command = JsonSerializer.Deserialize<ClothesWearingCommand>(
                    Encoding.UTF8.GetString(ea.Body.ToArray()));

                if (command is null)
                {
                    _channel.BasicNack(ea.DeliveryTag, multiple: false, requeue: false);
                    return;
                }

                using var scope = _scopeFactory.CreateScope();
                var repository = scope.ServiceProvider.GetRequiredService<IClothesWearingRepository>();

                try
                {
                    await (command.Action switch
                    {
                        "Create" => HandleCreate(command, repository, ea.BasicProperties),
                        "Update" => HandleUpdate(command, repository),
                        "Delete" => HandleDelete(command, repository),
                        "GetAll" => HandleGetAll(repository, ea.BasicProperties),
                        "GetById" => HandleGetById(command, repository, ea.BasicProperties),
                        _ => Task.CompletedTask
                    });

                    _channel.BasicAck(ea.DeliveryTag, multiple: false);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to process ClothesWearing command: {Action}", command.Action);
                    _channel.BasicNack(ea.DeliveryTag, multiple: false, requeue: true);
                }
            };

            _channel.BasicConsume(_queueName, autoAck: false, consumer: consumer);
            return Task.CompletedTask;
        }

        private async Task HandleCreate(ClothesWearingCommand command, IClothesWearingRepository repository, IBasicProperties props)
        {
            if (command.Payload is null) return;
            var created = await repository.AddClothesWearingAsync(command.Payload);
            _publisher.Publish(new EventMessage
            {
                EntityName = nameof(ClothesWearing),
                Action = "Created",
                Payload = created
            });
            Reply(created, props);
            _logger.LogInformation("ClothesWearing created: {Id}", created.Id);
        }

        private async Task HandleUpdate(ClothesWearingCommand command, IClothesWearingRepository repository)
        {
            if (command.Payload is null) return;
            var updated = await repository.UpdateClothesWearingAsync(command.Payload);
            _publisher.Publish(new EventMessage
            {
                EntityName = nameof(ClothesWearing),
                Action = "Updated",
                Payload = updated
            });
            _logger.LogInformation("ClothesWearing updated: {Id}", updated.Id);
        }

        private async Task HandleDelete(ClothesWearingCommand command, IClothesWearingRepository repository)
        {
            if (!command.Id.HasValue) return;
            await repository.DeleteClothesWearingAsync(command.Id.Value);
            _publisher.Publish(new EventMessage
            {
                EntityName = nameof(ClothesWearing),
                Action = "Deleted",
                Payload = new { Id = command.Id.Value }
            });
            _logger.LogInformation("ClothesWearing deleted: {Id}", command.Id.Value);
        }

        private async Task HandleGetAll(IClothesWearingRepository repository, IBasicProperties props)
        {
            var all = await repository.GetAllClothesWearingsAsync();
            Reply(all, props);
        }

        private async Task HandleGetById(ClothesWearingCommand command, IClothesWearingRepository repository, IBasicProperties props)
        {
            if (!command.Id.HasValue) { Reply<Models.ClothesWearing?>(null, props); return; }
            try
            {
                var item = await repository.GetClothesWearingByIdAsync(command.Id.Value);
                Reply(item, props);
            }
            catch (Exception)
            {
                Reply<Models.ClothesWearing?>(null, props);
            }
        }

        private void Reply<T>(T result, IBasicProperties requestProps)
        {
            if (requestProps.ReplyTo is null) return;
            var replyProps = _channel!.CreateBasicProperties();
            replyProps.CorrelationId = requestProps.CorrelationId;
            _channel.BasicPublish("", requestProps.ReplyTo, replyProps,
                Encoding.UTF8.GetBytes(JsonSerializer.Serialize(result)));
        }

        public override void Dispose()
        {
            _channel?.Close();
            _connection?.Close();
            base.Dispose();
        }
    }
}
