using MediatR;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.PostRecommendation.Command.CreatePostRecommendation
{
	public class CreatePostRecommendationCommandRequest:IRequest<ResponseContainer<CreatePostRecommendationCommandResponse>>
	{
        public CreatePostRecommendationCommandRequest()
        {
            
        }
        public CreatePostRecommendationCommandRequest(int postId, int displayOrder)
		{
			PostId = postId;
			DisplayOrder = displayOrder;
		}

		public int PostId { get; set; }
        public int DisplayOrder { get; set; }
    }
}
