using System;
using PhoneBook.Domain.ContactAggregate;
using SharedKernel;
using SharedKernel.Interfaces;

namespace PhoneBook.Domain.PersonAggregate
{
	public class Person : Entity, IAggregateRoot
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string CompanyName { get; set; }
		public Guid? PhoneId { get; private set; }
		public Guid? EmailId { get; private set; }
		public Guid? LocationId { get; private set; }

		public void AddPhone(Contact phoneContact)
		{
			if (phoneContact.ContactType != ContactType.Phone) throw new ConsistencyException("Contact type must be phone");
			PhoneId = phoneContact.Id;
		}

		public void AddEmail(Contact emailContact)
		{
			if (emailContact.ContactType != ContactType.Email) throw new ConsistencyException("Contact type must be email");
			EmailId = emailContact.Id;
		}

		public void AddLocation(Contact locationContact)
		{
			if (locationContact.ContactType != ContactType.Location) throw new ConsistencyException("Contact type must be location");
			LocationId = locationContact.Id;
		}
	}
}
