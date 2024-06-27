using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Consts;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Slider.Command.DeleteSlider
{
	public class DeleteSliderCommandHandler : BaseHandler<Domain.Entities.Slider>, IRequestHandler<DeleteSliderCommandRequest, ResponseContainer<Unit>>
	{
		public DeleteSliderCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor) : base(uow, mapper, httpContextAccessor)
		{
		}

		public async Task<ResponseContainer<Unit>> Handle(DeleteSliderCommandRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<Unit> response = new();
			await writeRepository.DeleteAsync(m => m.Id == request.Id, cancellationToken);
			await uow.SaveChangesAsync(cancellationToken);
			response.Success = true;
			response.Message = Const.Slider.SLIDER_DELETED;
			return response;
		}
	}
}
