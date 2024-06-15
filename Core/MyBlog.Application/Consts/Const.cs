using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Consts
{
	public static class Const
	{
		public static class Token { 
		public const string INVALID_TOKEN = "INVALID_TOKEN";
		}


		public static class Author
		{
			public const string EMAIL_ALREADY_TAKEN = "EMAIL_ALREADY_TAKEN";
			public const string NICKNAME_ALREADY_TAKEN = "NICKNAME_ALREADY_TAKEN";
			public const string EMAIL_REQUIRED = "EMAIL_REQUIRED";
			public const string NICKNAME_REQUIRED = "NICKNAME_REQUIRED";
			public const string PASSWORD_REQUIRED = "PASSWORD_REQUIRED";
			public const string INVALID_EMAIL= "INVALID_EMAIL";

			public const string AUTHOR_CREATED = "AUTHOR_CREATED";
		}


		public static class Regex
		{
			public const string EMAIL_REGEX = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
		}

	}
}
