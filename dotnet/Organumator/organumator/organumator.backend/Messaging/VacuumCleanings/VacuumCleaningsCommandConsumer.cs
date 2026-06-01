using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using organumator.Interfaces;
using organumator.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace organumator.Messaging.VacuumCleanings
{
    public class VacuumCleaningsCommandConsumer : BackgroundService
    {
        private readonly RabbitMqSettings _settings;
        private readonly ILogger<VacuumCleaningsCommandConsumer> _logger;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IRabbitMqPublisher _publisher;
        private IConnection? _connection;
        private IModel? _channel;

        public VacuumCleaningsCommandConsumer(
            IOptions<RabbitMqSettings> options,
            ILogger<VacuumCleaningsCommandConsumer> logger,
            IServiceScopeFactory scopeFactory,
            IRabbitMqPublisher publisher)
        {
            _settings = options.Value;
            _logger = logger;
            _scopeFactory = scopeFactory;
            _publisher = publisher;
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
            _channel.QueueDeclare(_settings.CommandQueueName, durable: true, exclusive: false, autoDelete: false);
            _channel.QueueBind(_settings.CommandQueueName, _settings.ExchangeName, routingKey: _settings.CommandQueueName);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (_, ea) =>
            {
                var command = JsonSerializer.Deserialize<VacuumCleaningsCommand>(
                    Encoding.UTF8.GetString(ea.Body.ToArray()));

                if (command is null)
                {
                    _channel.BasicNack(ea.DeliveryTag, multiple: false, requeue: false);
                    return;
                }

                using var scope = _scopeFactory.CreateScope();
                var repository = scope.ServiceProvider.GetRequiredService<IVacuumCleaningsRepository>();

                try
                {
                    await (command.Action switch
                    {
                        "Create"  => HandleCreate(command, repository, ea.BasicProperties),
                        "Update"  => HandleUpdate(command, repository),
                        "Delete"  => HandleDelete(command, repository),
                        "GetAll"  => HandleGetAll(repository, ea.BasicProperties),
                        "GetById" => HandleGetById(command, repository, ea.BasicProperties),
                        _         => Task.CompletedTask
                    });

                    _channel.BasicAck(ea.DeliveryTag, multiple: false);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to process VacuumCleanings command: {Action}", command.Action);
                    _channel.BasicNack(ea.DeliveryTag, multiple: false, requeue: true);
                }
            };

            _channel.BasicConsume(_settings.CommandQueueName, autoAck: false, consumer: consumer);
            return Task.CompletedTask;
        }

        private async Task HandleCreate(VacuumCleaningsCommand command, IVacuumCleaningsRepository repository, IBasicProperties props)
        {
            if (command.Payload is null) return;
            var created = await repository.AddVacuumCleaningsAsync(command.Payload);
            _publisher.Publish(new EventMessage
            {
                EntityName = nameof(Models.VacuumCleanings),
                Action = "Created",
                Payload = created
            });
            Reply(created, props);
            _logger.LogInformation("VacuumCleanings created: {Id}", created.Id);
        }

        private async Task HandleUpdate(VacuumCleaningsCommand command, IVacuumCleaningsRepository repository)
        {
            if (command.Payload is null) return;
            var updated = await repository.UpdateVacuumCleaningsAsync(command.Payload);
            _publisher.Publish(new EventMessage
            {
                EntityName = nameof(Models.VacuumCleanings),
                Action = "Updated",
                Payload = updated
            });
            _logger.LogInformation("VacuumCleanings updated: {Id}", updated.Id);
        }

        private async Task HandleDelete(VacuumCleaningsCommand command, IVacuumCleaningsRepository repository)
        {
            if (!command.Id.HasValue) return;
            await repository.DeleteVacuumCleaningsAsync(command.Id.Value);
            _publisher.Publish(new EventMessage
            {
                EntityName = nameof(Models.VacuumCleanings),
                Action = "Deleted",
                Payload = new { Id = command.Id.Value }
            });
            _logger.LogInformation("VacuumCleanings deleted: {Id}", command.Id.Value);
        }

        private async Task HandleGetAll(IVacuumCleaningsRepository repository, IBasicProperties props)
        {
            var all = await repository.GetAllVacuumCleaningsAsync();
            Reply(all, props);
        }

        private async Task HandleGetById(VacuumCleaningsCommand command, IVacuumCleaningsRepository repository, IBasicProperties props)
        {
            if (!command.Id.HasValue) { Reply<Models.VacuumCleanings?>(null, props); return; }
            try
            {
                var item = await repository.GetVacuumCleaningsByIdAsync(command.Id.Value);
                Reply(item, props);
            }
            catch (Exception)
            {
                Reply<Models.VacuumCleanings?>(null, props);
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
