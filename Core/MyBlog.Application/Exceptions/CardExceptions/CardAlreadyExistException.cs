using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Exceptions.CardExceptions
{
	public class CardAlreadyExistException:ApplicationException
	{
        public CardAlreadyExistException():base(Const.Card.CARD_ALREADY_EXISTS)
        {
            
        }
        public CardAlreadyExistException(string message):base(message)
        {
            
        }
    }
}
