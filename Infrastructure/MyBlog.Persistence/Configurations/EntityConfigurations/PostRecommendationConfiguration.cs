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
	internal class PostRecommendationConfiguration : IEntityTypeConfiguration<PostRecommendation>
	{
		public void Configure(EntityTypeBuilder<PostRecommendation> builder)
		{
			builder.HasKey(m => m.PostId);
		}
	}
}
