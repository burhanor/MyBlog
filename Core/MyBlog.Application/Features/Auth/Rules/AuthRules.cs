using MyBlog.Application.Bases;
using MyBlog.Application.Exceptions.AuthorExceptions;

namespace MyBlog.Application.Features.Auth.Rules
{
	public class AuthRules : BaseRules
	{

		public ValueTask EmailAlreadyTaken(Domain.Entities.Author? author) => author != null && author.Id!=0 ? throw new EmailAlreadyTakenException() : ValueTask.CompletedTask;
		public ValueTask EmailAlreadyTaken(bool isTaken) => isTaken ? throw new EmailAlreadyTakenException() : ValueTask.CompletedTask;

		public ValueTask NicknameAlreadyTaken(Domain.Entities.Author? author) => author != null && author.Id!=0 ? throw new NicknameAlreadyTakenException() : ValueTask.CompletedTask;
		public ValueTask NicknameAlreadyTaken(bool isTaken) => isTaken ? throw new NicknameAlreadyTakenException() : ValueTask.CompletedTask;

	


		public ValueTask UserNotFound(Domain.Entities.Author? author) => author == null || author.Id == 0 ? throw new UserNotFoundException() : ValueTask.CompletedTask;

	}
}
