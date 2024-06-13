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
	internal class AuthorConfiguration : IEntityTypeConfiguration<Author>
	{
		public void Configure(EntityTypeBuilder<Author> builder)
		{
			builder.HasIndex(m=>m.Nickname).IsUnique();
			builder.HasIndex(m=>m.EmailAddress).IsUnique();
			builder.Property(m=>m.Nickname).HasMaxLength(20).IsRequired();
			builder.Property(m=>m.EmailAddress).HasMaxLength(320).IsRequired();
		}
	}
}
