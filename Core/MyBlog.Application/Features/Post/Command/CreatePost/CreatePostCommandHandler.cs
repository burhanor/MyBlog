using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Features.Post.Rules;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Post.Command.CreatePost
{
	public class CreatePostCommandHandler : BaseHandler<Domain.Entities.Post>, IRequestHandler<CreatePostCommandRequest, ResponseContainer<CreatePostCommandResponse>>
	{
		private readonly PostRules postRules;

		public CreatePostCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor,PostRules postRules) : base(uow, mapper, httpContextAccessor)
		{
			this.postRules = postRules;
		}

		public async Task<ResponseContainer<CreatePostCommandResponse>> Handle(CreatePostCommandRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<CreatePostCommandResponse> response = new();

			return response;
		}
	}
}
