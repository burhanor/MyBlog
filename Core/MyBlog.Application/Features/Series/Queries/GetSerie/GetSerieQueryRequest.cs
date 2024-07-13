using MediatR;
using MyBlog.Application.Interfaces;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Series.Queries.GetSerie
{
	public class GetSerieQueryRequest:IRequest<ResponseContainer<GetSerieQueryResponse>>,IId
	{
        public GetSerieQueryRequest()
        {
            
        }
        public GetSerieQueryRequest(int id)
		{
			Id = id;
		}

		public int Id { get; set; }
	}
}
