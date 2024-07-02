using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Consts;
using MyBlog.Application.Features.Tag.Rules;
using MyBlog.Application.Features.Post.Rules;
using MyBlog.Application.Features.PostTag.Command.CreatePostTag;
using MyBlog.Application.Features.PostTag.Rules;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.Repositories;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.PostTag.Command.CreatePostTag
{
	public class CreatePostTagCommandHandler : BaseHandler<Domain.Entities.PostTag>, IRequestHandler<CreatePostTagCommandRequest, ResponseContainer<CreatePostTagCommandResponse>>
	{
		private readonly PostTagRules postTagRules;
		private readonly PostRules postRules;
		private readonly TagRules tagRules;

		public CreatePostTagCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor, PostTagRules postTagRules, PostRules postRules, TagRules tagRules) : base(uow, mapper, httpContextAccessor)
		{
			this.postTagRules = postTagRules;
			this.postRules = postRules;
			this.tagRules = tagRules;
		}

		public async Task<ResponseContainer<CreatePostTagCommandResponse>> Handle(CreatePostTagCommandRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<CreatePostTagCommandResponse> response = new();
			bool postIsExist = await uow.GetReadRepository<Domain.Entities.Post>().ExistAsync(x => x.Id == request.PostId, cancellationToken);
			await postRules.PostNotFound(postIsExist);
			Domain.Entities.Tag tag = await uow.GetReadRepository<Domain.Entities.Tag>().GetAsync(predicate: x => x.Id == request.TagId, cancellationToken: cancellationToken, select: m => new Domain.Entities.Tag
			{
				Name = m.Name,
				Id = request.TagId,
				Url= m.Url
			});
			await tagRules.TagNotFound(tag);
			bool postTagIsExist = await readRepository.ExistAsync(m => m.PostId == request.PostId && m.TagId == request.TagId, cancellationToken);
			await postTagRules.PostTagAlreadyExists(postTagIsExist);
			Domain.Entities.PostTag postTag = mapper.Map<Domain.Entities.PostTag, CreatePostTagCommandRequest>(request);
			await writeRepository.AddAsync(postTag, cancellationToken);
			await uow.SaveChangesAsync(cancellationToken);
			response.Success = true;
			response.Message = Const.PostTag.POST_TAG_CREATED;
			response.Data = new CreatePostTagCommandResponse
			{
				TagName = tag.Name,
				Url=tag.Url
			};

			return response;
		}
	}

}
