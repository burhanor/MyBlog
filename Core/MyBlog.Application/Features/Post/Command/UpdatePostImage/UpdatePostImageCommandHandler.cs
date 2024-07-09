using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Consts;
using MyBlog.Application.Features.Post.Rules;
using MyBlog.Application.Features.Series.Command.UpdateSeriesImage;
using MyBlog.Application.Features.Series.Rules;
using MyBlog.Application.Helpers;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;

namespace MyBlog.Application.Features.Post.Command.UpdatePostImage
{
	public class UpdatePostImageCommandHandler : BaseHandler<Domain.Entities.PostImage>, IRequestHandler<UpdatePostImageCommandRequest, ResponseContainer<UpdatePostImageCommandResponse>>
	{
		private readonly PostRules postRules;
		private readonly ImageHelper imageHelper;

		public UpdatePostImageCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor, PostRules postRules, ImageHelper imageHelper) : base(uow, mapper, httpContextAccessor)
		{
			this.postRules = postRules;
			this.imageHelper = imageHelper;
		}

		public async Task<ResponseContainer<UpdatePostImageCommandResponse>> Handle(UpdatePostImageCommandRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<UpdatePostImageCommandResponse> response = new();
			bool postIsExist = await uow.GetReadRepository<Domain.Entities.Post>().ExistAsync(m => m.Id == request.Id, cancellationToken);
			await postRules.PostNotFound(postIsExist);
			int imageId = uow.GetScalarFunction().GetPostImageId(request.Id, request.ImageType);
			ImageResponseModel imageResponseModel = await imageHelper.CreateOrUpdateImage(request.Image, request.ImageType, imageId, cancellationToken);
			if (imageId == 0)
			{
				await writeRepository.AddAsync(new Domain.Entities.PostImage
				{
					ImageId = imageResponseModel.ImageId,
					PostId = request.Id,
				}, cancellationToken);
				await uow.SaveChangesAsync(cancellationToken);
			}
			response.Success = true;
			response.Message = Const.PostImages.POST_IMAGE_UPDATED;
			response.Data = new UpdatePostImageCommandResponse()
			{
				ImagePath = uow.GetScalarFunction().GetPostImagePath(request.Id, request.ImageType)
			};
			return response;
		}

	}
}
