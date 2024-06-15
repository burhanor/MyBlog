﻿using MyBlog.Application.Bases;
using MyBlog.Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Exceptions.AuthorExceptions
{
	public class EmailAlreadyTakenException:BaseException
	{
		public EmailAlreadyTakenException():base(Const.Author.EMAIL_ALREADY_TAKEN)
		{

		}
    }
}
