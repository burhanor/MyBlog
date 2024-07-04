using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyBlog.Application.Interfaces.Functions;
using MyBlog.Domain.Enums;
using MyBlog.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Persistence.Functions
{
	public class ScalarFunctions(BlogDbContext dbContext) : IScalarFunction
	{
		public int GetSeriesImageId(int seriesId, ImageType imageType)
		{
			
			return dbContext.GetSeriesImageId(seriesId, imageType);
		}
		public string GetSeriesImagePath(int seriesId, ImageType imageType)
		{
			return dbContext.GetSeriesImagePath(seriesId, imageType);
		}
	}
}
