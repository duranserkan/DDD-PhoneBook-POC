using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SharedKernel.Interfaces;

namespace PhoneBook.Infrastructure.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		public Task SaveChangesAsync()
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}
