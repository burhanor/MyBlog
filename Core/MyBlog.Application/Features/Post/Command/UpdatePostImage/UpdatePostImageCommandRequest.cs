using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Interfaces;
using MyBlog.Application.Models;
using MyBlog.Domain.Enums;

namespace MyBlog.Application.Features.Post.Command.UpdatePostImage
{
	public class UpdatePostImageCommandRequest : IRequest<ResponseContainer<UpdatePostImageCommandResponse>>, IId
	{
		public int Id { get; set; }
		public ImageType ImageType { get; set; }
		public IFormFile Image { get; set; }

        public UpdatePostImageCommandRequest()
        {
            
        }

		public UpdatePostImageCommandRequest(ImageType imageType, IFormFile image)
		{
			ImageType = imageType;
			Image = image;
		}

		public UpdatePostImageCommandRequest(int ıd, ImageType imageType, IFormFile image)
		{
			Id = ıd;
			ImageType = imageType;
			Image = image;
		}
	}
}
