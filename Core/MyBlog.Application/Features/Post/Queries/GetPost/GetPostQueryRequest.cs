using MediatR;
using MyBlog.Application.Interfaces;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Post.Queries.GetPost
{
	public class GetPostQueryRequest:IRequest<ResponseContainer<GetPostQueryResponse>>,IId	
	{
        public GetPostQueryRequest()
        {
            
        }
        public GetPostQueryRequest(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
