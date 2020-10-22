using System;
using System.Threading.Tasks;
using MassTransit;
using PhoneBook.Domain.PersonAggregate.Events;

namespace PhoneBook.Service.Consumers.PersonEvents
{
	public class PersonDeletedEventConsumer:IConsumer<PersonDeletedEvent>
	{
		public Task Consume(ConsumeContext<PersonDeletedEvent> context)
		{
			throw new NotImplementedException();
		}
	}
}
