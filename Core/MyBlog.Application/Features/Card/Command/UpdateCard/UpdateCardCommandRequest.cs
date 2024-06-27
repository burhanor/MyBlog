using MediatR;
using MyBlog.Application.Interfaces;
using MyBlog.Application.Models;
using MyBlog.Application.Models.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Card.Command.UpdateCard
{
	public class UpdateCardCommandRequest:CardModel,IRequest<ResponseContainer<UpdateCardCommandResponse>>,IId
	{
        public int Id { get; set; }
    }
}
