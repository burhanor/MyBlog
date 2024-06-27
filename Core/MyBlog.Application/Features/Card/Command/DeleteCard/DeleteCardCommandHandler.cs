using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Consts;
using MyBlog.Application.Features.Card.Rules;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Card.Command.DeleteCard
{
	public class DeleteCardCommandHandler : BaseHandler<Domain.Entities.Card>, IRequestHandler<DeleteCardCommandRequest, ResponseContainer<Unit>>
	{
		public DeleteCardCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor) : base(uow, mapper, httpContextAccessor)
		{
		}

		public async Task<ResponseContainer<Unit>> Handle(DeleteCardCommandRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<Unit> response = new();
			await writeRepository.DeleteAsync(m => m.Id == request.Id, cancellationToken);
			await uow.SaveChangesAsync(cancellationToken);
			response.Success = true;
			response.Message= Const.Card.CARD_DELETED;
			return response;
		}
	}
}
