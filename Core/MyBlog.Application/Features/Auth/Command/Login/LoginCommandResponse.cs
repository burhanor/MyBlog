using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Auth.Command.Login
{
	public class LoginCommandResponse
	{
		public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
	}
}
