﻿using FluentValidation;
using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Category.Command.CreateCategory
{
	public class CreateCategoryCommandValidator:AbstractValidator<CreateCategoryCommandRequest>
	{
        public CreateCategoryCommandValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty().WithMessage(Const.Category.CATEGORY_NAME_REQUIRED)
                .MaximumLength(100).WithMessage(Const.Category.CATEGORY_NAME_MAX_LENGTH);
			RuleFor(m => m.Name)
				.NotEmpty().WithMessage(Const.Category.CATEGORY_URL_REQUIRED)
				.MaximumLength(450).WithMessage(Const.Category.CATEGORY_URL_MAX_LENGTH);
		}
    }
}
