using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Features.Tag.Rules;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Tag.Queries.GetTag
{
	public class GetTagQueryHandler : BaseHandler<Domain.Entities.Tag>, IRequestHandler<GetTagQueryRequest, ResponseContainer<GetTagQueryResponse>>
	{
		private readonly TagRules tagRules;

		public GetTagQueryHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor,TagRules tagRules) : base(uow, mapper, httpContextAccessor)
		{
			this.tagRules = tagRules;
		}

		public async Task<ResponseContainer<GetTagQueryResponse>> Handle(GetTagQueryRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<GetTagQueryResponse> response = new();
			Domain.Entities.Tag tag = await readRepository.GetAsync(m => m.Id == request.Id, cancellationToken: cancellationToken);
			await tagRules.TagNotFound(tag);
			response.Data = mapper.Map<GetTagQueryResponse, Domain.Entities.Tag>(tag);
			return response;
		}
	}
}
