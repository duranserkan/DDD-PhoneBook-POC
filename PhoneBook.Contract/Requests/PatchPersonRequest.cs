using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Contract.Requests
{
	public class PatchPersonRequest
	{
		public Guid PersonId { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string CompanyName { get; set; }
		public Guid? PhoneId { get; set; }
		public Guid? EmailId { get; set; }
		public Guid? LocationId { get; set; }
	}
}
