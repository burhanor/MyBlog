using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.PostCategory.Command.UpdatePostCategory
{
	public class UpdatePostCategoryCommandValidator:AbstractValidator<UpdatePostCategoryCommandRequest>
	{
		public UpdatePostCategoryCommandValidator()
		{
		}
	}
}
