using FluentValidation;
using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.PostRecommendation.Command.CreatePostRecommendation
{
	public class CreatePostRecommendationCommandValidator:AbstractValidator<CreatePostRecommendationCommandRequest>
	{
        public CreatePostRecommendationCommandValidator()
        {
            RuleFor(m=>m.DisplayOrder).GreaterThan(0).WithMessage(Const.Exception.DISPLAY_ORDER_MUST_BE_GREATER_THAN_ZERO);
        }
    }
}
