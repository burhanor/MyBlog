using FluentValidation;
using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.PostTag.Command.CreatePostTag
{
	public class CreatePostTagCommandValidator:AbstractValidator<CreatePostTagCommandRequest>
	{
        public CreatePostTagCommandValidator()
        {
			RuleFor(m => m.TagId).GreaterThan(0).WithMessage(Const.PostCategory.CATEGORY_ID_MUST_BE_GREATER_THAN_ZERO);
			RuleFor(m => m.PostId).GreaterThan(0).WithMessage(Const.PostCategory.POST_ID_MUST_BE_GREATER_THAN_ZERO);

		}
    }
}
