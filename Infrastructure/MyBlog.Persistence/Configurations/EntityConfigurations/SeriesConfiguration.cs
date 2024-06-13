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
	internal class SeriesConfiguration : IEntityTypeConfiguration<Series>
	{
		public void Configure(EntityTypeBuilder<Series> builder)
		{
			builder.Property(m => m.Title).HasMaxLength(100).IsRequired();
			builder.HasIndex(m=>m.Url).IsUnique();
		}
	}
}
