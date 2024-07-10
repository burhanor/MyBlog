using MediatR;
using MyBlog.Application.Models;
using MyBlog.Application.Models.PostCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.PostCategory.Command.CreatePostCategory
{
	public class CreatePostCategoryCommandRequest:PostCategoryModel,IRequest<ResponseContainer<CreatePostCategoryCommandResponse>>
	{
        public CreatePostCategoryCommandRequest()
        {
            
        }
        public CreatePostCategoryCommandRequest(int categoryId,int postId)
        {
            CategoryId = categoryId;
            PostId = postId;
        }
    }
}
