using MyBlog.Application.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Persistence.UnitOfWork
{
	public class Uow : IUow
	{
		public ValueTask DisposeAsync()
		{
			throw new NotImplementedException();
		}
	}
}
