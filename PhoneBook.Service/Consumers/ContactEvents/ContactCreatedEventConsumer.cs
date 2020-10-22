using MassTransit;
using PhoneBook.Domain.ContactAggregate.Events;
using System.Threading.Tasks;

namespace PhoneBook.Service.Consumers.ContactEvents
{
	public class ContactCreatedEventConsumer : IConsumer<ContactCreated>
	{
		public Task Consume(ConsumeContext<ContactCreated> context)
		{
			throw new System.NotImplementedException();
		}
	}
}
