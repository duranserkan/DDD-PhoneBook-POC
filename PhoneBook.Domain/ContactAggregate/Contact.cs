using SharedKernel;
using SharedKernel.Interfaces;
using System;

namespace PhoneBook.Domain.ContactAggregate
{

	public class Contact : Entity, IAggregateRoot
	{
		public ContactType ContactType { get; set; }
		public string Content { get; set; }
	}
}
