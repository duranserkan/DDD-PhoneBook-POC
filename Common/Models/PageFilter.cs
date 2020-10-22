using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
	public class PageFilter
	{
		public int PageNumber { get; set; }
		public int PageSize { get; set; }
		public int Skip => (PageNumber - 1) * PageSize;
		public PageFilter()
		{
			PageNumber = 1;
			PageSize = 10;
		}
		public PageFilter(int pageNumber, int pageSize)
		{
			PageNumber = pageNumber < 1 ? 1 : pageNumber;
			PageSize = pageSize > 100 ? 100 : pageSize;
		}
	}
}
