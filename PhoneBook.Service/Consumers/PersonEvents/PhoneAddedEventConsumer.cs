using MassTransit;
using PhoneBook.Contract.Events;
using PhoneBook.Domain.PersonAggregate.Events;
using System.Threading.Tasks;
using PhoneBook.Application.Services;

namespace PhoneBook.Service.Consumers.PersonEvents
{
	public class PhoneAddedEventConsumer : IConsumer<PhoneAddedEvent>
	{
		private readonly IPersonService _personService;

		public PhoneAddedEventConsumer(IPersonService personService)
		{
			_personService = personService;
		}

		public async Task Consume(ConsumeContext<PhoneAddedEvent> context)
		{
			var person = await _personService.GetPersonAsync(context.Message.PersonId);
			if (person.LocationId == null) return;

			var phoneJoinedLocation = new PhoneJoinedLocationEvent(
				context.Message.ContactId,
				person.LocationId.Value);

			await context.Publish(phoneJoinedLocation);
		}
	}
}
