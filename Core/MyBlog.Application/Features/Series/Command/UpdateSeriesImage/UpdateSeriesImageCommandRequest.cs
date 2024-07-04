﻿using MediatR;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Interfaces;
using MyBlog.Application.Models;
using MyBlog.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Series.Command.UpdateSeriesImage
{
	public class UpdateSeriesImageCommandRequest:IRequest<ResponseContainer<UpdateSeriesImageCommandResponse>>,IId
	{
        public int Id { get; set; }
        public ImageType ImageType { get; set; }
        public IFormFile Image { get; set; }
    }
}
