using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Slider.Command.UpdateSlider
{
	public class UpdateSliderCommandValidator:AbstractValidator<UpdateSliderCommandRequest>
	{
        public UpdateSliderCommandValidator()
        {
            
        }
    }
}
