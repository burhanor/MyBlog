using MyBlog.Application.Features.PostTag.Command.CreatePostTag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Models.PostTag
{
	public class PostTagModel
	{
        public PostTagModel()
        {
            
        }
        public PostTagModel(int postId, int tagId)
		{
			PostId = postId;
			TagId = tagId;
		}

		public PostTagModel(int postId, int tagId, bool isHidden) : this(postId, tagId)
		{
			IsHidden = isHidden;
		}

		public int PostId { get; set; }
		public int TagId { get; set; }
		public bool IsHidden { get; set; }

		public CreatePostTagCommandRequest ToCreateCommandRequest() {
			return new CreatePostTagCommandRequest
			{
				IsHidden = IsHidden,
				PostId = PostId,
				TagId = TagId
			};
		}

	}
}
