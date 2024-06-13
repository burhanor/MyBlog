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
	internal class TagConfiguration : IEntityTypeConfiguration<Tag>
	{
		public void Configure(EntityTypeBuilder<Tag> builder)
		{
			builder.Property(m=>m.Name).HasMaxLength(50).IsRequired();
			builder.HasIndex(m => m.Url).IsUnique();
		}
	}
}
