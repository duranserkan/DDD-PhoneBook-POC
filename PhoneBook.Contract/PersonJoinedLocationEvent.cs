using System;

namespace PhoneBook.Contract
{
	public class PersonJoinedLocationEvent
	{
		public Guid PersonId { get; set; }
		public Guid LocationId { get; set; }
		public string LocationContent { get; set; }
	}
}
