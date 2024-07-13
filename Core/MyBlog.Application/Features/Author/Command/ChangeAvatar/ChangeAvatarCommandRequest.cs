using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Interfaces;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Author.Command.ChangeAvatar
{
	public class ChangeAvatarCommandRequest:IRequest<ResponseContainer<ChangeAvatarCommandResponse>>,IId
	{
        public ChangeAvatarCommandRequest()
        {
            
        }

		public ChangeAvatarCommandRequest(IFormFile image)
		{
			Image = image;
		}

		public ChangeAvatarCommandRequest(int id, IFormFile image)
		{
			Id = id;
			Image = image;
		}

		public int Id { get; set; }
        public IFormFile Image { get; set; }
    }
}
