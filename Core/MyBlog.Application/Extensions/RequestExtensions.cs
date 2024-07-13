using MyBlog.Application.Features.Author.Queries.GetAuthors;
using MyBlog.Application.Features.Card.Queries.GetCards;
using MyBlog.Application.Features.Category.Queries.GetCategories;
using MyBlog.Application.Features.Menu.Queries.GetMenus;
using MyBlog.Application.Features.Post.Queries.GetPosts;
using MyBlog.Application.Features.Post.Queries.GetPublishedPosts;
using MyBlog.Application.Features.PostRecommendation.Queries.GetPostRecommendations;
using MyBlog.Application.Features.PostSeries.Queries.GetPostSeries;
using MyBlog.Application.Features.Series.Queries.GetSeries;
using MyBlog.Application.Features.Slider.Queries.GetSliders;
using MyBlog.Application.Features.Tag.Queries.GetTags;
using MyBlog.Application.Interfaces.Requests;

namespace MyBlog.Application.Extensions
{
	public static class RequestExtensions
	{
		public static bool IsNullOrEmpty(this IFilterRequest request)
		{
			if (request == null)
				return true;
			return request.PageSize == null && request.PageNumber == null && request.OrderBy == null && request.Search == null;
		}
	}
}
