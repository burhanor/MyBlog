using MediatR;
using MyBlog.Application.Interfaces;
using MyBlog.Application.Models;
using MyBlog.Application.Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Post.Command.UpdatePost
{
	public class UpdatePostCommandRequest:PostModel,IRequest<ResponseContainer<UpdatePostCommandResponse>>,IId
	{
		public int Id { get; set; }
	}
}
