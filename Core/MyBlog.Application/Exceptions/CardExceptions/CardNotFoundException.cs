using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Exceptions.CardExceptions
{
	public class CardNotFoundException:ApplicationException
	{
		public CardNotFoundException() : base(Const.Card.CARD_NOT_FOUND)
		{

		}
		public CardNotFoundException(string message) : base(message)
		{

		}
	}
}
