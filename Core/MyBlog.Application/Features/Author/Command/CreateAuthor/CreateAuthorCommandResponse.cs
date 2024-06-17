using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Author.Command.CreateAuthor
{
	public class CreateAuthorCommandResponse
	{
        public int Id { get; set; }
        public string ProfileImagePath { get; set; } = string.Empty;
    }
}
