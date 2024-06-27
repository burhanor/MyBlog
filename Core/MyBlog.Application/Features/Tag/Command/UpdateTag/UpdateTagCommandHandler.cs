using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Features.Category.Command.UpdateCategory;
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

namespace MyBlog.Application.Features.Tag.Command.UpdateTag
{
	public class UpdateTagCommandHandler : BaseHandler<Domain.Entities.Tag>, IRequestHandler<UpdateTagCommandRequest, ResponseContainer<UpdateTagCommandResponse>>
	{
		private readonly TagRules tagRules;

		public UpdateTagCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor,TagRules tagRules) : base(uow, mapper, httpContextAccessor)
		{
			this.tagRules = tagRules;
		}

		public async Task<ResponseContainer<UpdateTagCommandResponse>> Handle(UpdateTagCommandRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<UpdateTagCommandResponse> response=new();
			await tagRules.DisplayOrderMustBePositive(request.DisplayOrder);
			Domain.Entities.Tag? tag = await readRepository.GetAsync(m => m.Id == request.Id, cancellationToken: cancellationToken);
			await tagRules.TagNotFound(tag);
			bool isExist = await readRepository.ExistAsync(m => m.Name == request.Name && m.IsHidden == request.IsHidden && m.Id != request.Id, cancellationToken: cancellationToken);
			await tagRules.TagAlreadyExists(isExist);
			bool urlIsExist = await readRepository.ExistAsync(m => m.Url == request.Url && m.Id != request.Id, cancellationToken: cancellationToken);
			await tagRules.UrlMustBeUnique(urlIsExist);
			await writeRepository.UpdateAsync(mapper.Map<Domain.Entities.Tag, UpdateTagCommandRequest>(request));
			await uow.SaveChangesAsync(cancellationToken);
			response.Data = mapper.Map<UpdateTagCommandResponse, UpdateTagCommandRequest>(request);
			response.Success = true;
			return response;
		}
	}
}
