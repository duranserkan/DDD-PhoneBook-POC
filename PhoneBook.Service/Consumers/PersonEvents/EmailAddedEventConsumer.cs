using System;
using System.Threading.Tasks;
using MassTransit;
using PhoneBook.Domain.PersonAggregate.Events;

namespace PhoneBook.Service.Consumers.PersonEvents
{
	public class EmailAddedEventConsumer : IConsumer<EmailAddedEvent>
	{
		public async Task Consume(ConsumeContext<EmailAddedEvent> context)
		{
			throw new NotImplementedException();
		}
	}
}
