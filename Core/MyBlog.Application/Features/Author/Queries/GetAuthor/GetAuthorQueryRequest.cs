using MediatR;
using MyBlog.Application.Interfaces;
using MyBlog.Application.Models;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Author.Queries.GetAuthor
{
	public class GetAuthorQueryRequest:IRequest<ResponseContainer<GetAuthorQueryResponse>>,IId
	{
		public int Id { get; set; }

        public GetAuthorQueryRequest()
        {
            
        }
        public GetAuthorQueryRequest(int id)
        {
            Id = id;
        }
    }
}
