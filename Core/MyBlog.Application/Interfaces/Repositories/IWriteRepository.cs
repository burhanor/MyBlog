using MyBlog.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Interfaces.Repositories
{
	public interface IWriteRepository<T> where T : class,IEntityBase,new()
	{
	}
}
