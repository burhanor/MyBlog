using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.PostSeries.Command.CreatePostSeries
{
	public class CreatePostSeriesCommandValidator:AbstractValidator<CreatePostSeriesCommandRequest>
	{
        public CreatePostSeriesCommandValidator()
        {
            
        }
    }
}
