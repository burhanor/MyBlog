using Microsoft.AspNetCore.Http;
using MyBlog.Application.Features.Post.Command.CreatePost;
using MyBlog.Application.Features.Post.Command.UpdatePost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Models.Post
{
	public class PostModel
	{
		public string Title { get; set; } = string.Empty;
		public string Summary { get; set; } = string.Empty;
		public string HtmlContent { get; set; } = string.Empty;
		public string Url { get; set; } = string.Empty;
		public DateTime? PublishDate { get; set; }
		public bool IsPublished { get; set; }
		public IFormFile? HeaderImage { get; set; }
		public IFormFile? ThumbnailImage { get; set; }
        public PostModel()
        {
            
        }

		public CreatePostCommandRequest ToCreateCommandRequest() {
			return new CreatePostCommandRequest
			{
				HeaderImage = HeaderImage,
				HtmlContent = HtmlContent,
				IsPublished = IsPublished,
				PublishDate = PublishDate,
				Summary = Summary,
				ThumbnailImage = ThumbnailImage,
				Title = Title,
				Url = Url
			};
		}
		public UpdatePostCommandRequest ToUpdateCommandRequest(int id)
		{
			return new UpdatePostCommandRequest
			{
				Id = id,
				HeaderImage = HeaderImage,
				HtmlContent = HtmlContent,
				IsPublished = IsPublished,
				PublishDate = PublishDate,
				Summary = Summary,
				ThumbnailImage = ThumbnailImage,
				Title = Title,
				Url = Url
			};
		}
		
	}
}
