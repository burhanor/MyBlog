using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Consts;
using MyBlog.Application.Extensions;
using MyBlog.Application.Features.Author.Rules;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using MyBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Author.Command.ChangePassword
{
	public class ChangePasswordCommandHandler:BaseHandler<Domain.Entities.Author>,IRequestHandler<ChangePasswordCommandRequest,ResponseContainer<ChangePasswordCommandResponse>>
	{
		private readonly AuthorRules authorRules;

		public ChangePasswordCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor,AuthorRules authorRules) : base(uow, mapper, httpContextAccessor)
		{
			this.authorRules = authorRules;
		}

		public async Task<ResponseContainer<ChangePasswordCommandResponse>> Handle(ChangePasswordCommandRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<ChangePasswordCommandResponse> response = new();
			Domain.Entities.Author? author = await readRepository.GetAsync(x => x.Id == userId, cancellationToken: cancellationToken,enableTracking:true);
			await authorRules.UserNotFound(author);
			author.Password = request.Password.Encrypt();
			await uow.SaveChangesAsync(cancellationToken);
			response.Success = true;
			response.Message = Const.Author.PASSWORD_CHANGED;
			return response;
		}
	}
}
