using MassTransit;
using PhoneBook.Domain.PersonAggregate.Events;
using System;
using System.Threading.Tasks;

namespace PhoneBook.Service.Consumers.PersonEvents
{
	public class LocationRemovedEventConsumer : IConsumer<LocationRemovedEvent>
	{
		public Task Consume(ConsumeContext<LocationRemovedEvent> context)
		{
			throw new NotImplementedException();
		}
	}
}
