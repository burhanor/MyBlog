using MediatR;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Auth.Command.Register
{
	public class RegisterCommandRequest: RegisterModel,IRequest<ResponseContainer<UnitModel>>
	{
	}
}
