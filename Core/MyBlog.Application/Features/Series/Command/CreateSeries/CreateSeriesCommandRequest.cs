using MediatR;
using MyBlog.Application.Models;
using MyBlog.Application.Models.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Series.Command.CreateSeries
{
	public class CreateSeriesCommandRequest:SeriesModel,IRequest<ResponseContainer<CreateSeriesCommandResponse>>
	{
	}
}
