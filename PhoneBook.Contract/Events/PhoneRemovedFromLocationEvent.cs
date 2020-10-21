using System;

namespace PhoneBook.Contract.Events
{
	public class PhoneRemovedFromLocationEvent
	{
		public Guid PhoneId { get; set; }
		public Guid LocationId { get; set; }
		public string LocationContent { get; set; }
	}
}
