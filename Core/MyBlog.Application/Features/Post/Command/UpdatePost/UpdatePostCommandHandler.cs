using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MyBlog.Application.Bases;
using MyBlog.Application.Consts;
using MyBlog.Application.Features.Post.Rules;
using MyBlog.Application.Helpers;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using MyBlog.Domain.Views;

namespace MyBlog.Application.Features.Post.Command.UpdatePost
{
	public class UpdatePostCommandHandler : BaseHandler<Domain.Entities.Post>, IRequestHandler<UpdatePostCommandRequest, ResponseContainer<UpdatePostCommandResponse>>
	{
		private readonly PostRules postRules;
		private readonly ImageHelper imageHelper;

		public UpdatePostCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor,PostRules postRules,ImageHelper imageHelper) : base(uow, mapper, httpContextAccessor)
		{
			this.postRules = postRules;
			this.imageHelper = imageHelper;
		}

		public async Task<ResponseContainer<UpdatePostCommandResponse>> Handle(UpdatePostCommandRequest request, CancellationToken cancellationToken)
		{

			ResponseContainer<UpdatePostCommandResponse> response = new();
			Domain.Entities.Post? post = await readRepository.GetAsync(m => m.Id == request.Id, include: m => m.Include(s => s.PostImages).ThenInclude(s => s.Image), cancellationToken: cancellationToken);
			await postRules.PostNotFound(post);
			bool isExist = await readRepository.ExistAsync(m => m.Title == request.Title && m.AuthorId == userId && m.Id != request.Id, cancellationToken);
			await postRules.PostAlreadyExists(isExist);
			int headerImageId = post.PostImages.FirstOrDefault(s => s.Image.ImageType == Domain.Enums.ImageType.PostHeader)?.ImageId ?? 0;
			int thumbnailImageId = post.PostImages.FirstOrDefault(s => s.Image.ImageType == Domain.Enums.ImageType.PostThumbnail)?.ImageId ?? 0;
			if (request.HeaderImage != null)
			{
				await postRules.ValidateImage(request.HeaderImage);
				ImageResponseModel headerImageResponse = await imageHelper.CreateOrUpdateImage(request.HeaderImage, Domain.Enums.ImageType.PostHeader, headerImageId, cancellationToken);
				headerImageId = headerImageResponse.ImageId;
			}
			if (request.ThumbnailImage != null)
			{
				await postRules.ValidateImage(request.ThumbnailImage);
				ImageResponseModel thumbnailImageResponse = await imageHelper.CreateOrUpdateImage(request.ThumbnailImage, Domain.Enums.ImageType.PostThumbnail, thumbnailImageId, cancellationToken);
				thumbnailImageId = thumbnailImageResponse.ImageId;

			}
			List<Domain.Entities.PostImage> postImages = [];
			if (headerImageId > 0)
				postImages.Add(new() { ImageId = headerImageId, PostId = post.Id });
			if (thumbnailImageId > 0)
				postImages.Add(new() { ImageId = thumbnailImageId, PostId = post.Id });

			await uow.BeginTransactionAsync();
			await uow.GetWriteRepository<Domain.Entities.PostImage>().DeleteAsync(m => m.PostId == post.Id, cancellationToken);
			if (postImages.Count > 0)
				await uow.GetWriteRepository<Domain.Entities.PostImage>().AddRangeAsync(postImages, cancellationToken);
			post = mapper.Map<Domain.Entities.Post, UpdatePostCommandRequest>(request);
			post.AuthorId = userId;
			await writeRepository.UpdateAsync(post);
			await uow.SaveChangesAsync(cancellationToken);
			await uow.CommitTransactionAsync();
			response.Success = true;
			response.Message = Const.Post.POST_UPDATED;
			PostSummary postSummary = await uow.GetReadRepository<PostSummary>().GetAsync(m => m.Id == post.Id, cancellationToken: cancellationToken);
			response.Data = mapper.Map<UpdatePostCommandResponse, PostSummary>(postSummary);
			return response;

		}
	}
}
