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
	internal class PostCategoryConfiguration : IEntityTypeConfiguration<PostCategory>
	{
		public void Configure(EntityTypeBuilder<PostCategory> builder)
		{
			builder.HasKey(m => new { m.PostId, m.CategoryId });
		}
	}
}
