using FluentValidation;
using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Auth.Command.Login
{
	public class LoginCommandValidator:AbstractValidator<LoginCommandRequest>
	{
		public LoginCommandValidator()
		{
			RuleFor(x => x.NickNameOrEmailAddress).NotEmpty().WithMessage(Const.Author.NICKNAME_OR_EMAIL_REQUIRED);
			RuleFor(x => x.Password).NotEmpty().WithMessage(Const.Author.PASSWORD_REQUIRED);
		}
	}
}
