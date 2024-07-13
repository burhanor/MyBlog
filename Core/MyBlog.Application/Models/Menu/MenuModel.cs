using MyBlog.Application.Features.Menu.Command.CreateMenu;
using MyBlog.Application.Features.Menu.Command.UpdateMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Models.Menu
{
	public class MenuModel
	{
		public MenuModel()
		{

		}
		public MenuModel(string name, int displayOrder, string iconContent, string url)
		{
			Name = name;
			DisplayOrder = displayOrder;
			IconContent = iconContent;
			Url = url;
		}

		public MenuModel(int parentId, string name, int displayOrder, string iconContent, string url)
		{
			ParentId = parentId;
			Name = name;
			DisplayOrder = displayOrder;
			IconContent = iconContent;
			Url = url;
		}

		public int ParentId { get; set; }
		public string Name { get; set; } = string.Empty;
		public int DisplayOrder { get; set; }
		public string IconContent { get; set; } = string.Empty;
		public string Url { get; set; } = string.Empty;

		public CreateMenuCommandRequest ToCreateCommandRequest()
		{
			return new CreateMenuCommandRequest { DisplayOrder = DisplayOrder, IconContent = IconContent, Name = Name, ParentId = ParentId, Url = Url };
		}
		public UpdateMenuCommandRequest ToUpdateCommandRequest(int id)
		{
			return new UpdateMenuCommandRequest { DisplayOrder = DisplayOrder, IconContent = IconContent, Name = Name, ParentId = ParentId, Url = Url,Id=id };
		}
	}
}
