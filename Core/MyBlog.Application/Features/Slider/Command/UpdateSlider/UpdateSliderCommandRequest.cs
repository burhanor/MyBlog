using MediatR;
using MyBlog.Application.Interfaces;
using MyBlog.Application.Models;
using MyBlog.Application.Models.Slider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Slider.Command.UpdateSlider
{
	public class UpdateSliderCommandRequest:SliderModel,IRequest<ResponseContainer<UpdateSliderCommandResponse>>,IId
	{
		public int Id { get; set; }
	}
}
