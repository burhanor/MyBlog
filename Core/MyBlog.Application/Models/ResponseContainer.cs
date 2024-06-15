using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Models
{
	public class ResponseContainer<T>
	{
		public T? Data { get; set; }
		public bool Success { get; set; }
		public string Message { get; set; } = string.Empty;
	}
}
