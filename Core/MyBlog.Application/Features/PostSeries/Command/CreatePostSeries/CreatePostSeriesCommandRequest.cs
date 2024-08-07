﻿using MediatR;
using MyBlog.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.PostSeries.Command.CreatePostSeries
{
	public class CreatePostSeriesCommandRequest:IRequest<ResponseContainer<CreatePostSeriesCommandResponse>>
	{
        public CreatePostSeriesCommandRequest()
        {
            
        }

		public CreatePostSeriesCommandRequest(int postId, int seriesId, int displayOrder)
		{
			PostId = postId;
			SeriesId = seriesId;
			DisplayOrder = displayOrder;
		}

		public int PostId { get; set; }
		public int SeriesId { get; set; }
        public int DisplayOrder { get; set; }
    }
}
