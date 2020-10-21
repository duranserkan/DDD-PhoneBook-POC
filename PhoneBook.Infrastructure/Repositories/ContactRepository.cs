using PhoneBook.Domain.ContactAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Infrastructure.DbContext;

namespace PhoneBook.Infrastructure.Repositories
{
	public class ContactRepository : IContactRepository
	{
		private readonly PhoneBookDbContext _dbContext;

		public ContactRepository(PhoneBookDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<Contact> GetByIdAsync(Guid id)
		{
			return await _dbContext.Contacts.FindAsync(id);
		}

		public async Task<List<Contact>> ListAsync()
		{
			return await _dbContext.Contacts.ToListAsync();
		}

		public async Task<List<Contact>> ListAsync(int skip, int take)
		{
			return await _dbContext.Contacts.Skip(skip).Take(take).ToListAsync();
		}

		public async Task<int> CountAsync()
		{
			return await _dbContext.Contacts.CountAsync();
		}

		public async Task AddAsync(Contact aggregateRoot)
		{
			await _dbContext.Contacts.AddAsync(aggregateRoot);
		}
		
		public void Delete(Contact aggregateRoot)
		{
			_dbContext.Contacts.Remove(aggregateRoot);
		}
	}
}
