using PhoneBook.Domain.ContactAggregate;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.Infrastructure.Repositories
{
	public class ContactRepository : IContactRepository
	{
		public Task<Contact> GetByIdAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<List<Contact>> ListAsync()
		{
			throw new NotImplementedException();
		}

		public Task<Contact> AddAsync(Contact aggregateRoot)
		{
			throw new NotImplementedException();
		}

		public Task UpdateAsync(Contact aggregateRoot)
		{
			throw new NotImplementedException();
		}

		public Task DeleteAsync(Contact aggregateRoot)
		{
			throw new NotImplementedException();
		}
	}
}
