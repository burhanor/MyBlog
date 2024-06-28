using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Consts;
using MyBlog.Application.Features.Series.Rules;
using MyBlog.Application.Features.Tag.Rules;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Series.Command.DeleteSeries
{
	public class DeleteSeriesCommandHandler : BaseHandler<Domain.Entities.Series>, IRequestHandler<DeleteSeriesCommandRequest, ResponseContainer<Unit>>
	{
		private readonly SeriesRules seriesRules;

		public DeleteSeriesCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor,SeriesRules seriesRules) : base(uow, mapper, httpContextAccessor)
		{
			this.seriesRules = seriesRules;
		}

		public async Task<ResponseContainer<Unit>> Handle(DeleteSeriesCommandRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<Unit> response = new();
			Domain.Entities.Series? series = await readRepository.GetAsync(m => m.Id == request.Id, cancellationToken: cancellationToken);
			await seriesRules.SeriesNotFound(series);
			await writeRepository.DeleteAsync(series, cancellationToken);
			await uow.SaveChangesAsync(cancellationToken);
			response.Success = true;
			response.Message = Const.Series.SERIES_DELETED;
			return response;
		}
	}
}
