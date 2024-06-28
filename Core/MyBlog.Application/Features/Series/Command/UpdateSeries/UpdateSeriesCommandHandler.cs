using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MyBlog.Application.Bases;
using MyBlog.Application.Features.Series.Rules;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Series.Command.UpdateSeries
{
	public class UpdateSeriesCommandHandler : BaseHandler<Domain.Entities.Series>, IRequestHandler<UpdateSeriesCommandRequest, ResponseContainer<UpdateSeriesCommandResponse>>
	{
		private readonly SeriesRules seriesRules;

		public UpdateSeriesCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor,SeriesRules seriesRules) : base(uow, mapper, httpContextAccessor)
		{
			this.seriesRules = seriesRules;
		}

		public async Task<ResponseContainer<UpdateSeriesCommandResponse>> Handle(UpdateSeriesCommandRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<UpdateSeriesCommandResponse> response = new();
			return response;
		}
	}
}
