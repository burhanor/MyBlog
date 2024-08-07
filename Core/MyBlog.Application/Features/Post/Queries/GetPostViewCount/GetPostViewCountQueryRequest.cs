﻿using MediatR;
using MyBlog.Application.Interfaces;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Post.Queries.GetPostViewCount
{
	public class GetPostViewCountQueryRequest:IRequest<ResponseContainer<GetPostViewCountQueryResponse>>,IId
	{
        public GetPostViewCountQueryRequest()
        {
            
        }
        public GetPostViewCountQueryRequest(int ıd)
		{
			Id = ıd;
		}

		public int Id { get; set; }
	}
}
