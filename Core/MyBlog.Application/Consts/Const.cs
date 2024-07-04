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

		public static class PostCategory
		{
			public const string POST_CATEGORY_CREATED = "POST_CATEGORY_CREATED";
			public const string POST_CATEGORY_UPDATED = "POST_CATEGORY_UPDATED";
			public const string POST_CATEGORY_DELETED = "POST_CATEGORY_DELETED";
			public const string POST_CATEGORY_NOT_FOUND = "POST_CATEGORY_NOT_FOUND";
			public const string POST_CATEGORY_ALREADY_EXISTS = "POST_CATEGORY_ALREADY_EXISTS";
			public const string CATEGORY_ID_MUST_BE_GREATER_THAN_ZERO = "CATEGORY_ID_MUST_BE_GREATER_THAN_ZERO";
			public const string POST_ID_MUST_BE_GREATER_THAN_ZERO = "POST_ID_MUST_BE_GREATER_THAN_ZERO";

		}
		public static class PostSeries
		{
			public const string POST_SERIES_CREATED = "POST_SERIES_CREATED";
			public const string POST_SERIES_UPDATED = "POST_SERIES_UPDATED";
			public const string POST_SERIES_DELETED = "POST_SERIES_DELETED";
			public const string POST_SERIES_NOT_FOUND = "POST_SERIES_NOT_FOUND";
			public const string POST_SERIES_ALREADY_EXISTS = "POST_SERIES_ALREADY_EXISTS";
			public const string SERIES_ID_MUST_BE_GREATER_THAN_ZERO = "SERIES_ID_MUST_BE_GREATER_THAN_ZERO";
			public const string POST_ID_MUST_BE_GREATER_THAN_ZERO = "POST_ID_MUST_BE_GREATER_THAN_ZERO";
		}
		public static class PostTag
		{
			public const string POST_TAG_CREATED = "POST_TAG_CREATED";
			public const string POST_TAG_UPDATED = "POST_TAG_UPDATED";
			public const string POST_TAG_DELETED = "POST_TAG_DELETED";
			public const string POST_TAG_NOT_FOUND = "POST_TAG_NOT_FOUND";
			public const string POST_TAG_ALREADY_EXISTS = "POST_TAG_ALREADY_EXISTS";
			public const string TAG_ID_MUST_BE_GREATER_THAN_ZERO = "TAG_ID_MUST_BE_GREATER_THAN_ZERO";
			public const string POST_ID_MUST_BE_GREATER_THAN_ZERO = "POST_ID_MUST_BE_GREATER_THAN_ZERO";
		}

		public static class Post
		{
			public const string POST_CREATED = "POST_CREATED";
			public const string POST_UPDATED = "POST_UPDATED";
			public const string POST_DELETED = "POST_DELETED";
			public const string POST_NOT_FOUND = "POST_NOT_FOUND";
			public const string POST_ALREADY_EXISTS = "POST_ALREADY_EXISTS";
			public const string POST_TITLE_REQUIRED = "POST_TITLE_REQUIRED";
			public const string POST_TITLE_MAX_LENGTH = "POST_TITLE_MAX_LENGTH";
			public const string POST_CONTENT_REQUIRED = "POST_CONTENT_REQUIRED";
			public const string POST_CONTENT_MAX_LENGTH = "POST_CONTENT_MAX_LENGTH";
			public const string POST_URL_REQUIRED = "POST_URL_REQUIRED";
			public const string POST_URL_MAX_LENGTH = "POST_URL_MAX_LENGTH";
			public const string POST_CATEGORY_REQUIRED = "POST_CATEGORY_REQUIRED";
			public const string POST_AUTHOR_REQUIRED = "POST_AUTHOR_REQUIRED";
		}
		public static class PostRecommendation
		{
			public const string POST_RECOMMENDATION_CREATED = "POST_RECOMMENDATION_CREATED";
			public const string POST_RECOMMENDATION_DELETED = "POST_RECOMMENDATION_DELETED";
			public const string POST_RECOMMENDATION_NOT_FOUND = "POST_RECOMMENDATION_NOT_FOUND";
			public const string POST_RECOMMENDATION_ALREADY_EXISTS = "POST_RECOMMENDATION_ALREADY_EXISTS";
		}
		public static class Series
		{
			public const string SERIES_CREATED = "SERIES_CREATED";
			public const string SERIES_UPDATED = "SERIES_UPDATED";
			public const string SERIES_DELETED = "SERIES_DELETED";
			public const string SERIES_NOT_FOUND = "SERIES_NOT_FOUND";
			public const string SERIES_ALREADY_EXISTS = "SERIES_ALREADY_EXISTS";
			public const string SERIES_TITLE_REQUIRED = "SERIES_TITLE_REQUIRED";
			public const string SERIES_TITLE_MAX_LENGTH = "SERIES_TITLE_MAX_LENGTH";
			public const string SERIES_URL_REQUIRED = "SERIES_URL_REQUIRED";
			public const string SERIES_URL_MAX_LENGTH = "SERIES_URL_MAX_LENGTH";

		}
		public static class SeriesImages
		{
			public const string POST_SERIES_IMAGE_UPDATED = "POST_SERIES_IMAGE_UPDATED";	
			public const string POST_SERIES_IMAGE_DELETED = "POST_SERIES_IMAGE_DELETED";	
		}
		public static class Menu
		{
			public const string MENU_CREATED = "MENU_CREATED";
			public const string MENU_UPDATED = "MENU_UPDATED";
			public const string MENU_DELETED = "MENU_DELETED";
			public const string MENU_NOT_FOUND = "MENU_NOT_FOUND";
			public const string MENU_ALREADY_EXISTS = "MENU_ALREADY_EXISTS";
			public const string MENU_NAME_REQUIRED = "MENU_NAME_REQUIRED";
			public const string MENU_NAME_MAX_LENGTH = "MENU_NAME_MAX_LENGTH";
			public const string MENU_URL_REQUIRED = "MENU_URL_REQUIRED";
			public const string MENU_URL_MAX_LENGTH = "MENU_URL_MAX_LENGTH";
			public const string MENU_DISPLAY_ORDER_REQUIRED = "MENU_DISPLAY_ORDER_REQUIRED";
			public const string MENU_DISPLAY_ORDER_MUST_BE_GREATER_THAN_ZERO = "MENU_DISPLAY_ORDER_MUST_BE_GREATER_THAN_ZERO";
			public const string PARENT_MENU_NOT_FOUND = "PARENT_MENU_NOT_FOUND";
			public const string MENU_CIRCULAR_REFERENCE = "MENU_CIRCULAR_REFERENCE";
			public const string MENU_HAS_CHILD = "MENU_HAS_CHILD";
			public const string MENU_PARENT_CANNOT_BE_SAME = "MENU_PARENT_CANNOT_BE_SAME";

		}
		public static class Card
		{
			public const string CARD_CREATED = "CARD_CREATED";
			public const string CARD_UPDATED = "CARD_UPDATED";
			public const string CARD_DELETED = "CARD_DELETED";
			public const string CARD_NOT_FOUND = "CARD_NOT_FOUND";
			public const string CARD_ALREADY_EXISTS = "CARD_ALREADY_EXISTS";
			public const string CARD_TITLE_REQUIRED = "CARD_TITLE_REQUIRED";
			public const string CARD_TITLE_MAX_LENGTH = "CARD_TITLE_MAX_LENGTH";
			public const string CARD_CONTENT_REQUIRED = "CARD_CONTENT_REQUIRED";
			public const string CARD_CONTENT_MAX_LENGTH = "CARD_CONTENT_MAX_LENGTH";
			public const string CARD_URL_REQUIRED = "CARD_URL_REQUIRED";
			public const string CARD_URL_MAX_LENGTH = "CARD_URL_MAX_LENGTH";

		}
		public static class Slider
		{
			public const string SLIDER_CREATED = "SLIDER_CREATED";
			public const string SLIDER_UPDATED = "SLIDER_UPDATED";
			public const string SLIDER_DELETED = "SLIDER_DELETED";
			public const string SLIDER_NOT_FOUND = "SLIDER_NOT_FOUND";
			public const string SLIDER_ALREADY_EXISTS = "SLIDER_ALREADY_EXISTS";
			public const string SLIDER_TITLE_REQUIRED = "SLIDER_TITLE_REQUIRED";
			public const string SLIDER_TITLE_MAX_LENGTH = "SLIDER_TITLE_MAX_LENGTH";
			public const string SLIDER_CONTENT_REQUIRED = "SLIDER_CONTENT_REQUIRED";
			public const string SLIDER_CONTENT_MAX_LENGTH = "SLIDER_CONTENT_MAX_LENGTH";
			public const string SLIDER_URL_REQUIRED = "SLIDER_URL_REQUIRED";
			public const string SLIDER_URL_MAX_LENGTH = "SLIDER_URL_MAX_LENGTH";
		}

		public static class Tag
		{
			public const string TAG_CREATED = "TAG_CREATED";	
			public const string TAG_UPDATED = "TAG_UPDATED";
			public const string TAG_DELETED = "TAG_DELETED";
			public const string TAG_NOT_FOUND = "TAG_NOT_FOUND";
			public const string TAG_ALREADY_EXISTS = "TAG_ALREADY_EXISTS";
			public const string TAG_NAME_REQUIRED = "TAG_NAME_REQUIRED";
			public const string TAG_NAME_MAX_LENGTH = "TAG_NAME_MAX_LENGTH";
			public const string TAG_URL_REQUIRED = "TAG_URL_REQUIRED";
			public const string TAG_URL_MAX_LENGTH = "TAG_URL_MAX_LENGTH";
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
