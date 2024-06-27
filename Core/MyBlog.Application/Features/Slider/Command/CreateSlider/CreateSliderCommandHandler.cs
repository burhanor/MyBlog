using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Consts;
using MyBlog.Application.Features.Slider.Rules;
using MyBlog.Application.Helpers;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;

namespace MyBlog.Application.Features.Slider.Command.CreateSlider
{
	public class CreateSliderCommandHandler : BaseHandler<Domain.Entities.Slider>, IRequestHandler<CreateSliderCommandRequest, ResponseContainer<CreateSliderCommandResponse>>
	{
		private readonly SliderRules sliderRules;
		private readonly ImageHelper imageHelper;

		public CreateSliderCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor,SliderRules sliderRules,ImageHelper imageHelper) : base(uow, mapper, httpContextAccessor)
		{
			this.sliderRules = sliderRules;
			this.imageHelper = imageHelper;
		}

		public async Task<ResponseContainer<CreateSliderCommandResponse>> Handle(CreateSliderCommandRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<CreateSliderCommandResponse> response = new();
			await sliderRules.ValidateImage(request.Image);
			await sliderRules.DisplayOrderMustBePositive(request.DisplayOrder);
			Domain.Entities.Slider slider = new Domain.Entities.Slider
			{
				Title = request.Title,
				Content = request.Content,
				DisplayOrder = request.DisplayOrder,
				Url = request.Url
			};
			ImageResponseModel imageResponse = await imageHelper.CreateImage(request.Image, Domain.Enums.ImageType.Slider, cancellationToken);
			slider.ImageId = imageResponse.ImageId;
			await writeRepository.AddAsync(slider, cancellationToken);
			await uow.SaveChangesAsync(cancellationToken);
			if (slider.Id > 0)
			{
				response.Data = new CreateSliderCommandResponse
				{
					Id = slider.Id,
					ImagePath = imageResponse.ImagePath,
					Content = slider.Content,
					DisplayOrder = slider.DisplayOrder,
					Title = slider.Title,
					Url = slider.Url
				};
				response.Success = true;
				response.Message = Const.Slider.SLIDER_CREATED;
			}
			return response;
		}
	}
}
