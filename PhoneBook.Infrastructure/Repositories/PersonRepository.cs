using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.Domain.PersonAggregate;

namespace PhoneBook.Infrastructure.Repositories
{
	public class PersonRepository : IPersonRepository
	{
		public Task<Person> GetByIdAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<List<Person>> ListAsync()
		{
			throw new NotImplementedException();
		}

		public Task<List<Person>> ListAsync(int skip, int take)
		{
			throw new NotImplementedException();
		}

		public Task<int> CountAsync()
		{
			throw new NotImplementedException();
		}

		public Task<Person> AddAsync(Person aggregateRoot)
		{
			throw new NotImplementedException();
		}

		public Task UpdateAsync(Person aggregateRoot)
		{
			throw new NotImplementedException();
		}

		public Task DeleteAsync(Person aggregateRoot)
		{
			throw new NotImplementedException();
		}
	}
}
