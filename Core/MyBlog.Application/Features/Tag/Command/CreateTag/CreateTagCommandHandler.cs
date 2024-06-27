using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Features.Category.Rules;
using MyBlog.Application.Features.Tag.Rules;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Tag.Command.CreateTag
{
	public class CreateTagCommandHandler : BaseHandler<Domain.Entities.Tag>, IRequestHandler<CreateTagCommandRequest, ResponseContainer<CreateTagCommandResponse>>
	{
		private readonly TagRules tagRules;

		public CreateTagCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor,TagRules tagRules) : base(uow, mapper, httpContextAccessor)
		{
			this.tagRules = tagRules;
		}

		public async Task<ResponseContainer<CreateTagCommandResponse>> Handle(CreateTagCommandRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<CreateTagCommandResponse> response = new();
			bool tagAlreadyExists = await readRepository.ExistAsync(m => m.Name == request.Name && m.IsHidden == request.IsHidden, cancellationToken: cancellationToken);
			await tagRules.TagAlreadyExists(tagAlreadyExists);
			
			bool urlIsExist = await readRepository.ExistAsync(m => m.Url == request.Url, cancellationToken: cancellationToken);	
			await tagRules.UrlMustBeUnique(urlIsExist);

			Domain.Entities.Tag tag = mapper.Map<Domain.Entities.Tag, CreateTagCommandRequest>(request);

			await writeRepository.AddAsync(tag, cancellationToken);
			await uow.SaveChangesAsync(cancellationToken);
			if(tag.Id>0)
			{
				response.Success = true;
				response.Data = mapper.Map<CreateTagCommandResponse, Domain.Entities.Tag>(tag);
			}
			return response;
		}
	}
}
