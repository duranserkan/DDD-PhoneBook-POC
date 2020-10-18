using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharedKernel.Interfaces
{
	public interface IRepository
	{
		Task<T> GetByIdAsync<T>(int id) where T : IAggregateRoot;
		Task<List<T>> ListAsync<T>() where T :  IAggregateRoot;
		Task<T> AddAsync<T>(T entity) where T :  IAggregateRoot;
		Task UpdateAsync<T>(T entity) where T :  IAggregateRoot;
		Task DeleteAsync<T>(T entity) where T :  IAggregateRoot;
	}
}
