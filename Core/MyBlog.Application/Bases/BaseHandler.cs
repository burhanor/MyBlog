using Microsoft.AspNetCore.Http;
using MyBlog.Application.Extensions;
using MyBlog.Application.Interfaces.AutoMapper;
using MyBlog.Application.Interfaces.Repositories;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Domain.Commons;
using System.Security.Claims;

namespace MyBlog.Application.Bases
{
	// Mediatr handler metodlarında sıklıkla kullanılan yapıları bu sınıf içerisinde tutulacak
	public class BaseHandler<T> where T : class, IEntityBase, new()
	{
		public readonly IMyMapper mapper;
		public readonly IUow uow;
		public readonly IHttpContextAccessor httpContextAccessor;
		public readonly int userId = 0;
		public readonly IReadRepository<T> readRepository;
		public readonly IWriteRepository<T> writeRepository;
		public BaseHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor) : base()
		{
			this.uow = uow;
			this.mapper = mapper;
			this.httpContextAccessor = httpContextAccessor;
			userId = httpContextAccessor.GetUserId();
			readRepository = uow.GetReadRepository<T>();
			writeRepository = uow.GetWriteRepository<T>();
		}
	}

	public class BaseHandler
	{
		public readonly IMyMapper mapper;
		public readonly IUow uow;
		public readonly IHttpContextAccessor httpContextAccessor;
		public readonly int userId = 0;
		public BaseHandler(IUow uow, IMyMapper mapper, IHttpContextAccessor httpContextAccessor) : base()
		{
			this.uow = uow;
			this.mapper = mapper;
			this.httpContextAccessor = httpContextAccessor;
			userId = httpContextAccessor.GetUserId();
		}


	}
}
