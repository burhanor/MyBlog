using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Interfaces.AutoMapper
{
	public interface IMyMapper
	{
		public TDestination Map<TDestination, TSource>(TSource source, string? ignore = null, bool reverse = true);
		public IList<TDestination> Map<TDestination, TSource>(IList<TSource> source, string? ignore = null, bool reverse = true);
		public TDestination Map<TDestination>(object source, string? ignore = null, bool reverse = true);
		public IList<TDestination> Map<TDestination>(IList<object> source, string? ignore = null, bool reverse = true);
	}
}
