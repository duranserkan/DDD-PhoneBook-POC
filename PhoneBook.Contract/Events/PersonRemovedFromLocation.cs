using System;

namespace PhoneBook.Contract.Events
{
	public class PersonRemovedFromLocationEvent
	{
		public Guid PersonId { get; set; }
		public Guid LocationId { get; set; }
		public string LocationContent { get; set; }
	}
}
