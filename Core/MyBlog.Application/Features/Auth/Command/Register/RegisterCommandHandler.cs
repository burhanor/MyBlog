using MediatR;
using Microsoft.AspNetCore.Http;

using MyBlog.Application.Bases;
using MyBlog.Application.Consts;
using MyBlog.Application.Extensions;
using MyBlog.Application.Features.Auth.Rules;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using MyBlog.Domain.Entities;
using MyBlog.Domain.Enums;

namespace MyBlog.Application.Features.Auth.Command.Register
{
	public class RegisterCommandHandler :BaseHandler<Author>, IRequestHandler<RegisterCommandRequest, ResponseContainer<UnitModel>>
	{
		private readonly AuthRules authRules;

		public RegisterCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor,AuthRules authRules) : base(uow, mapper, httpContextAccessor)
		{
			this.authRules = authRules;
		}

		public async Task<ResponseContainer<UnitModel>> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<UnitModel> response = new();
			Author? author = await readRepository.GetAsync(x => x.EmailAddress == request.EmailAddress,cancellationToken:cancellationToken);
			await authRules.EmailAlreadyTaken(author);
			author = await readRepository.GetAsync(x => x.Nickname == request.Nickname, cancellationToken: cancellationToken);
			await authRules.NicknameAlreadyTaken(author);

			Author newAuthor = mapper.Map<Author, RegisterCommandRequest>(request);
			newAuthor.Password = newAuthor.Password.Encrypt();
			await writeRepository.AddAsync(newAuthor, cancellationToken);
			await uow.SaveChangesAsync(cancellationToken);
			response.Success = true;
			response.Message = Const.Author.AUTHOR_CREATED;

			return response;
		}
	}
}
