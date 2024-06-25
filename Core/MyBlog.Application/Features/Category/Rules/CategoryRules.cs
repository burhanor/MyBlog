using MyBlog.Application.Bases;
using MyBlog.Application.Exceptions.CategoryExceptions;
using MyBlog.Application.Exceptions.CommonExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Features.Category.Rules
{
	public class CategoryRules:BaseRules
	{

		public CategoryRules() { }


		public async ValueTask CategoryNotFound(Domain.Entities.Category? category)
		{
			if (category == null || category.Id == 0)
			{
				throw new CategoryNotFoundException();
			}
			await ValueTask.CompletedTask;
		}

		public async ValueTask CategoryAlreadyExists(Domain.Entities.Category? category)
		{
			if (category != null && category.Id != 0)
			{
				throw new CategoryAlreadyExistException();
			}
			await ValueTask.CompletedTask;
		}

		public async ValueTask CategoryParentCannotBeSame(int categoryId,int parentId)
		{
			if(categoryId==parentId)
				throw new CategoryParentCannotBeSameException();
			await ValueTask.CompletedTask;
		}

		public async ValueTask ParentCategoryNotFound(Domain.Entities.Category? category)
		{
			if (category == null || category.Id == 0)
			{
				throw new ParentCategoryNotFoundException();
			}
			await ValueTask.CompletedTask;
		}

		public async ValueTask CheckCategoryCircular(int categoryId,int parentCategoryId)
		{
			if (parentCategoryId == 0)
				await ValueTask.CompletedTask;
			else
			{
				if (categoryId == parentCategoryId)
					throw new CategoryParentCannotBeSameException();
				//TODO: Check for circular reference
			}
			
		}

		public async ValueTask DisplayOrderMustBePositive(int displayOrder)
		{
			if (displayOrder < 0)
				throw new DisplayOrderCannotBeNegativeException();
			await ValueTask.CompletedTask;
		}
	}
}
