using System;
using System.Threading.Tasks;
using MassTransit;
using PhoneBook.Domain.PersonAggregate.Events;

namespace PhoneBook.Service.Consumers.PersonEvents
{
	public class PhoneRemovedEventConsumer : IConsumer<PhoneRemovedEvent>
	{
		public Task Consume(ConsumeContext<PhoneRemovedEvent> context)
		{
			throw new NotImplementedException();
		}
	}
}
