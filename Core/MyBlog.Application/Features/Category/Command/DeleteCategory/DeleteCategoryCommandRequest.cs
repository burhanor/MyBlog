using MediatR;
using MyBlog.Application.Interfaces;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Category.Command.DeleteCategory
{
	public class DeleteCategoryCommandRequest:IRequest<ResponseContainer<DeleteCategoryCommandResponse>>,IId
	{
        public DeleteCategoryCommandRequest()
        {
            
        }

		public DeleteCategoryCommandRequest(int id)
		{
			Id = id;
		}

		public int Id { get; set; }
    }
}
