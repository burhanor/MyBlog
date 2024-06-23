using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Features.Author.Rules;
using MyBlog.Application.Helpers;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Author.Command.ChangeAvatar
{
	public class ChangeAvatarCommandHandler : BaseHandler<Domain.Entities.Author>, IRequestHandler<ChangeAvatarCommandRequest, ResponseContainer<ChangeAvatarCommandResponse>>
	{
		private readonly AuthorRules authorRules;
		private readonly ImageHelper imageHelper;

		public ChangeAvatarCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor,AuthorRules authorRules,ImageHelper imageHelper) : base(uow, mapper, httpContextAccessor)
		{
			this.authorRules = authorRules;
			this.imageHelper = imageHelper;
		}

		public async Task<ResponseContainer<ChangeAvatarCommandResponse>> Handle(ChangeAvatarCommandRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<ChangeAvatarCommandResponse> response = new() {
				Data = new()
			};
			Domain.Entities.Author? author = await readRepository.GetAsync(x => x.Id == userId, cancellationToken: cancellationToken, enableTracking: true);
			await authorRules.UserNotFound(author);
			if (request.Image != null)
			{
				ImageResponseModel imageResponseModel = await imageHelper.CreateImage(request.Image, Domain.Enums.ImageType.Author, cancellationToken);
				author.ImageId = imageResponseModel.ImageId;
				response.Data.ImagePath = imageResponseModel.ImagePath;
				response.Success = true;
				await uow.SaveChangesAsync(cancellationToken);
			}
			return response;
		}
	}
}
