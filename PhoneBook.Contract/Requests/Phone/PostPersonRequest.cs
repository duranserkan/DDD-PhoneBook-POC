﻿using System;

namespace PhoneBook.Contract.Requests.Phone
{
	public class PostPersonRequest
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string CompanyName { get; set; }
		public Guid? PhoneId { get; set; }
		public Guid? EmailId { get; set; }
		public Guid? LocationId { get; set; }
	}
}
