using System;

namespace PhoneBook.Contract.Events
{
	public class PhoneJoinedLocationEvent
	{
		public PhoneJoinedLocationEvent(Guid phoneId, Guid locationId)
		{
			if (phoneId == default) throw new ArgumentException("phoneId can not be default");
			if (locationId == default) throw new ArgumentException("locationId can not be default");
			PhoneId = phoneId;
			LocationId = locationId;
		}
		public Guid PhoneId { get; set; }
		public Guid LocationId { get; set; }
	}
}
