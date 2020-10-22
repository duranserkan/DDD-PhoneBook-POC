using System;
using System.Threading.Tasks;
using MassTransit;
using PhoneBook.Domain.PersonAggregate.Events;

namespace PhoneBook.Service.Consumers.PersonEvents
{
	public class LocationAddedEventConsumer : IConsumer<LocationAddedEvent>
	{
		public Task Consume(ConsumeContext<LocationAddedEvent> context)
		{
			throw new NotImplementedException();
		}
	}
}
