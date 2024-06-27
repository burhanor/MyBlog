using MediatR;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Tag.Queries.GetTags
{
	public class GetTagsQueryRequest:FilterModel,IRequest<ResponseContainer<IList<GetTagsQueryResponse>>>
	{

	}
}
