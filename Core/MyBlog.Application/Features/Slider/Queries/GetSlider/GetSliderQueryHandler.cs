using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Features.Slider.Queries.GetSlider;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using MyBlog.Domain.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Slider.Queries.GetSlider
{
	public class GetSliderQueryHandler : BaseHandler, IRequestHandler<GetSliderQueryRequest, ResponseContainer<GetSliderQueryResponse>>
	{
		public GetSliderQueryHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor) : base(uow, mapper, httpContextAccessor)
		{
		}

		public async Task<ResponseContainer<GetSliderQueryResponse>> Handle(GetSliderQueryRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<GetSliderQueryResponse> response = new();
			SliderSummary slider = await uow.GetReadRepository<SliderSummary>().GetAsync(m => m.Id == request.Id, cancellationToken: cancellationToken);
			if (slider != null && slider.Id > 0)
			{
				response.Success = true;
				response.Data = mapper.Map<GetSliderQueryResponse, SliderSummary>(slider);
			}
			return response;
		}
	}
}
