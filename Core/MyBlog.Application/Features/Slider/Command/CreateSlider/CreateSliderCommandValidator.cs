using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Slider.Command.CreateSlider
{
	public class CreateSliderCommandValidator:AbstractValidator<CreateSliderCommandRequest>
	{
        public CreateSliderCommandValidator()
        {
            
        }
    }
}
