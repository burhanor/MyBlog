using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Bases;
using MyBlog.Application.Consts;
using MyBlog.Application.Features.Slider.Command.UpdateSlider;
using MyBlog.Application.Features.Slider.Rules;
using MyBlog.Application.Features.Slider.Rules;
using MyBlog.Application.Helpers;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Slider.Command.UpdateSlider
{
	public class UpdateSliderCommandHandler : BaseHandler<Domain.Entities.Slider>, IRequestHandler<UpdateSliderCommandRequest, ResponseContainer<UpdateSliderCommandResponse>>
	{
		private readonly SliderRules sliderRules;
		private readonly ImageHelper imageHelper;

		public UpdateSliderCommandHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor,SliderRules sliderRules,ImageHelper imageHelper) : base(uow, mapper, httpContextAccessor)
		{
			this.sliderRules = sliderRules;
			this.imageHelper = imageHelper;
		}

		public async Task<ResponseContainer<UpdateSliderCommandResponse>> Handle(UpdateSliderCommandRequest request, CancellationToken cancellationToken)
		{
			ResponseContainer<UpdateSliderCommandResponse> response=new() { Data = new() };
			await sliderRules.DisplayOrderMustBePositive(request.DisplayOrder);
			Domain.Entities.Slider slider = await readRepository.GetAsync(m => m.Id == request.Id, cancellationToken: cancellationToken);
			await sliderRules.SliderNotFound(slider);
			string imagePath = string.Empty;
			if (request.Image != null)
			{
				await sliderRules.ValidateImage(request.Image);
				ImageResponseModel imageResponse = await imageHelper.CreateOrUpdateImage(request.Image, Domain.Enums.ImageType.Slider, slider.ImageId, cancellationToken);
				slider.ImageId = imageResponse.ImageId;
				imagePath = imageResponse.ImagePath;
			}
			else
				imagePath = (await uow.GetReadRepository<Domain.Entities.Image>().GetAsync(select: m => new TModel<string> { Value = m.Path }, predicate: m => m.Id == slider.ImageId, cancellationToken: cancellationToken)).Value ?? string.Empty;

			Domain.Entities.Slider newRecord = mapper.Map<Domain.Entities.Slider, UpdateSliderCommandRequest>(request);
			newRecord.ImageId = slider.ImageId;
			await writeRepository.UpdateAsync(newRecord);
			await uow.SaveChangesAsync(cancellationToken);
			response.Success = true;
			response.Message = Const.Slider.SLIDER_UPDATED;
			response.Data = mapper.Map<UpdateSliderCommandResponse, Domain.Entities.Slider>(newRecord);
			response.Data.ImagePath = imagePath;
			return response;

		}
	}
}
