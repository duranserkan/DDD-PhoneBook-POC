using System;
using SharedKernel;

namespace PhoneBook.Domain.ContactAggregate.Events
{
	public class ContactCreated : DomainEvent
	{
		public Guid Id { get; set; }
		public ContactType ContactType { get; set; }
		public string Content { get; set; }
	}
}
