using System;
using PhoneBook.Domain.ContactAggregate;

namespace PhoneBook.Contract.Requests.Contact
{
	public class PostContactRequest
	{
		public string Content { get; set; }
		public ContactType ContactType { get; set; }
	}
}
