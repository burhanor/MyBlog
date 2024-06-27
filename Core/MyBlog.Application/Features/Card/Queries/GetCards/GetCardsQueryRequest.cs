using MediatR;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Card.Queries.GetCards
{
	public class GetCardsQueryRequest:FilterModel,IRequest<ResponseContainer<IList<GetCardsQueryResponse>>>
	{
	}
}
