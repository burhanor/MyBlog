using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Consts;
using MyBlog.Application.Extensions;
using MyBlog.Application.Features.Auth.Rules;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.Tokens;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using MyBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Auth.Command.Login
{
	public class LoginCommandHandler : BaseHandler<Author>, IRequestHandler<LoginCommandRequest, ResponseContainer<LoginCommandResponse>>
	{
		private readonly AuthRules authRules;
		private readonly ITokenService tokenService;

		public LoginCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor,AuthRules authRules,ITokenService tokenService) : base(uow, mapper, httpContextAccessor)
		{
			this.authRules = authRules;
			this.tokenService = tokenService;
		}

		public async Task<ResponseContainer<LoginCommandResponse>> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
		{
			string passwordHash = request.Password.Encrypt();
			Author? author =await readRepository.GetAsync(x => (x.Nickname == request.NickNameOrEmailAddress || x.EmailAddress == request.NickNameOrEmailAddress) && x.Password==passwordHash,cancellationToken:cancellationToken);
			await authRules.UserNotFound(author);
			ResponseContainer<LoginCommandResponse> response = new()
			{
			   Data=new()
			};
			// Create a token
			JwtSecurityToken token = await tokenService.GenerateAccessToken(author,null);
			response.Data.AccessToken= new JwtSecurityTokenHandler().WriteToken(token);
			response.Data.RefreshToken = tokenService.GenerateRefreshToken();
			author.RefreshToken = response.Data.RefreshToken;
			author.Token= response.Data.AccessToken;
			await writeRepository.UpdateAsync(author);
			await uow.SaveChangesAsync(cancellationToken);
			response.Message= Const.Auth.SUCCESS_LOGIN;
			return response;
		}
	}
}
