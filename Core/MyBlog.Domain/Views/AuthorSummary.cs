using MyBlog.Domain.Commons;
using MyBlog.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.Views
{
	public class AuthorSummary: IViewBase
	{
		public int Id { get; set; }
		public string EmailAddress { get; set; } = string.Empty;
		public string NickName { get; set; } = string.Empty;
		public string Summary { get; set; } = string.Empty;
		public string? Path { get; set; } = string.Empty;
		public AuthorType AuthorType { get; set; }
	}
}
