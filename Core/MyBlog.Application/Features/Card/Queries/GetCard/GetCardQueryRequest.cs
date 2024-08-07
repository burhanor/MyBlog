﻿using MediatR;
using MyBlog.Application.Interfaces;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Card.Queries.GetCard
{
	public class GetCardQueryRequest:IRequest<ResponseContainer<GetCardQueryResponse>>,IId
	{
        public GetCardQueryRequest()
        {
            
        }

		public GetCardQueryRequest(int id)
		{
			Id = id;
		}

		public int Id { get; set; }
    }
}
