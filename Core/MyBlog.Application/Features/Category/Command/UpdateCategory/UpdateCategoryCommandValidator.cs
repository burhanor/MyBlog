using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Category.Command.UpdateCategory
{
	public class UpdateCategoryCommandValidator:AbstractValidator<UpdateCategoryCommandRequest>
	{
        public UpdateCategoryCommandValidator()
        {
            
        }
    }
}
