using MassTransit;
using PhoneBook.Contract.Events;
using PhoneBook.Domain.PersonAggregate.Events;
using System.Threading.Tasks;

namespace PhoneBook.Service.Consumers.PersonEvents
{
	public class LocationAddedEventConsumer : IConsumer<LocationAddedEvent>
	{
		public async Task Consume(ConsumeContext<LocationAddedEvent> context)
		{
			var personJoinedLocation = new PersonJoinedLocationEvent(
				context.Message.PersonId,
				context.Message.ContactId,
				context.Message.Content);

			await context.Publish(personJoinedLocation);
		}
	}
}
