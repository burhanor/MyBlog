using Microsoft.AspNetCore.Http;
using MyBlog.Application.Features.Author.Command.CreateAuthor;
using MyBlog.Application.Features.Author.Command.UpdateAuthor;

namespace MyBlog.Application.Models.Author
{
	public class AuthorModel
	{
		public AuthorModel()
		{

		}
		public AuthorModel(string nickname, string emailAddress, string password, string summary)
		{
			Nickname = nickname;
			EmailAddress = emailAddress;
			Password = password;
			Summary = summary;
		}

		public AuthorModel(string nickname, string emailAddress, string password, string summary, IFormFile? profileImage) : this(nickname, emailAddress, password, summary)
		{
			ProfileImage = profileImage;
		}

		public string Nickname { get; set; } = string.Empty;
		public string EmailAddress { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
		public string Summary { get; set; } = string.Empty;
		public IFormFile? ProfileImage { get; set; }

		public CreateAuthorCommandRequest ToCreateCommandRequest()
		{
			return new CreateAuthorCommandRequest
			{
				Nickname = Nickname,
				EmailAddress = EmailAddress,
				Password = Password,
				Summary = Summary,
				ProfileImage = ProfileImage
			};
		}

		public UpdateAuthorCommandRequest ToUpdateCommandRequest(int id)
		{
			return new UpdateAuthorCommandRequest
			{
				Nickname = Nickname,
				EmailAddress = EmailAddress,
				Password = Password,
				Summary = Summary,
				ProfileImage = ProfileImage,
				Id=id
			};

		}

	}
}
