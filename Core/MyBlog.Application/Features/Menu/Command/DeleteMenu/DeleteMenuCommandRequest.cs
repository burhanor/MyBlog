﻿using MediatR;
using MyBlog.Application.Interfaces;
using MyBlog.Application.Models;

namespace MyBlog.Application.Features.Menu.Command.DeleteMenu
{
	public class DeleteMenuCommandRequest:IRequest<ResponseContainer<Unit>>,IId
	{
        public DeleteMenuCommandRequest()
        {
            
        }

		public DeleteMenuCommandRequest(int id)
		{
			Id = id;
		}

		public int Id { get; set; }
    }
}
