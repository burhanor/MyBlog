using FluentValidation;
using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Auth.Command.Register
{
	public class RegisterCommandValidator: AbstractValidator<RegisterCommandRequest>
	{
		public RegisterCommandValidator()
		{
			RuleFor(x => x.Nickname).NotEmpty().WithMessage(Const.Author.NICKNAME_REQUIRED);
			RuleFor(x => x.EmailAddress).NotEmpty().WithMessage(Const.Author.EMAIL_REQUIRED);
			RuleFor(x => x.EmailAddress).Matches(Const.Regex.EMAIL_REGEX).WithMessage(Const.Author.INVALID_EMAIL);
			RuleFor(x => x.Password).NotEmpty().WithMessage(Const.Author.PASSWORD_REQUIRED);
		}
	}
}
