using MyBlog.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Author.Command.UpdateAuthor
{
	public class UpdateAuthorCommandResponse
	{
		public string ProfileImagePath { get; set; } = string.Empty;
	}
}
