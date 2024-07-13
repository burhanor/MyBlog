using MediatR;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Post.Command.CreatePostView
{
	public class CreatePostViewCommandRequest:IRequest<ResponseContainer<CreatePostViewCommandResponse>>
	{
        public int PostId { get; set; }
        public CreatePostViewCommandRequest()
        {
            
        }

		public CreatePostViewCommandRequest(int postId)
		{
			PostId = postId;
		}
	}
}
