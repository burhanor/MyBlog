using MediatR;
using MyBlog.Application.Models;
using MyBlog.Application.Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Post.Command.CreatePost
{
	public class CreatePostCommandRequest:PostModel,IRequest<ResponseContainer<CreatePostCommandResponse>>
	{
	}
}
