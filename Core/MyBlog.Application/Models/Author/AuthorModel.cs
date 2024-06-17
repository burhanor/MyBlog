using Microsoft.AspNetCore.Http;

namespace MyBlog.Application.Models.Author
{
	public class AuthorModel
	{
		public string Nickname { get; set; } = string.Empty;
		public string EmailAddress { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
		public string Summary { get; set; } = string.Empty;
		public IFormFile? ProfileImage { get; set; }

	}
}
