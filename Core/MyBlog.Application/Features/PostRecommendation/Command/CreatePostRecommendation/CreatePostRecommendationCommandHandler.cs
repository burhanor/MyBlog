using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Consts;
using MyBlog.Application.Features.Post.Rules;
using MyBlog.Application.Features.PostRecommendationRecommendation.Rules;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using MyBlog.Domain.Entities;
using MyBlog.Domain.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.PostRecommendation.Command.CreatePostRecommendation
{
	public class CreatePostRecommendationCommandHandler : BaseHandler<Domain.Entities.PostRecommendation>, IRequestHandler<CreatePostRecommendationCommandRequest, ResponseContainer<CreatePostRecommendationCommandResponse>>
	{
		private readonly PostRules postRules;
		private readonly PostRecommendationRules recommendationRules;

		public CreatePostRecommendationCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor,PostRules postRules, PostRecommendationRules recommendationRules ) : base(uow, mapper, httpContextAccessor)
		{
			this.postRules = postRules;
			this.recommendationRules = recommendationRules;
		}

		public async Task<ResponseContainer<CreatePostRecommendationCommandResponse>> Handle(CreatePostRecommendationCommandRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<CreatePostRecommendationCommandResponse> response = new();
			bool postIsExist = await uow.GetReadRepository<Domain.Entities.Post>().ExistAsync(x => x.Id == request.PostId, cancellationToken);
			await postRules.PostNotFound(postIsExist);
			bool postRecommendationIsExist = await uow.GetReadRepository<Domain.Entities.PostRecommendation>().ExistAsync(x => x.PostId == request.PostId, cancellationToken);
			await recommendationRules.PostRecommendationAlreadyExists(postRecommendationIsExist);
			await recommendationRules.DisplayOrderMustBePositive(request.DisplayOrder);
			Domain.Entities.PostRecommendation postRecommendation = new()
			{
				PostId = request.PostId,
				DisplayOrder = request.DisplayOrder
			};
			await writeRepository.AddAsync(postRecommendation, cancellationToken);
			await uow.SaveChangesAsync(cancellationToken);

			CreatePostRecommendationCommandResponse data = await uow.GetReadRepository<PostSummary>().GetAsync(predicate:m => m.Id == request.PostId,select:m=>new CreatePostRecommendationCommandResponse
			{
				Image=m.HeaderPath,
				Title=m.Title,
				Url=m.Url
			}, cancellationToken: cancellationToken);
			response.Success = true;
			response.Message= Const.PostRecommendation.POST_RECOMMENDATION_CREATED;
			response.Data = data;
			return response;
		}
	}
}
