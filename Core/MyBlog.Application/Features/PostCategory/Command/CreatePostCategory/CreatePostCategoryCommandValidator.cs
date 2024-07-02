using FluentValidation;
using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.PostCategory.Command.CreatePostCategory
{
	public class CreatePostCategoryCommandValidator:AbstractValidator<CreatePostCategoryCommandRequest>
	{
		public CreatePostCategoryCommandValidator()
		{
			RuleFor(m => m.CategoryId).GreaterThan(0).WithMessage(Const.PostCategory.CATEGORY_ID_MUST_BE_GREATER_THAN_ZERO);
			RuleFor(m=>m.PostId).GreaterThan(0).WithMessage(Const.PostCategory.POST_ID_MUST_BE_GREATER_THAN_ZERO);
		}
	}
}
