using MediatR;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.PostSeries.Queries.GetPostSeries
{
	public class GetPostSeriesQueryRequest:FilterModel,IRequest<ResponseContainer<IList<GetPostSeriesQueryResponse>>>
	{
        public int SeriesId { get; set; }
    }
}
