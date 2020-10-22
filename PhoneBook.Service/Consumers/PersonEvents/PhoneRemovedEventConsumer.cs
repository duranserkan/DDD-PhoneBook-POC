using MassTransit;
using PhoneBook.Application.Services;
using PhoneBook.Contract.Events;
using PhoneBook.Domain.PersonAggregate.Events;
using System.Threading.Tasks;

namespace PhoneBook.Service.Consumers.PersonEvents
{
	public class PhoneRemovedEventConsumer : IConsumer<PhoneRemovedEvent>
	{
		private readonly IPersonService _personService;

		public PhoneRemovedEventConsumer(IPersonService personService)
		{
			_personService = personService;
		}

		public async Task Consume(ConsumeContext<PhoneRemovedEvent> context)
		{
			var person = await _personService.GetPersonAsync(context.Message.PersonId);
			if (person.LocationId == null) return;

			var phoneJoinedLocation = new PhoneRemovedFromLocationEvent(
				context.Message.ContactId,
				person.LocationId.Value);

			await context.Publish(phoneJoinedLocation);
		}
	}
}
