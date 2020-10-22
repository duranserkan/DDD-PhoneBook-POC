using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.Infrastructure.DbContext;
using SharedKernel.Interfaces;

namespace PhoneBook.Infrastructure.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly PhoneBookDbContext _dbContext;

		public UnitOfWork(PhoneBookDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task SaveChangesAsync()
		{
			await _dbContext.SaveChangesAsync();
		}

		public void Dispose()
		{
			_dbContext.Dispose();
		}
	}
}
