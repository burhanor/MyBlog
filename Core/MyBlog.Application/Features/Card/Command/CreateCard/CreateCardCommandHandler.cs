using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Consts;
using MyBlog.Application.Features.Card.Rules;
using MyBlog.Application.Helpers;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Card.Command.CreateCard
{
	public class CreateCardCommandHandler : BaseHandler<Domain.Entities.Card>, IRequestHandler<CreateCardCommandRequest, ResponseContainer<CreateCardCommandResponse>>
	{
		private readonly CardRules cardRules;
		private readonly ImageHelper imageHelper;

		public CreateCardCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor,CardRules cardRules,ImageHelper imageHelper) : base(uow, mapper, httpContextAccessor)
		{
			this.cardRules = cardRules;
			this.imageHelper = imageHelper;
		}

		public async Task<ResponseContainer<CreateCardCommandResponse>> Handle(CreateCardCommandRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<CreateCardCommandResponse> response = new();
			await cardRules.ValidateImage(request.Image);
			await cardRules.DisplayOrderMustBePositive(request.DisplayOrder);
			Domain.Entities.Card card = new Domain.Entities.Card
			{
				Title = request.Title,
				Content = request.Content,
				DisplayOrder = request.DisplayOrder,
				Url = request.Url
			}; 
			ImageResponseModel imageResponse = await imageHelper.CreateImage(request.Image,Domain.Enums.ImageType.Card,cancellationToken);
			card.ImageId = imageResponse.ImageId;
			await writeRepository.AddAsync(card,cancellationToken);
			await uow.SaveChangesAsync(cancellationToken);
			if (card.Id>0)
			{
				response.Data=new CreateCardCommandResponse
				{
					Id=card.Id,
					ImagePath=imageResponse.ImagePath,
					Content=card.Content,
					DisplayOrder=card.DisplayOrder,	
					Title=card.Title,
					Url=card.Url
				};	
				response.Success=true;
				response.Message = Const.Card.CARD_CREATED;
			}
			return response;
		}
	}
}
