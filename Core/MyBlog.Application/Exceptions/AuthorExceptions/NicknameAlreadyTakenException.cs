using MyBlog.Application.Bases;
using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Exceptions.AuthorExceptions
{
	internal class NicknameAlreadyTakenException:BaseException
	{
		public NicknameAlreadyTakenException() : base(Const.Author.NICKNAME_ALREADY_TAKEN)
		{

		}
	}
}
