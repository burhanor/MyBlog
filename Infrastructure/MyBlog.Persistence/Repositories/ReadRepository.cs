using MyBlog.Application.Interfaces.Repositories;
using MyBlog.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Persistence.Repositories
{
	public class ReadRepository<T> : IWriteRepository<T> where T : class, IEntityBase, new()
	{
	}
}
