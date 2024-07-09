using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyBlog.Domain.Entities;
using MyBlog.Domain.Enums;
using MyBlog.Domain.Views;
using MyBlog.Persistence.Migrations;
using System.Numerics;

namespace MyBlog.Persistence.Contexts
{
	public class BlogDbContext:DbContext
	{
		public BlogDbContext()
		{
		}

		public BlogDbContext(DbContextOptions options) : base(options)
		{
		}
		#region Tables
		public DbSet<Author> Authors { get; set; }
		public DbSet<Card> Cards { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Image> Images { get; set; }
		public DbSet<Menu> Menus { get; set; }
		public DbSet<Post> Posts { get; set; }
		public DbSet<PostCategory> PostCategories { get; set; }
		public DbSet<PostImage> PostImages { get; set; }
		public DbSet<PostRecommendation> PostRecommendations { get; set; }
		public DbSet<PostSeries> PostSeries { get; set; }
		public DbSet<PostTag> PostTags { get; set; }
		public DbSet<PostView> PostViews { get; set; }
		public DbSet<Series> Series { get; set; }
		public DbSet<SeriesImage> SeriesImages { get; set; }
		public DbSet<Slider> Sliders { get; set; }
		public DbSet<SocialLink> SocialLinks { get; set; }
		public DbSet<Tag> Tags { get; set; }


		#endregion

		#region Views
		public DbSet<AuthorSummary> AuthorSummaries { get; set; }
		public DbSet<CategoryWithParentName> CategorriesWithParentName { get; set; }
		public DbSet<CardSummary> CardSummaries { get; set; }
        public DbSet<SliderSummary> SliderSummaries { get; set; }
		public DbSet<MenuWithParentName> MenuWithParentNames { get; set; }
		public DbSet<SeriesSummary> SeriesSummaries { get; set; }
		public DbSet<PostSeriesSummary> PostSeriesSummaries { get; set; }

		#endregion

		#region Functions
		//TODO : Fonksiyonları entity kullanmadan sadece select ile çek
		public int GetSeriesImageId(int seriesId, ImageType imageType)
		{
			return Series.Select(m => GetSeriesImageId(seriesId, imageType)).FirstOrDefault();
		}

		public string GetSeriesImagePath(int seriesId, ImageType imageType)
		{
			return Series.Select(m => GetSeriesImagePath(seriesId, imageType)).FirstOrDefault()??string.Empty;
		}

		public int GetPostImageId(int postId, ImageType imageType)
		{
			return Posts.Select(m => GetPostImageId(postId, imageType)).FirstOrDefault();
		}

		public string GetPostImagePath(int postId, ImageType imageType)
		{
			return Posts.Select(m => GetPostImagePath(postId, imageType)).FirstOrDefault() ?? string.Empty;
		}

		public int GetPostViewCount(int postId)
		{
			return Posts.Select(m => GetPostViewCount(postId)).FirstOrDefault();
		}

		#endregion



		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogDbContext).Assembly);
			ConfigureFunctions(modelBuilder);
		}

		private static void ConfigureFunctions(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDbFunction(typeof(BlogDbContext).GetMethod(nameof(GetSeriesImageId)))
				.HasName("GetSeriesImageId");
			modelBuilder.HasDbFunction(typeof(BlogDbContext).GetMethod(nameof(GetSeriesImagePath)))
				.HasName("GetSeriesImagePath");

			modelBuilder.HasDbFunction(typeof(BlogDbContext).GetMethod(nameof(GetPostImageId)))
				.HasName("GetPostImageId");
			modelBuilder.HasDbFunction(typeof(BlogDbContext).GetMethod(nameof(GetPostImagePath)))
				.HasName("GetPostImagePath");


			modelBuilder.HasDbFunction(typeof(BlogDbContext).GetMethod(nameof(GetPostViewCount)))
				.HasName("GetPostViewCount");
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
	
		}
	}
}
