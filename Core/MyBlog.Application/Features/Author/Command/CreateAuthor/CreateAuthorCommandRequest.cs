using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Models;
using MyBlog.Application.Models.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Author.Command.CreateAuthor
{
	public class CreateAuthorCommandRequest:AuthorModel,IRequest<ResponseContainer<CreateAuthorCommandResponse>>
	{
	}
}
