using MediatR;
using MyBlog.Application.Enums;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Author.Queries.GetAuthors
{
	public class GetAuthorsQueryRequest:IRequest<ResponseContainer<IList<GetAuthorsQueryResponse>>>
	{
		public int? PageSize { get; set; }
		public int? PageNumber { get; set; }
		public string? Search { get; set; }
		public string? OrderBy { get; set; }

        public GetAuthorsQueryRequest()
        {
            
        }

		
    }
}
