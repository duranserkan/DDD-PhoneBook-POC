using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PhoneBook.Api.Modules
{
	public static class MessageBrokerModule
	{
		public static void AddRabbitMq(this IServiceCollection serviceCollection, IConfiguration configuration)
		{
			serviceCollection.AddMassTransitHostedService();
			serviceCollection.AddMassTransit(serviceCollectionConfigurator =>
			{
				var settings = configuration.GetSection("RabbitMqSettings");
				var uri = settings.GetValue<string>("Uri");
				var userName = settings.GetValue<string>("UserName");
				var password = settings.GetValue<string>("Password");
				
				serviceCollectionConfigurator.AddBus(context =>
				{
					var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
					{
						cfg.Host(uri, "/", h =>
						{
							h.Username(userName);
							h.Password(password);
						});
					});

					return busControl;
				});
			});
		}
	}
}
