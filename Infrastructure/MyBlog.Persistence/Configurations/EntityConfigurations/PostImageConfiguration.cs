﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Persistence.Configurations.EntityConfigurations
{
	internal class PostImageConfiguration : IEntityTypeConfiguration<PostImage>
	{
		public void Configure(EntityTypeBuilder<PostImage> builder)
		{
			builder.HasKey(m=> new { m.PostId, m.ImageId });
		
		}
	}
}
