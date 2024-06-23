using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Consts;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using MyBlog.Domain.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Author.Queries.GetAuthor
{
	public class GetAuthorQueryHandler : BaseHandler,IRequestHandler<GetAuthorQueryRequest,ResponseContainer<GetAuthorQueryResponse>>
	{
		public GetAuthorQueryHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor) : base(uow, mapper, httpContextAccessor)
		{
		}

		public async Task<ResponseContainer<GetAuthorQueryResponse>> Handle(GetAuthorQueryRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<GetAuthorQueryResponse> response = new();
			AuthorSummary authorSummary = await uow.GetReadRepository<AuthorSummary>().GetAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
			if (authorSummary == null || authorSummary.Id==0)
			{
				response.Message = Const.Author.AUTHOR_NOT_FOUND;
				return response;
			}
			response.Data = mapper.Map<GetAuthorQueryResponse, AuthorSummary>(authorSummary);
			response.Success = true;
			return response;
		}
	}
}
