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
	internal class PostSeriesConfiguration : IEntityTypeConfiguration<PostSeries>
	{
		public void Configure(EntityTypeBuilder<PostSeries> builder)
		{
			builder.HasKey(m => new { m.PostId, m.SeriesId });
		
			builder.HasOne(ps => ps.Series)
				.WithMany(s => s.PostSeries)
				.HasForeignKey(ps => ps.SeriesId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
