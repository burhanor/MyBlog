using MyBlog.Application.Features.Auth.Command.Login;

namespace MyBlog.Application.Models.Auth
{
	public class LoginModel
	{
		public string NickNameOrEmailAddress { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;

		public LoginModel()
		{

		}
		public LoginModel(string nickNameOrEmailAddress, string password)
		{
			NickNameOrEmailAddress = nickNameOrEmailAddress;
			Password = password;
		}
		public LoginCommandRequest ToCommandRequest()
		{
			return new LoginCommandRequest
			{
				NickNameOrEmailAddress = NickNameOrEmailAddress,
				Password = Password
			};
		}
	}
}
