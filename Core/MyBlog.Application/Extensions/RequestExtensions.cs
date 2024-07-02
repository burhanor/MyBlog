using MyBlog.Application.Features.Author.Queries.GetAuthors;
using MyBlog.Application.Features.Card.Queries.GetCards;
using MyBlog.Application.Features.Category.Queries.GetCategories;
using MyBlog.Application.Features.Menu.Queries.GetMenus;
using MyBlog.Application.Features.Slider.Queries.GetSliders;
using MyBlog.Application.Features.Series.Queries.GetSeries;
using MyBlog.Application.Features.Tag.Queries.GetTags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlog.Application.Features.Post.Queries.GetPosts;
using MyBlog.Application.Features.Post.Queries.GetPublishedPosts;
using MyBlog.Application.Features.PostRecommendation.Queries.GetPostRecommendations;

namespace MyBlog.Application.Extensions
{
	public static class RequestExtensions
	{
		public static bool IsNullOrEmpty(this GetAuthorsQueryRequest request)
		{
			if (request == null)
				return true;
			return request.PageSize == null && request.PageNumber == null && request.OrderBy == null && request.Search == null;
		}

		public static bool IsNullOrEmpty(this GetCategoriesQueryRequest request)
		{
			if (request == null)
				return true;
			return request.PageSize == null && request.PageNumber == null && request.OrderBy == null && request.Search == null;
		}
		public static bool IsNullOrEmpty(this GetTagsQueryRequest request)
		{
			if (request == null)
				return true;
			return request.PageSize == null && request.PageNumber == null && request.OrderBy == null && request.Search == null;
		}

		public static bool IsNullOrEmpty(this GetCardsQueryRequest request)
		{
			if (request == null)
				return true;
			return request.PageSize == null && request.PageNumber == null && request.OrderBy == null && request.Search == null;
		}
		public static bool IsNullOrEmpty(this GetSlidersQueryRequest request)
		{
			if (request == null)
				return true;
			return request.PageSize == null && request.PageNumber == null && request.OrderBy == null && request.Search == null;
		}

		public static bool IsNullOrEmpty(this GetMenusQueryRequest request)
		{
			if (request == null)
				return true;
			return request.PageSize == null && request.PageNumber == null && request.OrderBy == null && request.Search == null;
		}

		public static bool IsNullOrEmpty(this GetSeriesQueryRequest request)
		{
			if (request == null)
				return true;
			return request.PageSize == null && request.PageNumber == null && request.OrderBy == null && request.Search == null;
		}
		public static bool IsNullOrEmpty(this GetPostsQueryRequest request)
		{
			if (request == null)
				return true;
			return request.PageSize == null && request.PageNumber == null && request.OrderBy == null && request.Search == null;
		}
		public static bool IsNullOrEmpty(this GetPublishedPostsQueryRequest request)
		{
			if (request == null)
				return true;
			return request.PageSize == null && request.PageNumber == null && request.OrderBy == null && request.Search == null;
		}

		public static bool IsNullOrEmpty(this GetPostRecommendationsQueryRequest request)
		{
			if (request == null)
				return true;
			return request.PageSize == null && request.PageNumber == null && request.OrderBy == null && request.Search == null;
		}

	}
}
