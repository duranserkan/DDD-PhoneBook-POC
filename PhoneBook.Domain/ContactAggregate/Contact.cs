using SharedKernel;
using SharedKernel.Interfaces;
using System;

namespace PhoneBook.Domain.ContactAggregate
{

	public class Contact : Entity, IAggregateRoot
	{
		public Contact(ContactType contactType, string content)
		{
			if (!Enum.IsDefined(typeof(ContactType), contactType))
				throw new ArgumentException("Contact type must be defined");
			ContactType = contactType;
			if (string.IsNullOrWhiteSpace(content))
				throw new ArgumentException("Content can not be empty or whitespace");
			Content = content;
		}
		public ContactType ContactType { get; set; }
		public string Content { get; set; }
	}
}
