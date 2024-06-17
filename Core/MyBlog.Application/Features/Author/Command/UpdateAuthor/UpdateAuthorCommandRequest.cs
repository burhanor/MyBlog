using MediatR;
using MyBlog.Application.Interfaces;
using MyBlog.Application.Models;
using MyBlog.Application.Models.Author;

namespace MyBlog.Application.Features.Author.Command.UpdateAuthor
{
	public class UpdateAuthorCommandRequest: AuthorModel, IRequest<ResponseContainer<UpdateAuthorCommandResponse>>,IId
	{
        public int Id { get; set; }
    }
}
