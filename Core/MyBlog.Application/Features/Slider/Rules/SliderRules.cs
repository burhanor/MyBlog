using MyBlog.Application.Commons.Rules;
using MyBlog.Application.Exceptions.SliderExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Slider.Rules
{
	public class SliderRules:CommonRules
	{

		public async ValueTask SliderNotFound(Domain.Entities.Slider? slider)
		{
			if (slider == null || slider.Id == 0)
			{
				throw new SliderNotFoundException();
			}
			await ValueTask.CompletedTask;
		}

		public async ValueTask SliderAlreadyExists(Domain.Entities.Slider? slider)
		{
			if (slider != null && slider.Id != 0)
			{
				throw new SliderAlreadyExistException();
			}
			await ValueTask.CompletedTask;
		}

		public async ValueTask SliderAlreadyExists(bool isExist)
		{
			if (isExist)
			{
				throw new SliderAlreadyExistException();
			}
			await ValueTask.CompletedTask;
		}
	}
}
