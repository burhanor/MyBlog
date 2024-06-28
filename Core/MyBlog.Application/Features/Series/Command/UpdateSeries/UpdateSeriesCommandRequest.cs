using MediatR;
using MyBlog.Application.Interfaces;
using MyBlog.Application.Models;
using MyBlog.Application.Models.Series;

namespace MyBlog.Application.Features.Series.Command.UpdateSeries
{
	public class UpdateSeriesCommandRequest:SeriesModel,IRequest<ResponseContainer<UpdateSeriesCommandResponse>>,IId
	{
		public int Id { get; set; }
	}
}
