namespace organumator.Messaging
{
    public class RabbitMqSettings
    {
        public string Host { get; set; } = "localhost";
        public int Port { get; set; } = 5672;
        public string Username { get; set; } = "guest";
        public string Password { get; set; } = "guest";
        public string VirtualHost { get; set; } = "/";
        public string ExchangeName { get; set; } = "organumator-dev";
        public string QueueName { get; set; } = "organumator-dev.events";
        public string CommandQueueName { get; set; } = "organumator-dev.vacuum-cleanings.commands";
        public string ClothesWearingCommandQueueName { get; set; } = "organumator-dev.clothes-wearing.commands";
    }
}