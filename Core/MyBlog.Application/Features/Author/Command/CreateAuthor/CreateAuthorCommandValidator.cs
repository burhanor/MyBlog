using FluentValidation;
using MyBlog.Application.Consts;

namespace MyBlog.Application.Features.Author.Command.CreateAuthor
{
	public class CreateAuthorCommandValidator:AbstractValidator<CreateAuthorCommandRequest>
	{
		public CreateAuthorCommandValidator()
        {
			RuleFor(x => x.Nickname).NotEmpty().WithMessage(Const.Author.NICKNAME_REQUIRED);
			RuleFor(x => x.Nickname).Matches(Const.Regex.NICKNAME_REGEX).WithMessage(Const.Author.INVALID_NICKNAME);
			RuleFor(x => x.EmailAddress).NotEmpty().WithMessage(Const.Author.EMAIL_REQUIRED);
			RuleFor(x => x.EmailAddress).Matches(Const.Regex.EMAIL_REGEX).WithMessage(Const.Author.INVALID_EMAIL);
			RuleFor(x => x.Password).NotEmpty().WithMessage(Const.Author.PASSWORD_REQUIRED);
		}
    }
}
