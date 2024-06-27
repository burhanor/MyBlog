using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using MyBlog.Domain.Views;

namespace MyBlog.Application.Features.Card.Queries.GetCard
{
	public class GetCardQueryHandler : BaseHandler, IRequestHandler<GetCardQueryRequest, ResponseContainer<GetCardQueryResponse>>
	{
		public GetCardQueryHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor) : base(uow, mapper, httpContextAccessor)
		{
		}

		public async Task<ResponseContainer<GetCardQueryResponse>> Handle(GetCardQueryRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<GetCardQueryResponse> response= new();
			CardSummary card = await uow.GetReadRepository<CardSummary>().GetAsync(m => m.Id == request.Id, cancellationToken: cancellationToken);
			if (card != null && card.Id > 0)
			{
				response.Success = true;
				response.Data = mapper.Map<GetCardQueryResponse, CardSummary>(card);
			}
			return response;
		}
	}
}
