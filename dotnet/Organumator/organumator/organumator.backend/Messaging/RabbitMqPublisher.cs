using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace organumator.Messaging
{
    public class RabbitMqPublisher : IRabbitMqPublisher, IDisposable
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly string _exchangeName;
        private readonly string _queueName;
        private readonly string _commandQueueName;

        public RabbitMqPublisher(IOptions<RabbitMqSettings> options)
        {
            var settings = options.Value;
            _exchangeName = settings.ExchangeName;
            _queueName = settings.QueueName;
            _commandQueueName = settings.CommandQueueName;

            var factory = new ConnectionFactory
            {
                HostName = settings.Host,
                Port = settings.Port,
                UserName = settings.Username,
                Password = settings.Password,
                VirtualHost = settings.VirtualHost
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(_exchangeName, ExchangeType.Direct, durable: true);
            _channel.QueueDeclare(_queueName, durable: true, exclusive: false, autoDelete: false);
            _channel.QueueBind(_queueName, _exchangeName, routingKey: _queueName);
            _channel.QueueDeclare(_commandQueueName, durable: true, exclusive: false, autoDelete: false);
            _channel.QueueBind(_commandQueueName, _exchangeName, routingKey: _commandQueueName);
        }

        public void Publish(EventMessage message)
        {
            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
            var properties = _channel.CreateBasicProperties();
            properties.Persistent = true;
            _channel.BasicPublish(_exchangeName, _queueName, properties, body);
        }

        public void PublishCommand(VacuumCleaningsCommand command)
        {
            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(command));
            var properties = _channel.CreateBasicProperties();
            properties.Persistent = true;
            _channel.BasicPublish(_exchangeName, _commandQueueName, properties, body);
        }

        public async Task<T?> QueryAsync<T>(VacuumCleaningsCommand command, TimeSpan? timeout = null)
        {
            var correlationId = Guid.NewGuid().ToString();
            var replyChannel = _connection.CreateModel();
            try
            {
                var replyQueue = replyChannel.QueueDeclare(exclusive: true, autoDelete: true);
                var tcs = new TaskCompletionSource<byte[]>(TaskCreationOptions.RunContinuationsAsynchronously);

                var consumer = new EventingBasicConsumer(replyChannel);
                consumer.Received += (_, ea) =>
                {
                    if (ea.BasicProperties.CorrelationId == correlationId)
                        tcs.TrySetResult(ea.Body.ToArray());
                };
                replyChannel.BasicConsume(replyQueue.QueueName, autoAck: true, consumer);

                var props = _channel.CreateBasicProperties();
                props.CorrelationId = correlationId;
                props.ReplyTo = replyQueue.QueueName;
                _channel.BasicPublish(_exchangeName, _commandQueueName,
                    props, Encoding.UTF8.GetBytes(JsonSerializer.Serialize(command)));

                using var cts = new CancellationTokenSource(timeout ?? TimeSpan.FromSeconds(10));
                cts.Token.Register(() => tcs.TrySetException(new TimeoutException("QueryAsync timed out")));

                return JsonSerializer.Deserialize<T>(await tcs.Task);
            }
            finally
            {
                replyChannel.Close();
                replyChannel.Dispose();
            }
        }

        public void PublishCommand(object command, string routingKey)
        {
            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(command, command.GetType()));
            var properties = _channel.CreateBasicProperties();
            properties.Persistent = true;
            _channel.BasicPublish(_exchangeName, routingKey, properties, body);
        }

        public async Task<T?> QueryAsync<T>(object command, string routingKey, TimeSpan? timeout = null)
        {
            var correlationId = Guid.NewGuid().ToString();
            var replyChannel = _connection.CreateModel();
            try
            {
                var replyQueue = replyChannel.QueueDeclare(exclusive: true, autoDelete: true);
                var tcs = new TaskCompletionSource<byte[]>(TaskCreationOptions.RunContinuationsAsynchronously);

                var consumer = new EventingBasicConsumer(replyChannel);
                consumer.Received += (_, ea) =>
                {
                    if (ea.BasicProperties.CorrelationId == correlationId)
                        tcs.TrySetResult(ea.Body.ToArray());
                };
                replyChannel.BasicConsume(replyQueue.QueueName, autoAck: true, consumer);

                var props = _channel.CreateBasicProperties();
                props.CorrelationId = correlationId;
                props.ReplyTo = replyQueue.QueueName;
                _channel.BasicPublish(_exchangeName, routingKey,
                    props, Encoding.UTF8.GetBytes(JsonSerializer.Serialize(command, command.GetType())));

                using var cts = new CancellationTokenSource(timeout ?? TimeSpan.FromSeconds(10));
                cts.Token.Register(() => tcs.TrySetException(new TimeoutException("QueryAsync timed out")));

                return JsonSerializer.Deserialize<T>(await tcs.Task);
            }
            finally
            {
                replyChannel.Close();
                replyChannel.Dispose();
            }
        }

        public void Dispose()
        {
            _channel?.Close();
            _connection?.Close();
        }
    }
}
