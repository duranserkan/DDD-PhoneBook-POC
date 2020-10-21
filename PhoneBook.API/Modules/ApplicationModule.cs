using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Application.Services;
using PhoneBook.Domain.PersonAggregate;
using PhoneBook.Infrastructure.Repositories;

namespace PhoneBook.Api.Modules
{
	public static class ApplicationModule
	{
		public static void AddApplicationServices(this IServiceCollection serviceCollection)
		{
			serviceCollection.AddTransient<IPersonService, PersonService>();
			serviceCollection.AddTransient<IPersonRepository, PersonRepository>();
		}
	}
}
