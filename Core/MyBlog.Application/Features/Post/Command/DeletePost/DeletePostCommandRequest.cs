﻿using MediatR;
using MyBlog.Application.Interfaces;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Post.Command.DeletePost
{
	public class DeletePostCommandRequest:IRequest<ResponseContainer<Unit>>,IId
	{
		public int Id { get; set; }
	}
}
