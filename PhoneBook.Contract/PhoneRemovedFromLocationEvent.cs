using System;

namespace PhoneBook.Contract
{
	public class PhoneRemovedFromLocationEvent
	{
		public Guid PhoneId { get; set; }
		public Guid LocationId { get; set; }
		public string LocationContent { get; set; }
	}
}
