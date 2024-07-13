using MyBlog.Application.Interfaces.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Models
{
	public class FilterModel:IFilterRequest
	{
		public int? PageSize { get; set; }
		public int? PageNumber { get; set; }
		public string? Search { get; set; }
		public string? OrderBy { get; set; }
	}
}
