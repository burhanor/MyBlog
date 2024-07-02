using MediatR;
using MyBlog.Application.Features.PostCategory.Command.CreatePostCategory;
using MyBlog.Application.Models.PostTag;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.PostTag.Command.CreatePostTag
{
	public class CreatePostTagCommandRequest : PostTagModel, IRequest<ResponseContainer<CreatePostTagCommandResponse>>
	{
	}
}
