using MyBlog.Domain.Commons;
using MyBlog.Domain.Enums;

namespace MyBlog.Domain.Entities
{
	public class Author : EntityBase
	{
		public string Nickname { get; set; } = string.Empty;
		public string EmailAddress { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
		public string Summary { get; set; } = string.Empty;
		public int ImageId { get; set; }
		public string Token { get; set; } = string.Empty;
		public string RefreshToken { get; set; } = string.Empty;
		public AuthorType AuthorType { get; set; }

		public ICollection<Post> Posts { get; set; }
		public Image Image { get; set; }
		public ICollection<SocialLink> SocialLinks { get; set; }
		public ICollection<Series> Series { get; set; }


	}
}
