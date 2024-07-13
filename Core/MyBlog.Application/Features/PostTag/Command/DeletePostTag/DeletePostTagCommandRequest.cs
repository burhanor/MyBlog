using MediatR;
using MyBlog.Application.Models;
using MyBlog.Application.Models.PostTag;

namespace MyBlog.Application.Features.PostTag.Command.DeletePostTag
{
	public class DeletePostTagCommandRequest : PostTagModel, IRequest<ResponseContainer<Unit>>
	{
        public DeletePostTagCommandRequest()
        {
            
        }
        public DeletePostTagCommandRequest(int postId,int tagId)
        {
            PostId = postId;
            TagId = tagId;
        }
    }
}
