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
			public const string INVALID_NICKNAME = "INVALID_NICKNAME";
			public const string EMAIL_REQUIRED = "EMAIL_REQUIRED";
			public const string NICKNAME_REQUIRED = "NICKNAME_REQUIRED";
			public const string PASSWORD_REQUIRED = "PASSWORD_REQUIRED";
			public const string INVALID_EMAIL= "INVALID_EMAIL";
			public const string AUTHOR_CREATED = "AUTHOR_CREATED";
			public const string AUTHOR_UPDATED = "AUTHOR_UPDATED";
			public const string NICKNAME_OR_EMAIL_REQUIRED = "NICKNAME_OR_EMAIL_REQUIRED";
			public const string AUTHOR_NOT_FOUND = "AUTHOR_NOT_FOUND";
			public const string AUTHOR_DELETED = "AUTHOR_DELETED";
			public const string PASSWORD_CHANGED = "PASSWORD_CHANGED";

		}

		public static class Auth
		{
			public const string SUCCESS_LOGIN = "SUCCESS_LOGIN";
		}


		public static class Regex
		{
			public const string NICKNAME_REGEX = @"^[a-zA-Z][a-zA-Z0-9_.]{2,15}$";
			public const string EMAIL_REGEX = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
		}


		public static class Exception
		{
			public const string IMAGE_IS_NOT_VALID = "IMAGE_IS_NOT_VALID";
			public const string IMAGE_CANNOT_BE_NULL = "IMAGE_CANNOT_BE_NULL";
			public const string NICKNAME_IS_NOT_VALID = "NICKNAME_IS_NOT_VALID";
		}

	}
}
