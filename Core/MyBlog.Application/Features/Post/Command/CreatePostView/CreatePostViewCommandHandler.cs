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

namespace MyBlog.Application.Features.Post.Command.CreatePostView
{
	public class CreatePostViewCommandHandler : BaseHandler<Domain.Entities.PostView>, IRequestHandler<CreatePostViewCommandRequest, ResponseContainer<CreatePostViewCommandResponse>>
	{
		private readonly PostRules postRules;

		public CreatePostViewCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor,PostRules postRules) : base(uow, mapper, httpContextAccessor)
		{
			this.postRules = postRules;
		}

		public async Task<ResponseContainer<CreatePostViewCommandResponse>> Handle(CreatePostViewCommandRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<CreatePostViewCommandResponse> response= new();
			bool postIsExist = await uow.GetReadRepository<Domain.Entities.Post>().ExistAsync(m => m.Id == request.PostId, cancellationToken);
			await postRules.PostNotFound(postIsExist);
			await writeRepository.AddAsync(new Domain.Entities.PostView
			{
				PostId = request.PostId,
				VisitDate = DateTime.Now,
				IpAddress = httpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress?.ToString() ?? string.Empty
			}, cancellationToken);
			await uow.SaveChangesAsync(cancellationToken);
			response.Success = true;
			int viewCount = await uow.GetReadRepository<Domain.Entities.PostView>().CountAsync(m => m.PostId == request.PostId, cancellationToken);
			response.Data=new CreatePostViewCommandResponse()
			{
				ViewCount=viewCount
			};
			return response;
		}
	}
}
