using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Features.Post.Rules;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace MyBlog.Application.Features.PostTag.Queries.GetPostTags
{
	public class GetPostTagsQueryHandler : BaseHandler, IRequestHandler<GetPostTagsQueryRequest, ResponseContainer<IList<GetPostTagsQueryResponse>>>
	{
		private readonly PostRules postRules;

		public GetPostTagsQueryHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor, PostRules postRules) : base(uow, mapper, httpContextAccessor)
		{
			this.postRules = postRules;
		}

		public async Task<ResponseContainer<IList<GetPostTagsQueryResponse>>> Handle(GetPostTagsQueryRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<IList<GetPostTagsQueryResponse>> response = new();
			bool postIsExist = await uow.GetReadRepository<Domain.Entities.Post>().ExistAsync(x => x.Id == request.PostId, cancellationToken);
			await postRules.PostNotFound(postIsExist);
			IList<Domain.Entities.PostTag> postTags = await uow.GetReadRepository<Domain.Entities.PostTag>().GetAllAsync(predicate: x => x.PostId == request.PostId, include: m => m.Include(s => s.Tag), cancellationToken: cancellationToken);
			response.Success = true;
			response.Data = postTags.Select(m => new GetPostTagsQueryResponse
			{
				TagName = m.Tag.Name,
				Url = m.Tag.Url
			}).ToList();
			return response;
		}
	}
}
