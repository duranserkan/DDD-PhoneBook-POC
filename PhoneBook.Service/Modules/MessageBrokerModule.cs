using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Service.Consumers.ContactEvents;
using PhoneBook.Service.Consumers.PersonEvents;

namespace PhoneBook.Service.Modules
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
						cfg.ReceiveEndpoint("ContactCreatedEventConsumerQueue", e =>
						{
							e.ConfigureConsumer<ContactCreatedEventConsumer>(context);
						});
						cfg.ReceiveEndpoint("ContactDeletedEventConsumerQueue", e =>
						{
							e.ConfigureConsumer<ContactDeletedEventConsumer>(context);
						});
						cfg.ReceiveEndpoint("PersonCreatedEventConsumerQueue", e =>
						{
							e.ConfigureConsumer<PersonCreatedEventConsumer>(context);
						});
						cfg.ReceiveEndpoint("PersonDeletedEventConsumerQueue", e =>
						{
							e.ConfigureConsumer<PersonDeletedEventConsumer>(context);
						});
						cfg.ReceiveEndpoint("PhoneAddedEventConsumerQueue", e =>
						{
							e.ConfigureConsumer<PhoneAddedEventConsumer>(context);
						});
						cfg.ReceiveEndpoint("PhoneRemovedEventConsumerQueue", e =>
						{
							e.ConfigureConsumer<PhoneRemovedEventConsumer>(context);
						});
						cfg.ReceiveEndpoint("EmailAddedEventConsumerQueue", e =>
						{
							e.ConfigureConsumer<EmailAddedEventConsumer>(context);
						});
						cfg.ReceiveEndpoint("EmailRemovedEventConsumerQueue", e =>
						{
							e.ConfigureConsumer<EmailRemovedEventConsumer>(context);
						});
						cfg.ReceiveEndpoint("LocationAddedEventConsumerQueue", e =>
						{
							e.ConfigureConsumer<LocationAddedEventConsumer>(context);
						});
						cfg.ReceiveEndpoint("LocationRemovedEventConsumerQueue", e =>
						{
							e.ConfigureConsumer<LocationRemovedEventConsumer>(context);
						});
					});

					return busControl;
				});

				serviceCollectionConfigurator.AddConsumers(typeof(PersonCreatedEventConsumer).Assembly);
			});
		}
	}
}
