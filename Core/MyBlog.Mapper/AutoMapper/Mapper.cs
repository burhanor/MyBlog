using AutoMapper.Internal;
using AutoMapper;
using MyBlog.Application.Interfaces.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Mapper.AutoMapper
{
	public class Mapper:IMyMapper
	{
		public static List<TypePair> typePairs = [];
		private IMapper MapperContainer;
		public TDestination Map<TDestination, TSource>(TSource source, string? ignore = null,bool reverse =true)
		{
			Configure<TDestination, TSource>(ignore: ignore, reverse: reverse);
			return MapperContainer.Map<TDestination>(source);
		}
		public IList<TDestination> Map<TDestination, TSource>(IList<TSource> source, string? ignore = null, bool reverse = true)
		{
			Configure<TDestination, TSource>(ignore: ignore, reverse: reverse);
			return MapperContainer.Map<IList<TDestination>>(source);
		}
		public TDestination Map<TDestination>(object source,string? ignore = null, bool reverse = true)
		{
			Configure<TDestination,object>(ignore: ignore,reverse:reverse);
			return MapperContainer.Map<TDestination>(source);
		}
		public IList<TDestination> Map<TDestination>(IList<object> source, string? ignore = null, bool reverse = true)
		{
			Configure<TDestination, object>(ignore: ignore, reverse: reverse);
			return MapperContainer.Map<IList<TDestination>>(source);
		}
		protected virtual void Configure<TDestination, TSource>(int depth = 5, bool reverse = true, string? ignore = null)
		{
			TypePair pair = new(typeof(TSource), typeof(TDestination));
			if (ignore == null && typePairs.Any(m => m.DestinationType == pair.DestinationType && m.SourceType == pair.SourceType))
				return;
			typePairs.Add(pair);
			MapperConfiguration config = new (cfg=>
			{
				foreach (var typePair in typePairs)
				{
					if (reverse)
					{
						if (ignore != null)
							cfg.CreateMap(typePair.SourceType, typePair.DestinationType).MaxDepth(depth).ForMember(ignore, m => m.Ignore()).ReverseMap();
						else
							cfg.CreateMap(typePair.SourceType, typePair.DestinationType).MaxDepth(depth).ReverseMap();
					}
					else {
						if (ignore != null)
							cfg.CreateMap(typePair.SourceType, typePair.DestinationType).MaxDepth(depth).ForMember(ignore, m => m.Ignore());
						else
							cfg.CreateMap(typePair.SourceType, typePair.DestinationType).MaxDepth(depth);
					}
					
				}
			});
			MapperContainer = config.CreateMapper();
		}
	}
}
