using MyBlog.Application.Bases;
using MyBlog.Application.Exceptions.AuthorExceptions;
using MyBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Auth.Rules
{
	public class AuthRules : BaseRules
	{

		public ValueTask EmailAlreadyTaken(Author? author) => author != null && author.Id!=0 ? throw new EmailAlreadyTakenException() : ValueTask.CompletedTask;
		public ValueTask EmailAlreadyTaken(bool isTaken) => isTaken ? throw new EmailAlreadyTakenException() : ValueTask.CompletedTask;

		public ValueTask NicknameAlreadyTaken(Author? author) => author != null && author.Id!=0 ? throw new NicknameAlreadyTakenException() : ValueTask.CompletedTask;
		public ValueTask NicknameAlreadyTaken(bool isTaken) => isTaken ? throw new NicknameAlreadyTakenException() : ValueTask.CompletedTask;

		public ValueTask UserNotFound(Author? author) => author == null || author.Id == 0 ? throw new UserNotFoundException() : ValueTask.CompletedTask;

	}
}
