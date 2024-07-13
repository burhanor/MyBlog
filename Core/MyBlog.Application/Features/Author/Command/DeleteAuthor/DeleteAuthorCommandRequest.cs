using MediatR;
using MyBlog.Application.Interfaces;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Author.Command.DeleteAuthor
{
	public class DeleteAuthorCommandRequest:IRequest<ResponseContainer<Unit>>,IId
	{
        public DeleteAuthorCommandRequest()
        {
            
        }

		public DeleteAuthorCommandRequest(int id)
		{
			Id = id;
		}

		public int Id { get; set; }
	}
}
