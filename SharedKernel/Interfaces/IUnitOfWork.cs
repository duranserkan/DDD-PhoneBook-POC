using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		Task SaveChangesAsync();
	}
}
