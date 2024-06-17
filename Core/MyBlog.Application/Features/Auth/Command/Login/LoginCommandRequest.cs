using MediatR;
using MyBlog.Application.Models;
using MyBlog.Application.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Auth.Command.Login
{
	public class LoginCommandRequest:LoginModel,IRequest<ResponseContainer<LoginCommandResponse>>
	{
	}
}
