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
	internal class SeriesImageConfiguration : IEntityTypeConfiguration<SeriesImage>
	{
		public void Configure(EntityTypeBuilder<SeriesImage> builder)
		{
			builder.HasKey(m => new { m.SeriesId, m.ImageId });
			
		}
	}
}
