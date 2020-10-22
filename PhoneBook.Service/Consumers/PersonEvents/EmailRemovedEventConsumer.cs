using System;
using System.Threading.Tasks;
using MassTransit;
using PhoneBook.Domain.PersonAggregate.Events;

namespace PhoneBook.Service.Consumers.PersonEvents
{
	public class EmailRemovedEventConsumer:IConsumer<EmailRemovedEvent>
	{
		public async Task Consume(ConsumeContext<EmailRemovedEvent> context)
		{
			throw new NotImplementedException();
		}
	}
}
