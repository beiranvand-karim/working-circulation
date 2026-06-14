using organumator.Messaging;
using organumator.Messaging.ClothesWearing;
using organumator.Messaging.VacuumCleanings;

namespace organumator.Extensions
{
    public static class MessagingServiceExtensions
    {
        public static IServiceCollection AddMessaging(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RabbitMqSettings>(configuration.GetSection("RabbitMQ"));

            var rabbitMqEnabled = configuration.GetValue<bool>("RabbitMQ:Enabled");

            if (rabbitMqEnabled)
            {
                services.AddSingleton<IRabbitMqPublisher, RabbitMqPublisher>();
                services.AddHostedService<RabbitMqConsumer>();
                services.AddHostedService<VacuumCleaningsCommandConsumer>();
                services.AddHostedService<ClothesWearingCommandConsumer>();
            }
            else
            {
                services.AddSingleton<IRabbitMqPublisher, NullRabbitMqPublisher>();
            }

            return services;
        }
    }
}
