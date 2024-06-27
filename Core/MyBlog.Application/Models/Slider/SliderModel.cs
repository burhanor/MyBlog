using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Models.Slider
{
	public class SliderModel
	{
		public string Title { get; set; } = string.Empty;
		public string Content { get; set; } = string.Empty;
		public int DisplayOrder { get; set; }
		public string Url { get; set; } = string.Empty;
		public IFormFile? Image { get; set; }
	}
}
