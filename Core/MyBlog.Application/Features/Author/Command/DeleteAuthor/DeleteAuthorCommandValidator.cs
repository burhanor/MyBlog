using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Author.Command.DeleteAuthor
{
	public class DeleteAuthorCommandValidator:AbstractValidator<DeleteAuthorCommandRequest>
	{
        public DeleteAuthorCommandValidator()
        {
            
        }
    }
}
