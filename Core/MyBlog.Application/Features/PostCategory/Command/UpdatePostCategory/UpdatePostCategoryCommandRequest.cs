using MediatR;
using MyBlog.Application.Interfaces;
using MyBlog.Application.Models;
using MyBlog.Application.Models.PostCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.PostCategory.Command.UpdatePostCategory
{
	public class UpdatePostCategoryCommandRequest:PostCategoryModel,IRequest<ResponseContainer<UpdatePostCategoryCommandResponse>>,IId
	{
        public int Id { get; set; }
    }
}
