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
	internal class ImageConfiguration : IEntityTypeConfiguration<Image>
	{
		public void Configure(EntityTypeBuilder<Image> builder)
		{
			builder.Property(m=>m.OriginalName).IsRequired();
			builder.Property(m=>m.UniqueName).HasMaxLength(36).IsRequired();
			
		}
	}
}
