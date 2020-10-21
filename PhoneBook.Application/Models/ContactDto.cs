using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhoneBook.Domain.ContactAggregate;
using PhoneBook.Domain.PersonAggregate;

namespace PhoneBook.Application.Models
{
	public class ContactDto
	{
		public string Content { get; set; }
		public ContactType ContactType { get; set; }
		public Guid Id { get; set; }

		public static ContactDto MapFrom(Contact contact)
		{
			if (contact == null) return null;

			return new ContactDto
			{
				Content = contact.Content,
				ContactType = contact.ContactType,
				Id = contact.Id
			};
		}

		public static IReadOnlyList<ContactDto> MapFrom(IReadOnlyList<Contact> contact) => contact.Select(MapFrom).ToArray();
	}
}
