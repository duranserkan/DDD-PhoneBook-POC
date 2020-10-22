using System;

namespace PhoneBook.Contract.Events
{
	public class PersonRemovedFromLocationEvent
	{
		public PersonRemovedFromLocationEvent(Guid personId, Guid locationId)
		{
			if (personId == default) throw new ArgumentException("PersonId can not be default");
			if (locationId == default) throw new ArgumentException("locationId can not be default");
			PersonId = personId;
			LocationId = locationId;
		}

		public Guid PersonId { get; set; }
		public Guid LocationId { get; set; }
	}
}
