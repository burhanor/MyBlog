using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Consts;
using MyBlog.Application.Features.Card.Rules;
using MyBlog.Application.Helpers;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using MyBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Card.Command.UpdateCard
{
	public class UpdateCardCommandHandler : BaseHandler<Domain.Entities.Card>, IRequestHandler<UpdateCardCommandRequest, ResponseContainer<UpdateCardCommandResponse>>
	{
		private readonly CardRules cardRules;
		private readonly ImageHelper imageHelper;

		public UpdateCardCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor,CardRules cardRules,ImageHelper imageHelper) : base(uow, mapper, httpContextAccessor)
		{
			this.cardRules = cardRules;
			this.imageHelper = imageHelper;
		}

		public async Task<ResponseContainer<UpdateCardCommandResponse>> Handle(UpdateCardCommandRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<UpdateCardCommandResponse> response = new() { Data = new() };
			await cardRules.DisplayOrderMustBePositive(request.DisplayOrder);
			Domain.Entities.Card card = await readRepository.GetAsync(m => m.Id == request.Id, cancellationToken: cancellationToken);
			await cardRules.CardNotFound(card);
			string imagePath = string.Empty;
			if (request.Image != null) {
				await cardRules.ValidateImage(request.Image);
				ImageResponseModel imageResponse = await imageHelper.CreateOrUpdateImage(request.Image,Domain.Enums.ImageType.Card,card.ImageId,cancellationToken);
				card.ImageId = imageResponse.ImageId;
				imagePath = imageResponse.ImagePath;
			}
			else
				imagePath = (await uow.GetReadRepository<Domain.Entities.Image>().GetAsync(select: m => new TModel<string> { Value = m.Path }, predicate: m => m.Id == card.ImageId, cancellationToken: cancellationToken)).Value ?? string.Empty;
		
			Domain.Entities.Card newRecord = mapper.Map<Domain.Entities.Card, UpdateCardCommandRequest>(request);
			newRecord.ImageId= card.ImageId;
			await writeRepository.UpdateAsync(newRecord);
			await uow.SaveChangesAsync(cancellationToken);
			response.Success = true;
			response.Message = Const.Card.CARD_UPDATED;
			response.Data = mapper.Map<UpdateCardCommandResponse,Domain.Entities.Card>(newRecord);
			response.Data.ImagePath = imagePath;
			return response;
		}
	}
}
