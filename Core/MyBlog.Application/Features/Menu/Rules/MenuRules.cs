using MyBlog.Application.Commons.Rules;
using MyBlog.Application.Exceptions.MenuExceptions;

namespace MyBlog.Application.Features.Menu.Rules
{
	public class MenuRules:CommonRules
	{
		public async ValueTask MenuNotFound(Domain.Entities.Menu? menu)
		{
			if (menu == null || menu.Id == 0)
			{
				throw new MenuNotFoundException();
			}
			await ValueTask.CompletedTask;
		}

		public async ValueTask MenuAlreadyExists(Domain.Entities.Menu? menu)
		{
			if (menu != null && menu.Id != 0)
			{
				throw new MenuAlreadyExistException();
			}
			await ValueTask.CompletedTask;
		}

		public async ValueTask MenuAlreadyExists(bool isExist)
		{
			if (isExist)
			{
				throw new MenuAlreadyExistException();
			}
			await ValueTask.CompletedTask;
		}


		public async ValueTask MenuParentCannotBeSame(int menuId, int parentId)
		{
			if (menuId == parentId)
				throw new MenuParentCannotBeSameException();
			await ValueTask.CompletedTask;
		}

		public async ValueTask ParentMenuNotFound(Domain.Entities.Menu? menu)
		{
			if (menu == null || menu.Id == 0)
			{
				throw new ParentMenuNotFoundException();
			}
			await ValueTask.CompletedTask;
		}

		public async ValueTask MenuHasChild(bool hasChild)
		{
			if (hasChild)
				throw new MenuHasChildException();
			await ValueTask.CompletedTask;
		}

	}
}
