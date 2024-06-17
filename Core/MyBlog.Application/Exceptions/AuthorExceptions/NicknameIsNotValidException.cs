using MyBlog.Application.Bases;
using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Exceptions.AuthorExceptions
{
	public class NicknameIsNotValidException:BaseException
	{
        public NicknameIsNotValidException():base(Const.Exception.NICKNAME_IS_NOT_VALID)
        {
            
        }
    }
}
