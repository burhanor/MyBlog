using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Interfaces.Requests
{
	public interface IFilterRequest
	{
		 int? PageSize { get; set; }
		 int? PageNumber { get; set; }
		 string? Search { get; set; }
		 string? OrderBy { get; set; }
	}
}
