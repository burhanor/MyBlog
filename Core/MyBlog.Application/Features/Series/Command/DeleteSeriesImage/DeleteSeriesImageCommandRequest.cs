using MediatR;
using MyBlog.Application.Models;
using MyBlog.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Series.Command.DeleteSeriesImage
{
	public class DeleteSeriesImageCommandRequest:IRequest<ResponseContainer<Unit>>
	{
        public int SeriesId { get; set; }
		public ImageType ImageType { get; set; }
	}
}
