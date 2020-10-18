using System;

namespace SharedKernel
{
	public class ConsistencyException : Exception
	{
		public ConsistencyException()
		{

		}

		public ConsistencyException(string message) : base(message)
		{

		}

	}
}
