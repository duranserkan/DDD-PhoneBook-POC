using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Application.Services;
using PhoneBook.Domain.ContactAggregate;
using PhoneBook.Domain.PersonAggregate;
using PhoneBook.Infrastructure.Repositories;
using SharedKernel.Interfaces;

namespace PhoneBook.Api.Modules
{
	public static class ApplicationModule
	{
		public static void AddApplicationServices(this IServiceCollection serviceCollection)
		{
			serviceCollection.AddTransient<IPersonService, PersonService>();
			serviceCollection.AddTransient<IPersonRepository, PersonRepository>();
			serviceCollection.AddTransient<IContactService, ContactService>();
			serviceCollection.AddTransient<IContactRepository, ContactRepository>();
			serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
		}
	}
}
