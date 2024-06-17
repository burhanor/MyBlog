using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Consts;
using MyBlog.Application.Extensions;
using MyBlog.Application.Features.Author.Rules;
using MyBlog.Application.Helpers;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;

namespace MyBlog.Application.Features.Author.Command.UpdateAuthor
{
	public class UpdateAuthorCommandHandler : BaseHandler<Domain.Entities.Author>,IRequestHandler<UpdateAuthorCommandRequest,ResponseContainer<UpdateAuthorCommandResponse>>
	{
		private readonly AuthorRules authorRules;
		private readonly ImageHelper imageHelper;
		public UpdateAuthorCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor, AuthorRules authorRules, ImageHelper imageHelper) : base(uow, mapper, httpContextAccessor)
		{
			this.authorRules = authorRules;
			this.imageHelper = imageHelper;
		}

		public async Task<ResponseContainer<UpdateAuthorCommandResponse>> Handle(UpdateAuthorCommandRequest request, CancellationToken cancellationToken)
		{
			Domain.Entities.Author? author = await readRepository.GetAsync(x => x.Id == request.Id, cancellationToken: cancellationToken,enableTracking:true);
			await authorRules.UserNotFound(author);
			bool emailIsTaken = await readRepository.ExistAsync(x => x.EmailAddress == request.EmailAddress && x.Id != request.Id, cancellationToken: cancellationToken);
			await authorRules.EmailAlreadyTaken(emailIsTaken);
			bool nicknameIsTaken = await readRepository.ExistAsync(x => x.Nickname == request.Nickname && x.Id != request.Id, cancellationToken: cancellationToken);
			await authorRules.NicknameAlreadyTaken(nicknameIsTaken);
			ResponseContainer<UpdateAuthorCommandResponse> response = new() { Data = new() };
			if (request.ProfileImage != null) 
			{
				ImageResponseModel imageResponseModel = await imageHelper.CreateOrUpdateImage(request.ProfileImage, Domain.Enums.ImageType.Author,author.ImageId ?? 0, cancellationToken);
				author.ImageId = imageResponseModel.ImageId;
				response.Data.ProfileImagePath = imageResponseModel.ImagePath;
			}
			author.Password = author.Password.Encrypt();
			await writeRepository.UpdateAsync(author);
			await uow.SaveChangesAsync(cancellationToken);
			response.Success = true;
			response.Message = Const.Author.AUTHOR_UPDATED;
			return response;

		}

	}
}
