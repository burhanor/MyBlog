using MyBlog.Application.Features.PostCategory.Command.CreatePostCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Models.PostCategory
{
	public class PostCategoryModel
	{
        public PostCategoryModel()
        {
            
        }
        public PostCategoryModel(int postId, int categoryId)
		{
			PostId = postId;
			CategoryId = categoryId;
		}

		public int PostId { get; set; }
        public int CategoryId { get; set; }

        public CreatePostCategoryCommandRequest ToCreateCommandRequest()
        {
			return new CreatePostCategoryCommandRequest()
            {
                CategoryId = CategoryId,
                PostId = PostId
            };
        }

    }
}
