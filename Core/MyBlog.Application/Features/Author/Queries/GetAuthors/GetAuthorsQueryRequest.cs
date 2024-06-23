using MediatR;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Author.Queries.GetAuthors
{
	public class GetAuthorsQueryRequest:IRequest<ResponseContainer<IList<GetAuthorsQueryResponse>>>
	{
	}
}
