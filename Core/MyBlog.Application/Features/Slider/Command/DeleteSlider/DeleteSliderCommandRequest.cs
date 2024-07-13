using MediatR;
using MyBlog.Application.Interfaces;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Slider.Command.DeleteSlider
{
	public class DeleteSliderCommandRequest:IRequest<ResponseContainer<Unit>>,IId
	{
        public DeleteSliderCommandRequest()
        {
            
        }
        public DeleteSliderCommandRequest(int id)
		{
			Id = id;
		}

		public int Id { get; set; }
    }
}
