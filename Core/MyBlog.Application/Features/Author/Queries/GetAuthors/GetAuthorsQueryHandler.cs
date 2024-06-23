using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Author.Queries.GetAuthors
{
	public class GetAuthorsQueryHandler : BaseHandler<Domain.Entities.Author>,IRequestHandler<GetAuthorsQueryRequest, ResponseContainer<IList<GetAuthorsQueryResponse>>>
	{
		public GetAuthorsQueryHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor) : base(uow, mapper, httpContextAccessor)
		{
		}

		public async Task<ResponseContainer<IList<GetAuthorsQueryResponse>>> Handle(GetAuthorsQueryRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<IList<GetAuthorsQueryResponse>> response = new();
			return response;
		}
	}
}
