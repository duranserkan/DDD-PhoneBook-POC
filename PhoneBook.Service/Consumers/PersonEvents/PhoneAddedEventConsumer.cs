using System;
using System.Threading.Tasks;
using MassTransit;
using PhoneBook.Domain.PersonAggregate.Events;

namespace PhoneBook.Service.Consumers.PersonEvents
{
	public class PhoneAddedEventConsumer : IConsumer<PhoneAddedEvent>
	{
		public Task Consume(ConsumeContext<PhoneAddedEvent> context)
		{
			throw new NotImplementedException();
		}
	}
}
