using Microsoft.AspNetCore.Http;

namespace MyBlog.Application.Extensions
{
	//IFormFile için sıklıkla kullanılan metodlar burada tanımlanacak
	public static class FormFileExtension
	{

		public static string GetFileExtension(this IFormFile file)
		{
			return Path.GetExtension(file.FileName);
		}
		public static byte[] GetBytes(this IFormFile file)
		{
			using var memoryStream = new MemoryStream();
			file.CopyTo(memoryStream);
			return memoryStream.ToArray();
		}
		public static bool IsImage(this IFormFile file)
		{
			string extension = file.GetFileExtension();
			return extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif" || extension == ".bmp" || extension == ".webp" || extension == ".svg" || extension == ".ico" || extension == ".tiff";
		}
	}
}
