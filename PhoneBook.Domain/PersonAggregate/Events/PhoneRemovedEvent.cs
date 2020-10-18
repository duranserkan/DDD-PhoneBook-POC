﻿using SharedKernel;
using System;

namespace PhoneBook.Domain.PersonAggregate.Events
{
	public class PhoneRemovedEvent : DomainEvent
	{
		public Guid ContactId { get; set; }
		public string Content { get; set; }
		public Guid PersonId { get; set; }
	}
}
