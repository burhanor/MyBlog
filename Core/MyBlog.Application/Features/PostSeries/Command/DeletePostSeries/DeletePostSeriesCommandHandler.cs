using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Consts;
using MyBlog.Application.Features.PostSeries.Rules;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.PostSeries.Command.DeletePostSeries
{
	public class DeletePostSeriesCommandHandler : BaseHandler<Domain.Entities.PostSeries>, IRequestHandler<DeletePostSeriesCommandRequest, ResponseContainer<Unit>>
	{
		private readonly PostSeriesRules postSeriesRules;

		public DeletePostSeriesCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor,PostSeriesRules postSeriesRules) : base(uow, mapper, httpContextAccessor)
		{
			this.postSeriesRules = postSeriesRules;
		}

		public async Task<ResponseContainer<Unit>> Handle(DeletePostSeriesCommandRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<Unit> response = new();
			Domain.Entities.PostSeries? postSeries = await readRepository.GetAsync(m => m.PostId == request.PostId && m.SeriesId==request.SeriesId, cancellationToken: cancellationToken);
			await postSeriesRules.PostSeriesNotFound(postSeries);
			await writeRepository.DeleteAsync(postSeries, cancellationToken);
			await uow.SaveChangesAsync(cancellationToken);
			response.Success = true;
			response.Message = Const.PostSeries.POST_SERIES_DELETED;
			return response;
		}
	}
}
