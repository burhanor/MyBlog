using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Exceptions.SliderExceptions
{
	public class SliderAlreadyExistException : ApplicationException
	{
		public SliderAlreadyExistException() : base(Const.Slider.SLIDER_ALREADY_EXISTS)
		{
		}
		public SliderAlreadyExistException(string message) : base(message)
		{
		}
	}
}
