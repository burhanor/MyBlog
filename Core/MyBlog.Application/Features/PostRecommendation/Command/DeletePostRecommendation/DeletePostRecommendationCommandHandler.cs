using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Consts;
using MyBlog.Application.Features.Post.Rules;
using MyBlog.Application.Features.PostRecommendationRecommendation.Rules;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.PostRecommendation.Command.DeletePostRecommendation
{
	public class DeletePostRecommendationCommandHandler : BaseHandler<Domain.Entities.PostRecommendation>, IRequestHandler<DeletePostRecommendationCommandRequest, ResponseContainer<Unit>>
	{
		private readonly PostRecommendationRules recommendationRules;

		public DeletePostRecommendationCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor,PostRecommendationRules recommendationRules) : base(uow, mapper, httpContextAccessor)
		{
			this.recommendationRules = recommendationRules;
		}

		public async Task<ResponseContainer<Unit>> Handle(DeletePostRecommendationCommandRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<Unit> response= new();
			Domain.Entities.PostRecommendation? recommendation = await readRepository.GetAsync(m => m.PostId == request.Id, cancellationToken: cancellationToken);
			await recommendationRules.PostRecommendationNotFound(recommendation);
			await writeRepository.DeleteAsync(recommendation, cancellationToken);
			await uow.SaveChangesAsync(cancellationToken);
			response.Success = true;
			response.Message = Const.PostRecommendation.POST_RECOMMENDATION_DELETED;
			return response;

		}
	}
}
