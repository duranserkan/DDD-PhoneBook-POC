using Microsoft.EntityFrameworkCore;
using PhoneBook.Domain.PersonAggregate;
using PhoneBook.Infrastructure.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Infrastructure.Repositories
{
	public class PersonRepository : IPersonRepository
	{
		private readonly PhoneBookDbContext _dbContext;

		public PersonRepository(PhoneBookDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<Person> GetByIdAsync(Guid id)
		{
			return await _dbContext.People.FindAsync(id);
		}

		public async Task<List<Person>> ListAsync()
		{
			return await _dbContext.People.ToListAsync();
		}

		public async Task<List<Person>> ListAsync(int skip, int take)
		{
			return await _dbContext.People.Skip(skip).Take(take).ToListAsync();
		}

		public async Task<int> CountAsync()
		{
			return await _dbContext.People.CountAsync();
		}

		public async Task AddAsync(Person aggregateRoot)
		{
			await _dbContext.People.AddAsync(aggregateRoot);
		}

		public void Delete(Person aggregateRoot)
		{
			_dbContext.People.Remove(aggregateRoot);
		}
	}
}
