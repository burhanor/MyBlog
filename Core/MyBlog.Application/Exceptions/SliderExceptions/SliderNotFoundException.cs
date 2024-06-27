using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Exceptions.SliderExceptions
{
	public class SliderNotFoundException : ApplicationException
	{
		public SliderNotFoundException() : base(Const.Slider.SLIDER_NOT_FOUND)
		{
		}
		public SliderNotFoundException(string message) : base(message)
		{
		}
	}
}
