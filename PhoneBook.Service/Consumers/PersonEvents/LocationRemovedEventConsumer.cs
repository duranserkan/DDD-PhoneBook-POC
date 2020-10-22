using MassTransit;
using PhoneBook.Contract.Events;
using PhoneBook.Domain.PersonAggregate.Events;
using System.Threading.Tasks;

namespace PhoneBook.Service.Consumers.PersonEvents
{
	public class LocationRemovedEventConsumer : IConsumer<LocationRemovedEvent>
	{
		public async Task Consume(ConsumeContext<LocationRemovedEvent> context)
		{
			var personRemovedFromLocation = new PersonRemovedFromLocationEvent(
				context.Message.PersonId,
				context.Message.ContactId);

			await context.Publish(personRemovedFromLocation);
		}
	}
}
