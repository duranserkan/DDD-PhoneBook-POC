using System;
using SharedKernel;

namespace PhoneBook.Domain.PersonAggregate.Events
{
	public class PersonCreated : DomainEvent
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string CompanyName { get; set; }
	}
}
