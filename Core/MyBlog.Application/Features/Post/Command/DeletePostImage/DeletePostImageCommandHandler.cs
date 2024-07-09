using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Consts;
using MyBlog.Application.Features.Post.Command.DeletePostImage;
using MyBlog.Application.Features.Post.Rules;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.Repositories;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Post.Command.DeletePostImage
{
	public class DeletePostImageCommandHandler : BaseHandler<Domain.Entities.PostImage>, IRequestHandler<DeletePostImageCommandRequest, ResponseContainer<Unit>>
	{
		private readonly PostRules postRules;

		public DeletePostImageCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor, PostRules postRules) : base(uow, mapper, httpContextAccessor)
		{
			this.postRules = postRules;
		}

		public async Task<ResponseContainer<Unit>> Handle(DeletePostImageCommandRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<Unit> response = new();
			bool postIsExist = await uow.GetReadRepository<Domain.Entities.Post>().ExistAsync(m => m.Id == request.PostId, cancellationToken);
			await postRules.PostNotFound(postIsExist);
			int imageId = uow.GetScalarFunction().GetPostImageId(request.PostId, request.ImageType);
			if (imageId > 0)
			{
				await writeRepository.DeleteAsync(m => m.ImageId == imageId && m.PostId == request.PostId, cancellationToken);
				await uow.SaveChangesAsync(cancellationToken);
			}
			response.Success = true;
			response.Message = Const.PostImages.POST_IMAGE_DELETED;
			return response;
		}
	}
}
