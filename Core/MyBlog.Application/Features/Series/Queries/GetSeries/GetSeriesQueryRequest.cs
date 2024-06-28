using MediatR;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Series.Queries.GetSeries
{
	public class GetSeriesQueryRequest:FilterModel,IRequest<ResponseContainer<IList<GetSeriesQueryResponse>>>
	{
	}
}
