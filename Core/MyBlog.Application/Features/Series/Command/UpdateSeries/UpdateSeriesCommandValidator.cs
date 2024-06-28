using FluentValidation;
using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Series.Command.UpdateSeries
{
	public class UpdateSeriesCommandValidator:AbstractValidator<UpdateSeriesCommandRequest>
	{
        public UpdateSeriesCommandValidator()
        {
			RuleFor(m => m.Title)
				.NotEmpty().WithMessage(Const.Series.SERIES_TITLE_REQUIRED)
				.MaximumLength(100).WithMessage(Const.Series.SERIES_TITLE_MAX_LENGTH);
			RuleFor(m => m.Url)
				.NotEmpty().WithMessage(Const.Series.SERIES_URL_REQUIRED)
				.MaximumLength(450).WithMessage(Const.Series.SERIES_URL_MAX_LENGTH);
		}
    }
}
