using Microsoft.EntityFrameworkCore;
using MyBlog.Domain.Entities;
using MyBlog.Domain.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		#endregion
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogDbContext).Assembly);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
	
		}
	}
}
