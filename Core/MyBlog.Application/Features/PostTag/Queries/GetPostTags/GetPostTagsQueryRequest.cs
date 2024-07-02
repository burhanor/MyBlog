using MediatR;
using MyBlog.Application.Models;

namespace MyBlog.Application.Features.PostTag.Queries.GetPostTags
{
	public class GetPostTagsQueryRequest : IRequest<ResponseContainer<IList<GetPostTagsQueryResponse>>>
	{
		public int PostId { get; set; }

	}
}
