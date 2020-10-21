using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhoneBook.Domain.PersonAggregate;

namespace PhoneBook.Application.Models
{
	public class PersonDto
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string CompanyName { get; set; }
		public Guid? PhoneId { get; set; }
		public Guid? EmailId { get; set; }
		public Guid? LocationId { get; set; }

		public static PersonDto MapFrom(Person person)
		{
			if (person == null) return null;

			return new PersonDto
			{
				Name = person.Name,
				Surname = person.Surname,
				CompanyName = person.CompanyName,
				EmailId = person.EmailId,
				LocationId = person.LocationId,
				PhoneId = person.LocationId
			};
		}

		public static IReadOnlyList<PersonDto> MapFrom(IReadOnlyList<Person> person) => person.Select(MapFrom).ToArray();
	}
}
