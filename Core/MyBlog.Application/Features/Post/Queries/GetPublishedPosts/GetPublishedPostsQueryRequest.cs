using MediatR;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Post.Queries.GetPublishedPosts
{
	public class GetPublishedPostsQueryRequest:FilterModel,IRequest<ResponseContainer<IList<GetPublishedPostsQueryResponse>>>
	{
	}
}
