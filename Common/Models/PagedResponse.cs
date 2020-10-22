using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
	public class PagedResponse<T>
	{
		public IReadOnlyList<T> Data { get; }
		public int PageNumber { get; }
		public int PageSize { get; }
		public int TotalPages { get; }
		public int TotalCount { get; }
		public int Skipped => (PageNumber - 1) * PageSize;
		public int Taken => Data.Count;

		public PagedResponse(IReadOnlyList<T> data, int pageNumber, int pageSize, int totalCount)
		{
			Data = data;
			PageNumber = pageNumber;
			PageSize = pageSize;
			TotalCount = totalCount;
			TotalPages = (int)Math.Ceiling((double)TotalCount / pageSize);
		}
	}
}
