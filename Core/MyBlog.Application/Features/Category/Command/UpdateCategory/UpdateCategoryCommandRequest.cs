using MediatR;
using MyBlog.Application.Interfaces;
using MyBlog.Application.Models;
using MyBlog.Application.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Category.Command.UpdateCategory
{
	public class UpdateCategoryCommandRequest:CategoryModel,IRequest<ResponseContainer<UpdateCategoryCommandResponse>>,IId
	{
        public int Id { get; set; }
     
    }
}
