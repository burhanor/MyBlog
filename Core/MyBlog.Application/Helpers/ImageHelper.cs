using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MyBlog.Application.Exceptions.CommonExceptions;
using MyBlog.Application.Extensions;
using MyBlog.Application.Interfaces.UnitOfWork;
using MyBlog.Application.Models;
using MyBlog.Domain.Entities;
using MyBlog.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MyBlog.Application.Helpers
{
	/// <summary>
	/// API icerisindeki resim kopyalama, guncelleme ve silme icin kullanılacak metodlar burada tanımlanacak
	/// </summary>
	public  class ImageHelper
	{

		private readonly IUow uow;

		private readonly string webRootPath;
		public ImageHelper(IUow uow, IHostingEnvironment _environment)
		{
			this.uow = uow;
			webRootPath = _environment.WebRootPath;
		}
	


		public async Task<ImageResponseModel> CreateImage(IFormFile file, ImageType imageType,CancellationToken cancellationToken)
		{
			ImageResponseModel response = new();

			await ValidateImage(file);
			Domain.Entities.Image image = PrepareImageModel(file, imageType);
			await SaveFile(file, image.Path);
			await uow.GetWriteRepository<Domain.Entities.Image>().AddAsync(image,cancellationToken);
			await uow.SaveChangesAsync(cancellationToken);
			response.ImageId = image.Id;
			response.ImagePath = image.Path.Replace(webRootPath, "");
			return response;
		}
		public async Task<ImageResponseModel> UpdateImage(IFormFile file, ImageType imageType,int id,CancellationToken cancellationToken)
		{
			ImageResponseModel response = new();

			await ValidateImage(file);
			Domain.Entities.Image image = PrepareImageModel(file, imageType,id);
			await SaveFile(file, image.Path);
			await uow.GetWriteRepository<Domain.Entities.Image>().UpdateAsync(image);
			await uow.SaveChangesAsync(cancellationToken);
			response.ImageId = id;
			response.ImagePath = image.Path.Replace(webRootPath, "");
			return response;
		}

		private Domain.Entities.Image PrepareImageModel(IFormFile file, ImageType imageType,int id=0)
		{
			string extension = file.GetFileExtension();
			string uniqueImageName = Guid.NewGuid().ToString();
			string imagePath = Path.Combine(webRootPath, "images", GetFolderName(imageType), uniqueImageName + extension);
			Domain.Entities.Image image = new()
			{
				ImageType = imageType,
				OriginalName = file.FileName,
				UniqueName = uniqueImageName,
				BinaryFile = file.GetBytes(),
				Path = imagePath.Replace(webRootPath, ""),
				Extension = extension,
				Id = id 
			};
			return image;

		}

		private static async ValueTask ValidateImage(IFormFile? file) { 
		
			if (file == null) 
				throw new ImageCannotBeNullException();
			if (!file.IsImage())
				throw new ImageIsNotValidException();
			await ValueTask.CompletedTask;
		}

		private static string GetFolderName(ImageType imageType)
		{
			return imageType switch
			{
				ImageType.SeriesHeader => "series",
				ImageType.SeriesThumbnail => "series",
				ImageType.PostHeader => "posts",
				ImageType.PostThumbnail => "posts",
				ImageType.Author => "authors",
				ImageType.Slider => "sliders",
				ImageType.Card => "cards",
				_ => "others",
			};
		}

		private  async Task SaveFile(IFormFile file, string path)
		{
			string combinePath = webRootPath+path;
			await using FileStream fileStream = new(combinePath, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true);
			await file.CopyToAsync(fileStream);
		}


	}
}
