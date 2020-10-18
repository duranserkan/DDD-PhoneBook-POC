﻿using PhoneBook.Domain.ContactAggregate;
using PhoneBook.Domain.PersonAggregate.Events;
using SharedKernel;
using SharedKernel.Interfaces;
using System;

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
			if (phoneContact.PersonId != Id) throw new ConsistencyException("Person Id mismatch");
			if (phoneContact.ContactType != ContactType.Phone) throw new ConsistencyException("Contact type must be phone");
			if (PhoneId != null) throw new ConsistencyException("Phone id must be empty");
			PhoneId = phoneContact.Id;
			Events.Add(new PhoneAdded
			{
				PersonId = Id,
				ContactId = phoneContact.Id,
				Content = phoneContact.Content
			});
		}

		public void RemovePhone(Contact phoneContact)
		{
			if (phoneContact.PersonId != Id) throw new ConsistencyException("Person Id mismatch");
			if (phoneContact.ContactType != ContactType.Phone) throw new ConsistencyException("Contact type must be phone");
			if (PhoneId == null) throw new ConsistencyException("Phone id not found");
			PhoneId = null;
			Events.Add(new PhoneRemoved()
			{
				PersonId = Id,
				ContactId = phoneContact.Id ,
				Content = phoneContact.Content
			});
		}

		public void AddEmail(Contact emailContact)
		{
			if (emailContact.PersonId != Id) throw new ConsistencyException("Person Id mismatch");
			if (emailContact.ContactType != ContactType.Email) throw new ConsistencyException("Contact type must be email");
			if (EmailId != null) throw new ConsistencyException("Email id must be empty");
			EmailId = emailContact.Id;
			Events.Add(new EmailAdded()
			{
				PersonId = Id,
				ContactId = emailContact.Id,
				Content = emailContact.Content
			});
		}

		public void RemoveEmail(Contact emailContact)
		{
			if (emailContact.PersonId != Id) throw new ConsistencyException("Person Id mismatch");
			if (emailContact.ContactType != ContactType.Email) throw new ConsistencyException("Contact type must be email");
			if (EmailId == null) throw new ConsistencyException("Email id not found");
			EmailId = null;
			Events.Add(new EmailRemoved()
			{
				PersonId = Id,
				ContactId = emailContact.Id,
				Content = emailContact.Content
			});
		}

		public void AddLocation(Contact locationContact)
		{
			if (locationContact.PersonId != Id) throw new ConsistencyException("Person Id mismatch");
			if (locationContact.ContactType != ContactType.Location) throw new ConsistencyException("Contact type must be location");
			if (LocationId != null) throw new ConsistencyException("Location id must be empty");
			LocationId = locationContact.Id;
			Events.Add(new LocationAdded()
			{
				PersonId = Id,
				ContactId = locationContact.Id,
				Content = locationContact.Content
			});
		}

		public void RemoveLocation(Contact locationContact)
		{
			if (locationContact.PersonId != Id) throw new ConsistencyException("Person Id mismatch");
			if (locationContact.ContactType != ContactType.Location) throw new ConsistencyException("Contact type must be location");
			if (LocationId == null) throw new ConsistencyException("Location not found");
			LocationId = null;
			Events.Add(new LocationRemoved()
			{
				PersonId = Id,
				ContactId = locationContact.Id,
				Content = locationContact.Content
			});
		}
	}
}
