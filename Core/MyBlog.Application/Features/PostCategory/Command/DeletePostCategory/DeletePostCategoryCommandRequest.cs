using MediatR;
using MyBlog.Application.Models;
using MyBlog.Application.Models.PostCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.PostCategory.Command.DeletePostCategory
{
	public class DeletePostCategoryCommandRequest:PostCategoryModel,IRequest<ResponseContainer<Unit>>
	{
        public DeletePostCategoryCommandRequest()
        {
            
        }
        public DeletePostCategoryCommandRequest(int postId,int categoryId)
        {
            
        }
    }
}
