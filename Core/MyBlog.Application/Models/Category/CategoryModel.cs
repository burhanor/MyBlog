using MyBlog.Application.Features.Category.Command.CreateCategory;
using MyBlog.Application.Features.Category.Command.UpdateCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Models.Category
{
	public class CategoryModel
	{
		public CategoryModel()
		{

		}

		public CategoryModel(string name, int displayOrder, string ıconContent, string url)
		{
			Name = name;
			DisplayOrder = displayOrder;
			IconContent = ıconContent;
			Url = url;
		}

		public CategoryModel(int parentId, string name, int displayOrder, string ıconContent, string url)
		{
			ParentId = parentId;
			Name = name;
			DisplayOrder = displayOrder;
			IconContent = ıconContent;
			Url = url;
		}

		public int ParentId { get; set; }
		public string Name { get; set; } = string.Empty;
		public int DisplayOrder { get; set; }
		public string IconContent { get; set; } = string.Empty;
		public string Url { get; set; } = string.Empty;

		public CreateCategoryCommandRequest ToCreateCommandRequest()
		{
			return new CreateCategoryCommandRequest()
			{
				DisplayOrder = DisplayOrder,
				IconContent = IconContent,
				Name = Name,
				ParentId = ParentId,
				Url = Url
			};
		}
		public UpdateCategoryCommandRequest ToUpdateCommandRequest(int id)
		{
			return new UpdateCategoryCommandRequest()
			{
				DisplayOrder = DisplayOrder,
				IconContent = IconContent,
				Name = Name,
				ParentId = ParentId,
				Url = Url,
				Id = id
			};
		}
	}
}
