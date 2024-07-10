using MediatR;
using MyBlog.Application.Enums;
using MyBlog.Application.Interfaces.Requests;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Author.Queries.GetAuthors
{
	public class GetAuthorsQueryRequest:FilterModel,IRequest<ResponseContainer<IList<GetAuthorsQueryResponse>>>
	{

        public GetAuthorsQueryRequest()
        {
            
        }

		
    }
}
