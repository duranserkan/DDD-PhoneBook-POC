using System;

namespace PhoneBook.Contract.Events
{
	public class PhoneJoinedLocationEvent
	{
		public Guid PhoneId { get; set; }
		public Guid LocationId { get; set; }
	}
}
