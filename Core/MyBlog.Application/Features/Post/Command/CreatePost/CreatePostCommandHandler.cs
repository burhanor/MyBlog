using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Consts;
using MyBlog.Application.Features.Post.Rules;
using MyBlog.Application.Helpers;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using MyBlog.Domain.Views;

namespace MyBlog.Application.Features.Post.Command.CreatePost
{
	public class CreatePostCommandHandler : BaseHandler<Domain.Entities.Post>, IRequestHandler<CreatePostCommandRequest, ResponseContainer<CreatePostCommandResponse>>
	{
		private readonly PostRules postRules;
		private readonly ImageHelper imageHelper;

		public CreatePostCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor,PostRules postRules,ImageHelper imageHelper) : base(uow, mapper, httpContextAccessor)
		{
			this.postRules = postRules;
			this.imageHelper = imageHelper;
		}

		public async Task<ResponseContainer<CreatePostCommandResponse>> Handle(CreatePostCommandRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<CreatePostCommandResponse> response = new();
			bool postAlreadyExists = await readRepository.ExistAsync(m => m.Title == request.Title && m.AuthorId == userId, cancellationToken: cancellationToken);
			await postRules.PostAlreadyExists(postAlreadyExists);

			bool urlIsExist = await readRepository.ExistAsync(m => m.Url == request.Url, cancellationToken: cancellationToken);
			await postRules.UrlMustBeUnique(urlIsExist);
			await postRules.ValidateImage(request.HeaderImage);
			await postRules.ValidateImage(request.ThumbnailImage);
			ImageResponseModel headerImageResponse = await imageHelper.CreateImage(request.HeaderImage, Domain.Enums.ImageType.PostHeader, cancellationToken);
			ImageResponseModel thumbnailImageResponse = await imageHelper.CreateImage(request.ThumbnailImage, Domain.Enums.ImageType.PostThumbnail, cancellationToken);
			Domain.Entities.Post post = mapper.Map<Domain.Entities.Post, CreatePostCommandRequest>(request);
			post.AuthorId = userId;
			await writeRepository.AddAsync(post, cancellationToken);
			await uow.SaveChangesAsync(cancellationToken);

			IList<Domain.Entities.PostImage> postImage = [];
			postImage.Add(new()
			{
				ImageId = headerImageResponse.ImageId,
				PostId = post.Id,
			});
			postImage.Add(new()
			{
				ImageId = thumbnailImageResponse.ImageId,
				PostId = post.Id,
			});
			await uow.GetWriteRepository<Domain.Entities.PostImage>().AddRangeAsync(postImage, cancellationToken);
			await uow.SaveChangesAsync(cancellationToken);
			//TODO: Add AuthorName to PostSummary
			if (post.Id > 0)
			{
				response.Success = true;
				response.Data = await uow.GetReadRepository<PostSummary>().GetAsync(select: m => new CreatePostCommandResponse
				{
					Id = m.Id,
					AuthorName = m.AuthorName,
					HeaderPath = m.HeaderPath,
					IsPublished = m.IsPublished,
					PublishDate = m.PublishDate,
					Summary = m.Summary,
					ThumbnailPath = m.ThumbnailPath,
					Title = m.Title,
					Url = m.Url,
					AuthorPath = m.AuthorPath
				}, predicate: m => m.Id == post.Id, cancellationToken: cancellationToken);
				response.Message = Const.Post.POST_CREATED;
			}
			return response;
		}
	}
}
