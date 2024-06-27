using MediatR;
using MyBlog.Application.Interfaces;
using MyBlog.Application.Models;
using MyBlog.Application.Models.Tag;

namespace MyBlog.Application.Features.Tag.Command.UpdateTag
{
	public class UpdateTagCommandRequest:TagModel,IRequest<ResponseContainer<UpdateTagCommandResponse>>,IId
	{
        public int Id { get; set; }
    }
}
