using MassTransit;
using PhoneBook.Domain.ContactAggregate.Events;
using System;
using System.Threading.Tasks;

namespace PhoneBook.Service.Consumers.ContactEvents
{
	public class ContactDeletedEventConsumer:IConsumer<ContactDeleted>
	{
		public Task Consume(ConsumeContext<ContactDeleted> context)
		{
			throw new NotImplementedException();
		}
	}
}
