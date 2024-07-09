using Microsoft.EntityFrameworkCore;
using MyBlog.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Interfaces.Functions
{
	public interface IScalarFunction
	{
		int GetSeriesImageId(int seriesId, ImageType imageType);
		string GetSeriesImagePath(int seriesId, ImageType imageType);


		int GetPostImageId(int postId, ImageType imageType);
		string GetPostImagePath(int postId, ImageType imageType);
		int GetPostViewCount(int postId);
	}
}
