using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Series.Command.UpdateSeriesImage
{
	public class UpdateSeriesImageCommandValidator:AbstractValidator<UpdateSeriesImageCommandRequest>
	{
		public UpdateSeriesImageCommandValidator()
		{
		}
	}
}
