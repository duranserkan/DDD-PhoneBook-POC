using System;

namespace SharedKernel
{
	public abstract class DomainEvent
	{
		public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
		public Guid? PhoneId { get; private set; }
	}
}
