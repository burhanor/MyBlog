using MediatR;
using MyBlog.Application.Models;
using MyBlog.Application.Models.Slider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Slider.Command.CreateSlider
{
	public class CreateSliderCommandRequest:SliderModel,IRequest<ResponseContainer<CreateSliderCommandResponse>>
	{
	}
}
