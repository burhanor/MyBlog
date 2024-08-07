﻿using MediatR;
using MyBlog.Application.Models;
using MyBlog.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Post.Command.DeletePostImage
{
	public class DeletePostImageCommandRequest : IRequest<ResponseContainer<Unit>>
	{
        public DeletePostImageCommandRequest()
        {
            
        }
        public DeletePostImageCommandRequest(int postId, ImageType imageType)
		{
			PostId = postId;
			ImageType = imageType;
		}

		public int PostId { get; set; }
		public ImageType ImageType { get; set; }
	}
}
