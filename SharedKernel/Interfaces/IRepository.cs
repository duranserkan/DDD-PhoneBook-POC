﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharedKernel.Interfaces
{
	public interface IRepository<T> where T : IAggregateRoot
	{
		Task<T> GetByIdAsync(Guid id);
		Task<List<T>> ListAsync();
		Task<List<T>> ListAsync(int skip, int take);
		Task<int> CountAsync();
		Task AddAsync(T aggregateRoot);
		void Delete(T aggregateRoot);
	}
}
