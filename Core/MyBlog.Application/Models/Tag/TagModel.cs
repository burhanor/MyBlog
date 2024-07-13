using MyBlog.Application.Features.Tag.Command.CreateTag;
using MyBlog.Application.Features.Tag.Command.UpdateTag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Models.Tag
{
	public class TagModel
	{
		public string Name { get; set; } = string.Empty;
		public int DisplayOrder { get; set; }
		public string Url { get; set; } = string.Empty;
		public bool IsHidden { get; set; }

		public CreateTagCommandRequest ToCreateCommandRequest() {

			return new CreateTagCommandRequest
			{
				DisplayOrder = DisplayOrder,
				IsHidden = IsHidden,
				Name = Name,
				Url = Url
			};
		}

		public UpdateTagCommandRequest ToUpdateCommandRequest(int id)
		{

			return new UpdateTagCommandRequest
			{
				Id = id,
				DisplayOrder = DisplayOrder,
				IsHidden = IsHidden,
				Name = Name,
				Url = Url
			};
		}
	}
}
