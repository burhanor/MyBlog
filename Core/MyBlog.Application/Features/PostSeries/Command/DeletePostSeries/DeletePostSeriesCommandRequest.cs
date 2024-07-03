using MediatR;
using MyBlog.Application.Interfaces;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.PostSeries.Command.DeletePostSeries
{
	public class DeletePostSeriesCommandRequest:IRequest<ResponseContainer<Unit>>
	{
		public int PostId { get; set; }
		public int SeriesId { get; set; }
	}
}
