using System;

namespace PhoneBook.Contract
{
	public class PhoneJoinedLocationEvent
	{
		public Guid PhoneId { get; set; }
		public Guid LocationId { get; set; }
		public string LocationContent { get; set; }
	}
}
