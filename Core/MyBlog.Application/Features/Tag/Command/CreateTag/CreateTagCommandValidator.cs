using FluentValidation;
using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Tag.Command.CreateTag
{
	public class CreateTagCommandValidator:AbstractValidator<CreateTagCommandRequest>
	{
        public CreateTagCommandValidator()
        {
			RuleFor(m => m.Name)
				.NotEmpty().WithMessage(Const.Category.CATEGORY_NAME_REQUIRED)
				.MaximumLength(100).WithMessage(Const.Category.CATEGORY_NAME_MAX_LENGTH);
			RuleFor(m => m.Url)
				.NotEmpty().WithMessage(Const.Category.CATEGORY_URL_REQUIRED)
				.MaximumLength(450).WithMessage(Const.Category.CATEGORY_URL_MAX_LENGTH);
		}
    }
}
