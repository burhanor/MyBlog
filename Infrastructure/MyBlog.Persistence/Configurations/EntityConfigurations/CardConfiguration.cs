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
	internal class CardConfiguration : IEntityTypeConfiguration<Card>
	{
		public void Configure(EntityTypeBuilder<Card> builder)
		{
			builder.Property(m => m.Url).IsRequired();
		}
	}
}
