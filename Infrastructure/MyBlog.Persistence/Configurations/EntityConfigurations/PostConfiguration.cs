using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Persistence.Configurations.EntityConfigurations
{
	internal class PostConfiguration : IEntityTypeConfiguration<Post>
	{
		public void Configure(EntityTypeBuilder<Post> builder)
		{
			builder.Property(m => m.Title).IsRequired();
			builder.HasIndex(m=>m.Url).IsUnique();
		}
	}
}
