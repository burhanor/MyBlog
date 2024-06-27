using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Card.Command.UpdateCard
{
	public class UpdateCardCommandValidator:AbstractValidator<UpdateCardCommandRequest>
	{
        public UpdateCardCommandValidator()
        {
            
        }
    }
}
