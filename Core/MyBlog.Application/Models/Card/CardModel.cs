using Microsoft.AspNetCore.Http;
using MyBlog.Application.Features.Card.Command.CreateCard;
using MyBlog.Application.Features.Card.Command.UpdateCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Models.Card
{
	public class CardModel
	{
        public CardModel()
        {
            
        }
        public CardModel(string title, string content, int displayOrder, string url)
		{
			Title = title;
			Content = content;
			DisplayOrder = displayOrder;
			Url = url;
		}

		public CardModel(string title, string content, int displayOrder, string url, IFormFile? image) : this(title, content, displayOrder, url)
		{
			Image = image;
		}

		public string Title { get; set; } = string.Empty;
		public string Content { get; set; } = string.Empty;
		public int DisplayOrder { get; set; }
		public string Url { get; set; } = string.Empty;
        public IFormFile? Image { get; set; }

		public CreateCardCommandRequest ToCreateCommandRequest() {
			return new CreateCardCommandRequest()
			{
				Content = Content,
				DisplayOrder = DisplayOrder,
				Image = Image,
				Title = Title,
				Url = Url
			};
		}

		public UpdateCardCommandRequest ToUpdateCommandRequest(int id)
		{
			return new UpdateCardCommandRequest()
			{
				Content = Content,
				DisplayOrder = DisplayOrder,
				Image = Image,
				Title = Title,
				Url = Url,
				Id = id
			};
		}
	}
}
