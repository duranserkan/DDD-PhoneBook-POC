using System.Threading.Tasks;
using MassTransit;
using PhoneBook.Domain.PersonAggregate.Events;

namespace PhoneBook.Service.Consumers.PersonEvents
{
	public class PersonCreatedEventConsumer : IConsumer<PersonCreatedEvent>
	{
		public Task Consume(ConsumeContext<PersonCreatedEvent> context)
		{
			throw new System.NotImplementedException();
		}
	}
}
