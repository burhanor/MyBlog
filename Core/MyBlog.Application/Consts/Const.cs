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

		public static class Category { 
		
			public const string CATEGORY_CREATED = "CATEGORY_CREATED";
			public const string CATEGORY_UPDATED = "CATEGORY_UPDATED";
			public const string CATEGORY_DELETED = "CATEGORY_DELETED";
			public const string CATEGORY_NOT_FOUND = "CATEGORY_NOT_FOUND";
			public const string CATEGORY_ALREADY_EXISTS = "CATEGORY_ALREADY_EXISTS";
			public const string PARENT_CATEGORY_NOT_FOUND = "PARENT_CATEGORY_NOT_FOUND";
			public const string CATEGORY_CIRCULAR_REFERENCE = "CATEGORY_CIRCULAR_REFERENCE";
			public const string CATEGORY_HAS_CHILD = "CATEGORY_HAS_CHILD";
			public const string CATEGORY_PARENT_CANNOT_BE_SAME = "CATEGORY_PARENT_CANNOT_BE_SAME";

			public const string CATEGORY_NAME_REQUIRED = "CATEGORY_NAME_REQUIRED";
			public const string CATEGORY_NAME_MAX_LENGTH = "CATEGORY_NAME_MAX_LENGTH";

			public const string CATEGORY_URL_REQUIRED = "CATEGORY_URL_REQUIRED";
			public const string CATEGORY_URL_MAX_LENGTH = "CATEGORY_URL_MAX_LENGTH";
		
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
			public const string DISPLAY_ORDER_MUST_BE_GREATER_THAN_ZERO = "DISPLAY_ORDER_MUST_BE_GREATER_THAN_ZERO";
			public const string URL_MUST_BE_UNIQUE = "URL_MUST_BE_UNIQUE";
		}

	}
}
