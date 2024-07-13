using MediatR;
using MyBlog.Application.Interfaces;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Author.Command.ChangePassword
{
	public class ChangePasswordCommandRequest:IRequest<ResponseContainer<ChangePasswordCommandResponse>>, IId
	{
        public ChangePasswordCommandRequest()
        {
            
        }
        public ChangePasswordCommandRequest(string password)
		{
			Password = password;
		}

		public ChangePasswordCommandRequest(int ıd, string password)
		{
			Id = ıd;
			Password = password;
		}

		public int Id { get; set; }
        public string Password { get; set; } = string.Empty;
    }
}
