using FluentValidation;
using MyBlog.Application.Consts;

namespace MyBlog.Application.Features.Menu.Command.UpdateMenu
{
	public class UpdateMenuCommandValidator:AbstractValidator<UpdateMenuCommandRequest>
	{
        public UpdateMenuCommandValidator()
        {
			RuleFor(m => m.Name)
				.NotEmpty().WithMessage(Const.Menu.MENU_NAME_REQUIRED)
				.MaximumLength(100).WithMessage(Const.Menu.MENU_NAME_MAX_LENGTH);
			RuleFor(m => m.Url)
				.NotEmpty().WithMessage(Const.Menu.MENU_URL_REQUIRED)
				.MaximumLength(450).WithMessage(Const.Menu.MENU_URL_MAX_LENGTH);

		}
    }
}
