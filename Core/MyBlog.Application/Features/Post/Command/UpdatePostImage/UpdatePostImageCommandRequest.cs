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
	}
}
