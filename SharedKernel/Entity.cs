using System;
using System.Collections.Generic;
using SharedKernel.Interfaces;

namespace SharedKernel
{
	public abstract class Entity : IEntity
	{
		public Guid Id { get; set; }
		public List<DomainEvent> Events { get; } = new List<DomainEvent>();
	}
}
