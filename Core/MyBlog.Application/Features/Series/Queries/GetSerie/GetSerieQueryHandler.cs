using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using MyBlog.Domain.Views;

namespace MyBlog.Application.Features.Series.Queries.GetSerie
{
	public class GetSerieQueryHandler : BaseHandler, IRequestHandler<GetSerieQueryRequest, ResponseContainer<GetSerieQueryResponse>>
	{
		public GetSerieQueryHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor) : base(uow, mapper, httpContextAccessor)
		{
		}

		public async Task<ResponseContainer<GetSerieQueryResponse>> Handle(GetSerieQueryRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<GetSerieQueryResponse> response = new();
			SeriesSummary series = await uow.GetReadRepository<SeriesSummary>().GetAsync(m => m.Id == request.Id, cancellationToken: cancellationToken);
			if (series != null && series.Id > 0)
			{
				response.Success = true;
				response.Data = mapper.Map<GetSerieQueryResponse, SeriesSummary>(series);
			}
			return response;
		}
	}
}
