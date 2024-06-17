using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Consts;
using MyBlog.Application.Features.Auth.Rules;
using MyBlog.Application.Features.Author.Rules;
using MyBlog.Application.Helpers;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using MyBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Author.Command.CreateAuthor
{
	public class CreateAuthorCommandHandler : BaseHandler<Domain.Entities.Author>, IRequestHandler<CreateAuthorCommandRequest, ResponseContainer<CreateAuthorCommandResponse>>
	{
		private readonly AuthorRules authorRules;
		private readonly ImageHelper imageHelper;

		public CreateAuthorCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor,AuthorRules authorRules,ImageHelper imageHelper) : base(uow, mapper, httpContextAccessor)
		{
			this.authorRules = authorRules;
			this.imageHelper = imageHelper;
		}

		public async Task<ResponseContainer<CreateAuthorCommandResponse>> Handle(CreateAuthorCommandRequest request, CancellationToken cancellationToken)
		{
			Domain.Entities.Author? author = await readRepository.GetAsync(x => x.EmailAddress == request.EmailAddress, cancellationToken: cancellationToken);
			await authorRules.EmailAlreadyTaken(author);
			author = await readRepository.GetAsync(x => x.Nickname == request.Nickname, cancellationToken: cancellationToken);
			await authorRules.NicknameAlreadyTaken(author);

			author = mapper.Map<Domain.Entities.Author, CreateAuthorCommandRequest>(request);
			ResponseContainer<CreateAuthorCommandResponse> response = new() { Data = new() };
			if (request.ProfileImage != null) {

				ImageResponseModel imageResponseModel = await imageHelper.CreateImage(request.ProfileImage, Domain.Enums.ImageType.Author, cancellationToken);
				author.ImageId = imageResponseModel.ImageId;
				response.Data.ProfileImagePath = imageResponseModel.ImagePath;
			}
			await writeRepository.AddAsync(author,cancellationToken);
			await uow.SaveChangesAsync(cancellationToken);
			if (author.Id>0)
			{
				response.Success = true;
				response.Message = Const.Author.AUTHOR_CREATED;
				response.Data.Id = author.Id;
			}
			return response;
		}
	}
}
