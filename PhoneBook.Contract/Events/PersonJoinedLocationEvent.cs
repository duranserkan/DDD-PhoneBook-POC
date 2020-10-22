using System;

namespace PhoneBook.Contract.Events
{
	public interface IPersonJoinedLocationEvent
	{
		Guid PersonId { get; }
		Guid LocationId { get; }
		string LocationContent { get; }
	}

	public class PersonJoinedLocationEvent : IPersonJoinedLocationEvent
	{
		public PersonJoinedLocationEvent(Guid personId, Guid locationId, string locationContent)
		{
			if (personId == default) throw new ArgumentException("PersonId can not be default");
			if (locationId == default) throw new ArgumentException("locationId can not be default");
			if (string.IsNullOrWhiteSpace(locationContent)) throw new ArgumentException("locationContent can not be null or whitespace");
			PersonId = personId;
			LocationId = locationId;
			LocationContent = locationContent;
		}
		public Guid PersonId { get; set; }
		public Guid LocationId { get; set; }
		public string LocationContent { get; set; }
	}
}
